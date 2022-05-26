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
                _context.Hike.Add(hikes);
                _context.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            Hikes hikes = null;
            
            hikes = _context.Hike.First(item => item.ID == id);

            return View(hikes);
        }

        [HttpPost]
        public ActionResult Update(Hikes hikes)
        {
            
                if (ModelState.IsValid)
                {
                    _context.Hike.Update(hikes);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Hikes hikes = null;

            hikes = _context.Hike.First(item => item.ID == id);
            
            
            return View(hikes);
        }
        [HttpPost]
        public ActionResult Delete(Hikes hikes)
        {
            
                _context.Hike.Remove(hikes);
                _context.SaveChanges();

                return RedirectToAction("Index");
        }
    }
}


