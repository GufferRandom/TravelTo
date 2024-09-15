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
        
        private readonly ApplicationDataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ApplicationDataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var Turebi = _context.Turebi.ToList();
            

            return View(Turebi);
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
        public IActionResult Turi(TurebiDto Turebi)
        {
            if (Turebi.image == null)
            {
                ModelState.AddModelError("Image", "Image is Requered");

            }
            if (ModelState.IsValid)
            {
                string rootpath = webHostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(Turebi.image.FileName);
                string productfile = Path.Combine(rootpath, "turebi");
                if (!Directory.Exists(productfile))
                {
                    Directory.CreateDirectory(productfile);
                }
                using (var file = new FileStream(Path.Combine(productfile, filename), FileMode.Create))
                {
                    Turebi.image.CopyTo(file);

                }
                var Turi = new Turebi()
                {
                    Name = Turebi.Name,
                    Price = Turebi.Price,
                    Description = Turebi.Description,
                    image_name = filename

                };
                _context.Add(Turi);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(TurebiDto Turebi)
        {
            if (Turebi.image == null)
            {
                ModelState.AddModelError("image", "image is requered as hel");
            }

            if (ModelState.IsValid)
            {
                string wwwrootpath = webHostEnvironment.WebRootPath;
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(Turebi.image.FileName);
                string productPath = Path.Combine(wwwrootpath, "Turebi");
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }
                using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    Turebi.image.CopyTo(fileStream);
                }
                var namdvili_turi = new Turebi()
                {
                    Name = Turebi.Name,
                    Description = Turebi.Description,
                    Price = Turebi.Price,
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
        public IActionResult Edit(int id, TurebiDto Turebi)
        {
            var get_turi = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
            string wwwrootpath = webHostEnvironment.WebRootPath;
            if (Turebi.image != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(Turebi.image.FileName);
                string productPath = Path.Combine(wwwrootpath, "Turebi");
                if (!Directory.Exists(productPath))
                {
                    Directory.CreateDirectory(productPath);
                }
                using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                {
                    Turebi.image.CopyTo(fileStream);
                }
                get_turi.image_name = filename;
            };
            get_turi.Name = Turebi.Name;
            get_turi.Price = Turebi.Price;
            get_turi.Description = Turebi.Description;
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

