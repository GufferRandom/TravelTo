using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics;
using TravelTo.Data;
using TravelTo.Dto;
using TravelTo.Models;

namespace TravelTo.Controllers
{
    public class HomeController : Controller
    {
        private readonly TurebiDataContext _context1;
        private readonly ApplicationDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(TurebiDataContext context1
            , ApplicationDataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context1 = context1;
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var turebi = _context.Turebi.ToList();
            
            var getting_turebi2=_context1.turebi2s.ToList();
            ViewBag.turebi2 = getting_turebi2;

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
        public IActionResult Turi()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Turi(Turebi2Dto turebi2)
        {
            if (turebi2.Image == null)
            {
                ModelState.AddModelError("Image", "Image is Requered");

            }
            if (ModelState.IsValid)
            {
                string rootpath = webHostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(turebi2.Image.FileName);
                string productfile = Path.Combine(rootpath, "turebi2");
                if (!Directory.Exists(productfile))
                {
                    Directory.CreateDirectory(productfile);
                }
                using (var file = new FileStream(Path.Combine(productfile, filename), FileMode.Create))
                {
                    turebi2.Image.CopyTo(file);

                }
                var Turi = new Turebi2()
                {
                    Name = turebi2.Name,
                    Price = turebi2.Price,
                    Description = turebi2.Description,
                    Image_name = filename

                };
                _context1.Add(Turi);
                _context1.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
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
            var get_turi = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
            return View(get_turi);
        }
        [HttpGet, DisplayName("Edit")]
        public IActionResult Edit(int id)
        {

            var get_turi2 = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
            ViewData["img_name"] = get_turi2.image_name;
            var get_turi_dto = new TurebiDto() { Name = get_turi2.Name, Description = get_turi2.Description, Price = get_turi2.Price };

            return View(get_turi_dto);
        }
        [HttpPost]
        public IActionResult Edit(int id, TurebiDto turebi)
        {
            var get_turi = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
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

    }
}

