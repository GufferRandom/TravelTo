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
            return View();
        }

        [HttpPost]
        public IActionResult Add(TurebiDto turebi)
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
                var namdvili_turi = new Turebi()
                {
                    Name = turebi.Name,
                    Description = turebi.Description,
                    Price = turebi.Price,
                    image_name = filename

                };
                _context.Add(namdvili_turi);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult GetTuri(int id)
        {
            var get_turi = _context.Turebis.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Yvela()
        {
            List<Turebi> getting_turs = _context.Turebis.ToList();
            return View(getting_turs);
        }


        public IActionResult Zebna(string names, string selected,string min,string max)
        {
            double Max = Convert.ToDouble(max);
            double Min = Convert.ToDouble(min);
            if (names == null && selected != null && min != null && max != null)
            {
                var getting_turs1 = _context.Turebis.Where(u => u.Name == selected && u.Price > Min && u.Price < Max).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return View(getting_turs1);

            }

            if (selected == null && names != null && min != null && max != null)
            {
                var getting_turs1 = _context.Turebis.Where(u => u.Name == names && u.Price > Min && u.Price < Max).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return View(getting_turs1);
            }
            if (names == null && selected == null && min == null && max == null)
            {
                var getting_turs1 = _context.Turebis.ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return RedirectToAction("yvela");
            }
            if (names == null && selected == null && min != null && max != null)
            {
                var getting_turs1 = _context.Turebis.Select(u => u.Name).ToList();
                var get_tur = _context.Turebis.Where(u => u.Price > Min && u.Price < Max).ToList();
                ViewBag.turebi = getting_turs1;
                return View(get_tur);
            }
            if (names == null && selected != null)
            {
                var getting_turs1 = _context.Turebis.Where(u => u.Name == selected).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return View(getting_turs1);

            }
            if (selected == null && names != null)
            {
                var getting_turs1 = _context.Turebis.Where(u => u.Name == names).ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return View(getting_turs1);
            }
            if (names == null && selected == null)
            {
                var getting_turs1 = _context.Turebis.ToList();
                var getting_full_vals1 = _context.Turebis.Select(u => u.Name).ToList();
                ViewBag.turebi = getting_full_vals1;
                return RedirectToAction("yvela");
            }
            var getting_turs = _context.Turebis.Where(u => u.Name == selected && u.Name == names).ToList();
            var getting_full_vals = _context.Turebis.Select(u => u.Name).ToList();
            ViewBag.turebi = getting_full_vals;
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
            if (_signInManager.IsSignedIn(User))
            {
                var getting = _context.Turebis.Where(u => u.id == id).FirstOrDefault();
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var new_enty = new UserAndTurebiMap { Turebi_Id = id,User_Id=userid };
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
            var get_tur = _context.Turebis.Where(u => u.id == id).Select(u=>u.id).FirstOrDefault();
            var user_Id  = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var kide_get = _context.UserAndTurebi.Where(u => u.User_Id == user_Id && u.Turebi_Id == u.Turebi_Id).FirstOrDefault();
            if(kide_get == null)
            {
                TempData["SomeKindOfError"] = "რაღაცა ერრორია";    
                return RedirectToAction("index");

            }
            _context.UserAndTurebi.Remove(kide_get);
            _context.SaveChanges();
            TempData["sec"] = "turi warmatebit amoishala biwoo";
            return Redirect(Request.Headers["Referer"].ToString());

        }


    }
}

