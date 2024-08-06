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

        public HomeController(ApplicationDataContext context,IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var turebi = _context.Turebi.ToList();


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
            var get_turi=_context.Turebi.Where(x=>x.id==id).FirstOrDefault();
            return View(get_turi);
        }
        [HttpGet,DisplayName("Edit")]
        public IActionResult Edit(int id) {

            var get_turi2 = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
           ViewData["img_name"] = get_turi2.image_name;
           var get_turi_dto= new TurebiDto() { Name=get_turi2.Name,Description=get_turi2.Description,Price=get_turi2.Price };

            return View(get_turi_dto);
        }
        [HttpPost]
        public IActionResult Edit(int id,TurebiDto turebi) {
            var get_turi = _context.Turebi.Where(x => x.id == id).FirstOrDefault();
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
            get_turi.Name = turebi.Name;
            get_turi.image_name =filename;
            get_turi.Price= turebi.Price;
            get_turi.Description = turebi.Description;
            if(ModelState.IsValid)
            {
                _context.Update(get_turi);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
                return View();

        }

    }
}

