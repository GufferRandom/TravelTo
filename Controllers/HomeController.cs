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
        public IActionResult Add(TurebiDto turebi,string kompania)
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
                int company_id = _context.Companies.Where(u=>u.Name== kompania).
                                                        Select(u=>u.Company_Id).
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
            var yvela_tur = _context.Turebis.ToList();
            yvela_tur.Remove(get_turi);
            ViewBag.yvela_tur = yvela_tur;
            return View(get_turi);
        }
        [HttpGet, DisplayName("Edit")]
        public IActionResult Edit(int id)
        {

            var get_turi2 = _context.Turebis.Where(x => x.id == id).FirstOrDefault();
            ViewData["img_name"] = get_turi2.image_name;
            var get_turi_dto = new TurebiDto() { Name = get_turi2.Name, Description = get_turi2.Description, Price = get_turi2.Price };

            return View(get_turi_dto);
        }
        [HttpPost]
        public IActionResult Edit(int id, TurebiDto turebi)
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

            var tobedeletedTur = _context.Turebis.Where(u => u.id == id).FirstOrDefault();
            string wwwpath = webHostEnvironment.WebRootPath;
            string name = tobedeletedTur.image_name;
            string Full_Image_Url = Path.Combine(wwwpath, "turebi", name);
            System.IO.File.Delete(Full_Image_Url);

            _context.Remove(tobedeletedTur);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Yvela(int page_id)
        {
            int lenght_of_turebi = _context.Turebis.Count();
            int size = 5;
            int ramdeni_gverdi = (int)Math.Ceiling(lenght_of_turebi / 5.0);
            int darchenili = lenght_of_turebi - ramdeni_gverdi;
			var getti_company = _context.Companies.ToList();
			int current_page = page_id;
			ViewBag.current_page = current_page;
			if (page_id == 0) {
                ViewBag.current_page = 1;
            }
			if (page_id == 0)
            {
				ViewBag.company = getti_company;
				ViewBag.ramdeni_gverdi = ramdeni_gverdi;
				ViewBag.current_page = 1;
                var skipee = _context.Turebis.Take(size).ToList();
                return View(skipee);

			}
			var skipe = _context.Turebis.Skip((page_id - 1) * size).Take(size).ToList();
            ViewBag.ramdeni_gverdi = ramdeni_gverdi;
            if (TempData["fasizrda"] != null)
            {
                var gettin_company = _context.Companies.ToList();
                
				if (page_id == 0)
				{
					ViewBag.current_page = 1;

					var skipee = _context.Turebis.Include("Company").OrderBy(x => x.Price).Skip((page_id - 1) * size).Take(size).ToList();
                  ViewBag.company = gettin_company;
					ViewBag.ramdeni_gverdi = ramdeni_gverdi;

					return View(skipee);

				}
                List<Turebi> getting_turs = _context.Turebis.Include("Company").OrderBy(x => x.Price).Skip((page_id - 1) * size).Take(size).ToList();
				int current_page3 = page_id;
				ViewBag.current_page = current_page3;

				ViewBag.company = gettin_company;
                
                return View(getting_turs);
            }
            if (TempData["faziklebadoba"] != null)
            {
				var gettin_company = _context.Companies.ToList();

				if (page_id == 0)
				{
					ViewBag.current_page = 1;
					var skipee = _context.Turebis.Include("Company").OrderByDescending(x => x.Price).Skip((page_id - 1) * size).Take(size).ToList();
					ViewBag.company = gettin_company;
					ViewBag.ramdeni_gverdi = ramdeni_gverdi;

					return View(skipee);

				}

                List<Turebi> getting_turs = _context.Turebis.Include("Company").OrderByDescending(x=>x.Price).ToList();
                ViewBag.company = gettin_company;
                return View(getting_turs);
            }
            if (TempData["Saxelizrda"] != null)
            {
                var gettin_company = _context.Companies.ToList();
				if (page_id == 0)
				{
					ViewBag.current_page = 1;

					var skipee = _context.Turebis.Include("Company").OrderBy(x => x.Name).Take(size).ToList();
					ViewBag.company = gettin_company;
					ViewBag.ramdeni_gverdi = ramdeni_gverdi;

					return View(skipee);

				}
				List<Turebi> getting_turs = _context.Turebis.Include("Company").OrderBy(x => x.Name).ToList();
                ViewBag.company = gettin_company;
                return View(getting_turs);
            }
            if (TempData["Saxeliklebadoba"] != null)
            {
                var gettin_company = _context.Companies.ToList();
				if (page_id == 0)
				{
					ViewBag.current_page = 1;

					var skipee = _context.Turebis.Include("Company").OrderByDescending(x => x.Name).Take(size).ToList();
					ViewBag.company = gettin_company;
					ViewBag.ramdeni_gverdi = ramdeni_gverdi;

					return View(skipee);

				}
				List<Turebi> getting_turs = _context.Turebis.Include("Company").OrderByDescending(x => x.Name).ToList();
                ViewBag.company = gettin_company;
                return View(getting_turs);
            }
            var getting_company = _context.Companies.ToList();
			if (page_id == 0)
			{
				var skipee = _context.Turebis.Include("Company").Take(size).ToList();
				ViewBag.company = getting_company;
				ViewBag.ramdeni_gverdi = ramdeni_gverdi;
				return View(skipee);
			}
			List<Turebi> gettin_turs = _context.Turebis.Include("Company").Skip((page_id - 1) * size).Take(size).ToList();
            ViewBag.company = getting_company;
            return View(gettin_turs);
        }
        public IActionResult Zebna(string names, string selected, string min, string max, string kompania)
        {
            double Max = Convert.ToDouble(max);
            double Min = Convert.ToDouble(min);
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
                var getting_turs1 = _context.Turebis.Where(u => u.Name == selected && u.Price > Min && u.Price < Max).ToList();
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
                var getting_turs1 = _context.Turebis.Where(u => u.Name == names && u.Price > Min && u.Price < Max).ToList();
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

                return RedirectToAction("yvela");
            }
            if (names == null && selected == null && min != null && max != null && kompania == null)
            {
                var getting_turs1 = _context.Turebis.Select(u => u.Name).ToList();
                var get_tur = _context.Turebis.Where(u => u.Price > Min && u.Price < Max).ToList();
                ViewBag.turebi = getting_turs1;
                var get_company_name = _context.Companies.Select(u => u.Name).ToList();
                ViewBag.company = get_company_name;
                var get_country_name = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.get_country_name = get_country_name;

                return View(get_tur);
            }
            if (names == null && selected != null)
            {
                var getting_turs1 = _context.Turebis.Where(u => u.Name == selected).ToList();
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
                var getting_turs1 = _context.Turebis.Where(u => u.Name == names).ToList();
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
                ViewBag.get_country_name= get_country_name;
                ViewBag.company = get_company_name;
                return RedirectToAction("yvela");
            }
            var getting_turs = _context.Turebis.Where(u => u.Name == selected && u.Name == names).ToList();
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

                return View(get_user_favs);
            }
            return View();
        }
        [HttpPost]
        public IActionResult ShoppingCart(int id)
        {
            var refererUrl = Request.Headers["Referer"].ToString();
            Console.WriteLine($"Referer URL: {refererUrl}");
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
            TempData["fasizrda"] = true;
            return RedirectToAction("Yvela");
        }
        public IActionResult FasiKlebadoba()
        {
            TempData["faziklebadoba"] = true;
            return RedirectToAction("Yvela");
        }
        public IActionResult SaxeliZrda()
        {
            TempData["Saxelizrda"] = true;
            return RedirectToAction("Yvela");
        }
        public IActionResult SaxeliKlebadoba() {
            TempData["Saxeliklebadoba"] = true;
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
            ViewBag.yvela_tur = turebi_kompaniebis;
            return View(get_company);
        }


    }
}

