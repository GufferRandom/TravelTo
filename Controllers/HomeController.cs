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
			var companies = _context.Companies.Select(x=>x.Name).ToList();
			ViewBag.companies = companies;
			return View(get_turi_dto);
		}
		[HttpPost]
		public IActionResult Edit(int id, TurebiDto turebi,string kompania)
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
			var get_compani = _context.Companies.Where(x=>x.Name == kompania).FirstOrDefault();
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
				ViewBag.get_country_name = get_country_name;
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
			ViewBag.yvela_tur = turebi_kompaniebis;
            return View(get_company);
        }
        public IActionResult Contact()
        {
			return View();
		}
		[HttpPost]
		public IActionResult Contact(ContactPerson person)
		{
			if (_context.ContactiUndat.Any(x => x.First_Name == person.First_Name && x.Last_Name==person.Last_Name && x.Telephoni == person.Telephoni)) {
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
		public IActionResult Sastumroebi(int page_id =1)
		{
			var sastumroebi = _context.Sastumroebis.ToList();
			var type = typeof(TvisebebiSastumroebis);
			var tito_size = 5;
			var size = sastumroebi.Count();
         
            var skiP = _context.Sastumroebis.Skip((page_id- 1) * tito_size).Take(tito_size).ToList();

            var sastumroebis_tvisebebi =type.GetProperties().Select(p=>p.Name).ToList();
			ViewBag.tvisebebi=sastumroebis_tvisebebi;
            var ramdeni_gverdi = Math.Ceiling(size / (double)tito_size);
            ViewBag.ramdeni_gverdi = ramdeni_gverdi;
			var current_page = page_id;
			ViewBag.current_page = current_page;
            return View(skiP);
		}
		public IActionResult GetSastumro(int id)
		{
			var sastumro = _context.Sastumroebis.FirstOrDefault(x => x.Id == id);
			ViewBag.yvelasastumro = _context.Sastumroebis.Where(x=>x.Id!=id).ToList();
			
			return View(sastumro);
		}
	}
}

