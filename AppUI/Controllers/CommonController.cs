using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using System.Linq;

namespace AppUI.Controllers
{
    public class CommonController : Controller
    {
        private readonly Context _context;
        public CommonController(Context context) 
        { 
            _context = context;
        }
        public IActionResult Home() 
        {
            ViewBag.sessionInfos = _context.sessionInfos.ToList();
            var events = _context.eventDetails.ToList();
            return View(events);
        }



    }
}