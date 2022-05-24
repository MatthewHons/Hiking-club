using Microsoft.AspNetCore.Mvc;
using HikingProject.Models;

namespace HikingProject.Controllers
{
    public class HikesController : Controller
    {
        private readonly DefaultContext _context = null;

        public HikesController(DefaultContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {

            var query = from item in _context.Hike select item;

            return View(query.ToList());
        }

    }
}
