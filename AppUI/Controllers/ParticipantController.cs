
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppUI.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly Context _context;

        public ParticipantController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> EventList()
        {
            var events = await _context.eventDetails.ToListAsync();
            return View(events);
        }
        public async Task<IActionResult> EventSessions(int eventId)
        {
            var sessions = await _context.sessionInfos
                .Where(s => s.EventId == eventId)
                .ToListAsync();

            ViewBag.EventId = eventId;
            return View(sessions);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEvent(int eventId, int sessionId)
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }
            var alreadyRegistered = await _context.participantEventDetails
                           .AnyAsync(x => x.EmailId == email
                                       && x.EventId == eventId
                                       && x.SessionId == sessionId);

            if (alreadyRegistered)
            {
                TempData["Message"] = "You already registered for this session.";
                return RedirectToAction("Dashboard");
            }
            ParticipantEventDetails registration = new ParticipantEventDetails
            {
                EmailId = email,
                UserEmailId = email,
                EventId = eventId,
                SessionId = sessionId,
                IsAttended = false
            };

            _context.participantEventDetails.Add(registration);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Registration successful.";
            return RedirectToAction("Dashboard");
        }
        public async Task<IActionResult> Dashboard()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login", "Account");
            }

            var myRegistrations = await _context.participantEventDetails
                .Where(p => p.EmailId == email)
                .Join(_context.eventDetails,
                    p => p.EventId,
                    e => e.EventId,
                    (p, e) => new { p, e })
                .Join(_context.sessionInfos,
                    pe => pe.p.SessionId,
                    s => s.SessionId,
                    (pe, s) => new ParticipantDashboardViewModel
                    {
                        EventName = pe.e.EventName,
                        EventDate = pe.e.EventDate,
                        EventCategory = pe.e.EventCategory,
                        SessionTitle = s.SessionTitle,
                        SessionStart = s.SessionStart,
                        Description = s.Description,
                        IsAttended = pe.p.IsAttended
                    })
                .OrderBy(x => x.EventDate)
                .ThenBy(x => x.SessionStart)
                .ToListAsync();

            return View(myRegistrations);
        }
    }
}


