using Microsoft.AspNetCore.Mvc;
using HikingProject.Models;

namespace HikingProject.Controllers
{
    public class HikesController : Controller
    {
        private readonly DefaultContext _context;

        public HikesController(DefaultContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {

            var query = from item in _context.Hike select item;
            return View(query.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Hikes hikes)
        {
            if (ModelState.IsValid)
            {
                _context.Hike?.Add(hikes);
                _context.SaveChanges();

                ViewBag.SuccessMessage = "The hike has been created sucessfully!";
                ModelState.Clear();
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Hikes hikes = null;
            
            hikes = this._context.Hike.First(item => item.ID == id);

            return View(hikes);
        }

        [HttpPost]
        public ActionResult Update(Hikes hikes)
        {
                

                if (ModelState.IsValid)
                {
                    this._context.Hike.Update(hikes);
                    _context.SaveChanges();

                    ViewBag.UpdateSuccessMessage = "The hike has been updated sucessfully!";
                }
                return View();

        }
    }
}
