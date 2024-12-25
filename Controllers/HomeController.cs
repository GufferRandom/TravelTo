using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using TravelTo.Data;
using TravelTo.Dto;
using TravelTo.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using System.Net;
using Humanizer;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Collections;
using Microsoft.AspNetCore.Components.RenderTree;
using Mono.TextTemplating;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Formatters;
using NuGet.Protocol;
using static Azure.Core.HttpHeader;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
namespace TravelTo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly SignInManager<User> _signInManager;
        public HomeController(ApplicationDataContext context, IWebHostEnvironment webHostEnvironment, SignInManager<User> signInManager)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var turebi = _context.Turebis.ToList();
            if (_signInManager.IsSignedIn(User))
            {
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var get_user_favs = _context.UserAndTurebi.Where(u => u.User_Id == userid)
                                      .Select(u => u.turebi)
                                      .ToList().Count();
                ViewBag.howmany = get_user_favs;
            }
            return View(turebi);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Add()
        {
            var gettin_company = _context.Companies.ToList();
            ViewBag.company = gettin_company;
            return View();
        }
        [HttpPost]
        public IActionResult Add(TurebiDto turebi, string kompania)
        {
            if (turebi.image == null)
            {
                ModelState.AddModelError("image", "image is requered as hel");
            }
            if (ModelState.IsValid)
            {
                string wwwrootpath = webHostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(turebi.image.FileName);
                string productPath = Path.Combine(wwwrootpath, "turebi");
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }
                using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    turebi.image.CopyTo(fileStream);
                }
                int company_id = _context.Companies.Where(u => u.Name == kompania).
                                                        Select(u => u.Company_Id).
                                                        FirstOrDefault();
                var namdvili_turi = new Turebi()
                {
                    Name = turebi.Name,
                    Description = turebi.Description,
                    Price = turebi.Price,
                    image_name = filename,
                    Company_Id = company_id,
                };
                _context.Add(namdvili_turi);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult GetTuri(int id)
        {
            var get_turi = _context.Turebis.Where(x => x.id == id).Include(x => x.Company).FirstOrDefault();
            var Yvela_tur = _context.Turebis.ToList();
            Yvela_tur.Remove(get_turi);
            ViewBag.Yvela_tur = Yvela_tur;
            return View(get_turi);
        }
        [HttpGet, DisplayName("Edit")]
        public IActionResult Edit(int id)
        {
            var get_turi2 = _context.Turebis.Where(x => x.id == id).FirstOrDefault();
            ViewData["img_name"] = get_turi2.image_name;
            var get_turi_dto = new TurebiDto() { Name = get_turi2.Name, Description = get_turi2.Description, Price = get_turi2.Price };
            var companies = _context.Companies.Select(x => x.Name).ToList();
            ViewBag.companies = companies;
            return View(get_turi_dto);
        }
        [HttpPost]
        public IActionResult Edit(int id, TurebiDto turebi, string kompania)
        {
            var get_turi = _context.Turebis.Where(x => x.id == id).FirstOrDefault();
            string wwwrootpath = webHostEnvironment.WebRootPath;
            if (turebi.image != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(turebi.image.FileName);
                string productPath = Path.Combine(wwwrootpath, "turebi");
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }
                using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    turebi.image.CopyTo(fileStream);
                }
                get_turi.image_name = filename;
            };
            get_turi.Name = turebi.Name;
            get_turi.Price = turebi.Price;
            get_turi.Description = turebi.Description;
            var get_compani = _context.Companies.Where(x => x.Name == kompania).FirstOrDefault();
            get_turi.Company = get_compani;
            if (ModelState.IsValid)
            {
                _context.Update(get_turi);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var tobedeletedTur = _context.Turebis.Include("Company").Where(u => u.id == id).FirstOrDefault();
            var temp = tobedeletedTur;
            string wwwpath = webHostEnvironment.WebRootPath;
            string name = tobedeletedTur.image_name;
            string Full_Image_Url = Path.Combine(wwwpath, "turebi", name);
            System.IO.File.Delete(Full_Image_Url);
            _context.Remove(tobedeletedTur);
            _context.SaveChanges();
            TempData["WarmatebitWaishala"] = $"ტური წარმატებით წაიშალა სახელად {temp.Name} მწარმოებელი კომპანია: {temp.Company.Name}";
            return RedirectToAction("Index");

        }
        public IActionResult Yvela(int page_id)
        {
            int length_of_turebi = _context.Turebis.Count();
            int size = 5;
            int ramdeni_gverdi = (int)Math.Ceiling(length_of_turebi / (double)size);
            var getti_company = _context.Companies.ToList();
            ViewBag.company = getti_company;
            IQueryable<Turebi> query = _context.Turebis.Include("Company");
            var sortin = HttpContext.Session.GetString("Sortin");
            switch (sortin)
            {
                case "FasiZrda":
                    query = query.OrderBy(x => x.Price);
                    break;
                case "FasiKlebadoba":
                    query = query.OrderByDescending(x => x.Price);
                    break;
                case "Saxelizrda":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "SaxeliKlebadoba":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                default:
                    break;
            }
            ViewBag.current_page = page_id > 0 ? page_id : 1;
            ViewBag.ramdeni_gverdi = ramdeni_gverdi;
            if (page_id == 0)
            {
                var paged_tur = query.Take(size).ToList();
                return View(paged_tur);
            }
            var pagedTurebis = query.Skip((page_id - 1) * size).Take(size).ToList();

            return View(pagedTurebis);
        }

        public IActionResult Zebna(string names, string selected, string min, string max, string kompania)
        {
            double Max = Convert.ToDouble(max);
            double Min = Convert.ToDouble(min);
            ViewBag.current_page = 1;
            ViewBag.ramdeni_gverdi = 1;
            if (names == null && selected == null && min != null && max == null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(x => (int)x.Price > int.Parse(min)).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;
                ViewBag.company = get_company_name;
                return View(getting_turs1);
            }
            if (names == null && selected != null && min != null && max != null && kompania != null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == selected && u.Price > Min && u.Price < Max && u.Company.Name == kompania).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);
            }

            if (selected == null && names != null && min != null && max != null && kompania != null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == names && u.Price > Min && u.Price < Max && u.Company.Name == kompania).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);
            }
            if (names == null && selected == null && min == null && max == null && kompania != null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Company.Name == kompania).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);

            }
            if (names == null && selected == null && min != null && max != null && kompania != null)
            {
                var getting_turs1 = _context.Turebis.Select(u => u.Name).ToList();
                var get_tur = _context.Turebis.Include(u => u.Company).Where(u => u.Price > Min && u.Price < Max && u.Company.Name == kompania).ToList();
                ViewBag.turebi = getting_turs1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(get_tur);
            }

            if (names == null && selected != null && min != null && max != null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == selected && u.Price > Min && u.Price < Max).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);

            }
            if (selected == null && names != null && min != null && max != null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == names && u.Price > Min && u.Price < Max).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);
            }
            if (names == null && selected == null && min == null && max == null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return RedirectToAction("Yvela");
            }
            if (names == null && selected == null && min != null && max != null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.Select(u => u.Name).ToList();
                var get_tur = _context.Turebis.Include(u => u.Company).Where(u => u.Price > Min && u.Price < Max).ToList();
                ViewBag.turebi = getting_turs1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(get_tur);
            }
            if (names == null && selected != null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == selected).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);

            }
            if (selected == null && names != null)
            {
                var getting_turs1 = _context.Turebis.Include(u => u.Company).Where(u => u.Name == names).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(getting_turs1);
            }
            if (names == null && selected == null)
            {
                var getting_turs1 = _context.Turebis.ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;

                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;
                ViewBag.company = get_company_name;
                return RedirectToAction("Yvela");
            }

            var getting_turs = _context.Turebis.Include(u => u.Company).Where(u => u.Name == selected && u.Name == names).ToList();
            var getting_full_vals = _context.Turebis.Select(u => u.Name).ToList();
            ViewBag.turebi = getting_full_vals;
            var get_country_name1 = _context.Turebis.Select(u => u.Name).ToList();
            ViewBag.get_country_name = get_country_name1;

            return View(getting_turs);
        }
        public IActionResult ShoppingCart()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var get_user_favs = _context.UserAndTurebi.Where(u => u.User_Id == userid)
                                      .Select(u => u.turebi)
                                      .ToList();
                var get_user_fav_sastumroebi = _context.userAndSastumroebis.Where(u => u.User_Id == userid).Select(u => u.sastumroebi).ToList();
                ViewBag.sastumroebi = get_user_fav_sastumroebi;
                return View(get_user_favs);
            }
            return View();
        }
        [HttpPost]
        public IActionResult ShoppingCart(int id)
        {
            var refererUrl = Request.Headers["Referer"].ToString();
            if (_signInManager.IsSignedIn(User))
            {
                var getting = _context.Turebis.Where(u => u.id == id).FirstOrDefault();
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var new_enty = new UserAndTurebiMap { Turebi_Id = id, User_Id = userid };
                if (_context.UserAndTurebi.Where(u => u.User_Id == userid)
                                      .Select(u => u.turebi)
                                       .Any(u => u.id == id))
                {
                    TempData["Error"] = "ტური უკვე არი დამატებული კალათაში";

                }
                else
                {
                    _context.UserAndTurebi.Add(new_enty);
                    _context.SaveChanges();
                    TempData["Success"] = "ტური წარმატებით დაემატა კალათაში";
                }
            }
            else
            {
                TempData["Failed"] = "გთხოვთ დარეგისტრილდით,რათა დაამატოთ კალათაში";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult AmoshlaKalatidan(int id)
        {
            var get_tur = _context.Turebis.Where(u => u.id == id).Select(u => u.id).FirstOrDefault();
            var user_Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var kide_get = _context.UserAndTurebi.Where(u => u.User_Id == user_Id && u.Turebi_Id == u.Turebi_Id).FirstOrDefault();
            if (kide_get == null)
            {
                TempData["SomeKindOfError"] = "რაღაცა ერრორია";
                return RedirectToAction("index");

            }
            _context.UserAndTurebi.Remove(kide_get);
            _context.SaveChanges();
            TempData["sec"] = "turi warmatebit amoishala biwoo";
            return Redirect(Request.Headers["Referer"].ToString());

        }
        public IActionResult FasiZrda()
        {

            HttpContext.Session.SetString("Sortin", "FasiZrda");
            return RedirectToAction("Yvela");
        }
        public IActionResult FasiKlebadoba()
        {
            HttpContext.Session.SetString("Sortin", "FasiKlebadoba");
            return RedirectToAction("Yvela");
        }
        public IActionResult SaxeliZrda()
        {
            HttpContext.Session.SetString("Sortin", "SaxeliZrda");

            return RedirectToAction("Yvela");
        }
        public IActionResult SaxeliKlebadoba()
        {
            HttpContext.Session.SetString("Sortin", "SaxeliKlebadoba");
            return RedirectToAction("Yvela");
        }
        public IActionResult Yvela_Kompania()
        {
            var comapniebi = _context.Companies.ToList();
            return View(comapniebi);
        }
        public IActionResult Get_Kompania(int id)
        {

            var get_company = _context.Companies.FirstOrDefault(u => u.Company_Id == id);
            var turebi_kompaniebis = _context.Turebis.Where(u => u.Company_Id == id).ToList();
            ViewBag.Yvela_tur = turebi_kompaniebis;
            return View(get_company);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactPerson person)
        {
            if (_context.ContactiUndat.Any(x => x.First_Name == person.First_Name && x.Last_Name == person.Last_Name && x.Telephoni == person.Telephoni))
            {
                TempData["Warning"] = "ukve gagzavnili gaqvt tqveni sakontaqto infromacia";
                return Redirect(Request.Headers["Referer"].ToString());
            };
            if (ModelState.IsValid)
            {
                _context.Add(person);
                _context.SaveChanges();
                TempData["Successfull"] = "warmatebit gaigzavna tqveni kontaqti";
            }
            return View();
        }
        public IActionResult Sastumroebi(string? sax,int page_id = 1)
        {
            if(sax is not null)
            {
                HttpContext.Session.Remove("lokaciebi");
            }
            var sastumroebi = _context.Sastumroebis.ToList();
            var type = typeof(TvisebebiSastumroebis);
            var tito_size = 5;
            var skiP = _context.Sastumroebis.ToList();
            var sastumroebis_tvisebebi = type.GetProperties().Select(p => p.Name).ToList();
            ViewBag.tvisebebi = sastumroebis_tvisebebi;
            var current_page = page_id;
            ViewBag.current_page = current_page;
            var lokaciebi = _context.Sastumroebis.Select(x => x.Lokacia).Distinct().ToList();
            ViewBag.lokaciebi = lokaciebi;
            var saxelebi = _context.Sastumroebis.Select(p => p.Name).Distinct().ToList();
            ViewBag.saxelebi = saxelebi;
            var get_http_ses = HttpContext.Session.GetString("SortinCompania");
            var tvisebebi_row = new TvisebebiSastumroebis();
            switch (get_http_ses)
            {
                case "FasiZrdaCompania":
                    if(HttpContext.Session.GetString("lokaciebi") is not null)
                    {
                        skiP = JsonConvert.DeserializeObject<List<Sastumroebi>>(HttpContext.Session.GetString("lokaciebi")).OrderBy(u=>u.Fasi).ToList();
                    }
                    else
                    {
                    skiP = skiP.OrderBy(u => u.Fasi).ToList();
                    }
                    break;
                case "FasiKlebadobaCompania":
                    skiP = skiP.OrderByDescending(u => u.Fasi).ToList();
                    break;
                case "SaxeliZrdaCompania":
                    skiP = skiP.OrderBy(u => u.Name).ToList();
                    break;
                case "SaxeliKlebadobaKompania":
                    skiP = skiP.OrderByDescending(u => u.Name).ToList();
                    break;
                default:
                    break;
            }
            var size = skiP.Count();
            var ramdeni_gverdi = Math.Ceiling(size / (double)tito_size);
            ViewBag.ramdeni_gverdi = ramdeni_gverdi;
            skiP = skiP.Skip((page_id - 1) * tito_size).Take(tito_size).ToList();
            return View(skiP);
        }
        public IActionResult GetSastumro(int id)
        {
            var sastumro = _context.Sastumroebis.FirstOrDefault(x => x.Id == id);
            var tvisebebi = _context.TvisebebiDaSastumroebi.FirstOrDefault(x => x.Tviseba_Id ==sastumro.Tviseba_Id);
            var tvisebebis_saxeli = new TvisebebiSastumroebis();
            var tvisebasaxeli = tvisebebis_saxeli.GetType().GetProperties().Select(x => x.Name).ToList();
            ViewBag.tvisebebi = tvisebebi;
            ViewBag.tvisebasaxeli= tvisebasaxeli;
            ViewBag.Yvelasastumro = _context.Sastumroebis.Where(x => x.Id != id).ToList();
            return View(sastumro);
        }
        public IActionResult FasiZrdaCompania()
        {
            HttpContext.Session.SetString("SortinCompania", "FasiZrdaCompania");
            return RedirectToAction("Sastumroebi");
        }
        public IActionResult FasiKlebadobaCompania()
        {
            HttpContext.Session.SetString("SortinCompania", "FasiKlebadobaCompania");
            return RedirectToAction("Sastumroebi");
        }
        public IActionResult SaxeliZrdaCompania()
        {
            HttpContext.Session.SetString("SortinCompania", "SaxeliZrdaCompania");
            return RedirectToAction("Sastumroebi");
        }
        public IActionResult SaxeliKlebadobaKompania()
        {
            HttpContext.Session.SetString("SortinCompania", "SaxeliKlebadobaKompania");
            return RedirectToAction("Sastumroebi");
        }
        public IActionResult Fav_Sastumroebi(int id)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var get_sastumro = _context.Sastumroebis.FirstOrDefault(x => x.Id == id);
                var get_new_user = new UserAndSastumroebi() { Sastumorebi_Id = id, User_Id = userid };
                var get_if_exist = _context.userAndSastumroebis.Where(u => u.User_Id == userid && u.Sastumorebi_Id == id).FirstOrDefault();
                if (get_if_exist != null)
                {
                    TempData["Sastumroexists"] = "Sastumro kalatashia ukve batono simn";
                }
                else
                {
                    _context.userAndSastumroebis.Add(get_new_user);
                    _context.SaveChanges();
                    TempData["SastumroSuc"] = "Sastumro warmatebit daemata kalatashi";
                    return Redirect(Request.Headers["Referer"].ToString());

                }
                return Redirect(Request.Headers["Referer"].ToString());

            }
            TempData["NotRegirted"] = "Damatebistvis sawiroa rom daregistridet";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Kalatidan_Washla(int id)
        {
            var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var get_sastumro = _context.userAndSastumroebis.Where(u => u.User_Id == user_id
                                                    && u.Sastumorebi_Id == id).FirstOrDefault();
            if (get_sastumro != null)
            {
                _context.userAndSastumroebis.Remove(get_sastumro);
                _context.SaveChanges();
                TempData["SastumroWaishala"] = "სასტუმრო წარმატებით წაიშალა";
                return Redirect(Request.Headers["Referer"].ToString());
            }
            TempData["SastumroWashlaError"] = "რაღაც ერორია";
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult SastumroebiFilteri(string names, string lokacia, string sasumtrosaxeli, List<string> archeuli, int page_id = 1)
        {
            var saxelebi = _context.Sastumroebis.Select(p => p.Name).Distinct().ToList();
            ViewBag.saxelebi = saxelebi;
            var type = typeof(TvisebebiSastumroebis);
            var sastumroebis_tvisebebi = type.GetProperties().Select(p => p.Name).ToList();
            ViewBag.tvisebebi = sastumroebis_tvisebebi;
            var current_page = page_id;
            ViewBag.current_page = current_page;
            var sastumroebi_lsit = _context.Sastumroebis.ToList();
            //filtri tvisebebi unda gadmoces im saitidan da aq gaiflitros imedia aq rac xdeba ra damaviwydeba
            var tipi = new TvisebebiSastumroebis();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var tipebi = tipi.GetType().GetProperties().Select(x => x.Name).ToList();
            //user picked so the user picks from site checks then go to server then hashing that thing to yes
            Dictionary<string, string> userPick = new Dictionary<string, string>();
            foreach (var i in archeuli)
            {
                if (!userPick.ContainsKey(i))
                {
                userPick.Add(i, "YES");

                }
            } //aqamde
            var saziebeli = _context.TvisebebiDaSastumroebi.ToList();
            List<Dictionary<string, string>> pas = new List<Dictionary<string, string>>();
            foreach (var i in saziebeli)
            {
                var hlep = new Dictionary<string, string>();

                foreach (var propertyName in tipebi)
                {
                    var propertyInfo = i.GetType().GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        var value = propertyInfo.GetValue(i)?.ToString() ?? string.Empty;
                        hlep.Add(propertyName, value);
                    }
                }
                pas.Add(hlep);
            }
            var filteredResults = pas.Where(dict =>
            userPick.All(userEntry =>
            dict.TryGetValue(userEntry.Key, out var value) && value == userEntry.Value)).ToList();
            var pasuxisaboloo = new List<Sastumroebi>();
            foreach (var i in filteredResults)
            {
                if (i.TryGetValue("Tviseba_Id", out var value))
                {
                    var matchingSastumroebi = sastumroebi_lsit.Where(x => x.Tviseba_Id.ToString() == value);
                    pasuxisaboloo.AddRange(matchingSastumroebi);
                }
            }
            //if (names.IsNullOrEmpty())
            //{
            //    return View("Sastumroebi", new List<Sastumroebi>());

            //}
            var lokaciebi = _context.Sastumroebis.Select(x => x.Lokacia).Distinct().ToList();
            ViewBag.lokaciebi = lokaciebi;
            var tito_size_sab = 5;
            if (archeuli.Count > 0)
            {
                if (lokacia == null && sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.bolonames = names;
                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x=>x.Description.ToLower().Contains(names.ToLower()) || 
                    x.Name.ToLower().Contains(names.ToLower())).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia == null && sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty()
                )

            {
                    HttpContext.Session.SetString("lokaciebi", JsonConvert.SerializeObject(pasuxisaboloo, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        NullValueHandling = NullValueHandling.Ignore
                    }));
                    HttpContext.Session.SetString("archeuli",JsonConvert.SerializeObject(archeuli));
                    ViewBag.archeulilist = archeuli;
                 var sizesab = pasuxisaboloo.Count();
                var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                var skap = pasuxisaboloo.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                return View("Sastumroebi", skap);
            }
                if (lokacia != null && sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.bolonames = names;
                    ViewBag.bolo_archeuli = lokacia;
                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x => x.Lokacia == lokacia &&(x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower()) )).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia != null && sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.bolo_archeuli = lokacia;
                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x => x.Lokacia == lokacia).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia == null && !sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    ViewBag.bolonames = names;
                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x => x.Name == sasumtrosaxeli && (x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower()))).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia==null && !sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
                 {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;

                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x => x.Name== sasumtrosaxeli).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                } 
               
                if (lokacia != null && !sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    ViewBag.bolo_archeuli = lokacia;
                    var sizesab = pasuxisaboloo.Count();
                var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                var skap = pasuxisaboloo.Where(x => x.Lokacia == lokacia &&
                x.Name==sasumtrosaxeli).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                return View("Sastumroebi", skap);
                }
                if (lokacia != null && !sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.archeulilist = archeuli;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    ViewBag.bolonames = names;
                    ViewBag.bolo_archeuli = lokacia;

                    var sizesab = pasuxisaboloo.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = pasuxisaboloo.Where(x => x.Lokacia == lokacia &&
                    x.Name == sasumtrosaxeli && (x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower()))).Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                else
                {
                    return View("Sastumroebi", new List<Sastumroebi>());
                }
            }
            else
            {
                if (!names.IsNullOrEmpty() && sasumtrosaxeli.IsNullOrEmpty() && lokacia.IsNullOrEmpty())
                {
                    ViewBag.bolonames = names;
                    var quer = sastumroebi_lsit.Where(x => x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower()));
                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia.IsNullOrEmpty() && sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
                {
                   
                    var sizesab = sastumroebi_lsit.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = sastumroebi_lsit.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (!sasumtrosaxeli.IsNullOrEmpty() && !lokacia.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.bolo_archeuli = lokacia;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    ViewBag.bolonames = names;
                    var quer = sastumroebi_lsit.Where(x => x.Name == sasumtrosaxeli && x.Lokacia == lokacia && (x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower())));
                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (!sasumtrosaxeli.IsNullOrEmpty() && 
                    !lokacia.IsNullOrEmpty() &&names.IsNullOrEmpty())
                {
                    ViewBag.bolo_archeuli = lokacia;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    var quer = sastumroebi_lsit.Where(x => x.Name == sasumtrosaxeli && x.Lokacia == lokacia);
                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer
                        .Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (!lokacia.IsNullOrEmpty() && 
                    sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.bolo_archeuli = lokacia;
                    ViewBag.bolonames = names;
                    var quer = sastumroebi_lsit
                        .Where(x => x.Lokacia == lokacia && (x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower())));

                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (!lokacia.IsNullOrEmpty() && sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
            {
                    ViewBag.bolo_archeuli = lokacia;
                    var quer = sastumroebi_lsit
                        .Where(x => x.Lokacia == lokacia);
                    var sizesab =quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer
                        .Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia.IsNullOrEmpty() && !sasumtrosaxeli.IsNullOrEmpty() && !names.IsNullOrEmpty())
                {
                    ViewBag.bolonames = names;
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    var quer = sastumroebi_lsit.Where(x => x.Name == sasumtrosaxeli && (x.Description.ToLower().Contains(names.ToLower()) || x.Name.ToLower().Contains(names.ToLower())));
                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer
                        .Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
                if (lokacia.IsNullOrEmpty() && !sasumtrosaxeli.IsNullOrEmpty() && names.IsNullOrEmpty())
                {
                    ViewBag.boloarcheulisastumrosaxeli = sasumtrosaxeli;
                    var quer = sastumroebi_lsit.Where(x => x.Name == sasumtrosaxeli);
                    var sizesab = quer.Count();
                    var ramdeni_gverdi1 = Math.Ceiling(sizesab / (double)tito_size_sab);
                    ViewBag.ramdeni_gverdi = ramdeni_gverdi1;
                    var skap = quer
                        .Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
                    return View("Sastumroebi", skap);
                }
            }   
            var sizesaba = sastumroebi_lsit.Count();
            var ramdeni_gverdi2 = Math.Ceiling(sizesaba / (double)tito_size_sab);
            ViewBag.ramdeni_gverdi = ramdeni_gverdi2;
            var skape = sastumroebi_lsit.Skip((page_id - 1) * tito_size_sab).Take(tito_size_sab).ToList();
            return View("Sastumroebi", skape);
        }
       
    }
}
