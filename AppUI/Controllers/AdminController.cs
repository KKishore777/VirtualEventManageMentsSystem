using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUI.Controllers
{
    public class AdminController : Controller
    {


        private readonly IEventRepository<EventDetails> _eventRepo;
        private readonly ISessionRepository<SessionInfo> _sessionRepo;
        private readonly ISpeakerRepository<SpeakersDetails> _speakerRepo;

        public AdminController(
            IEventRepository<EventDetails> eventRepo,
            ISessionRepository<SessionInfo> sessionRepo,
            ISpeakerRepository<SpeakersDetails> speakerRepo)
        {
            _eventRepo = eventRepo;
            _sessionRepo = sessionRepo;
            _speakerRepo = speakerRepo;
        }

        // Dashboard
        public async Task<IActionResult> Dashboard()
        {
            // 1. Fetch the actual lists from your database via services
            var eventsList = await _eventRepo.GetAll();
            var speakersList = await _speakerRepo.GetAll();

            // 2. Assign the actual .Count() of those lists to ViewBag
            // Using ?.Count() ?? 0 handles cases where the list might be null
            ViewBag.EventCount = eventsList?.Count() ?? 0;
            ViewBag.SpeakerCount = speakersList?.Count() ?? 0;

            return View();
        }

        // ================= EVENT =================

        public async Task<IActionResult> EventList()
        {
            return View(await _eventRepo.GetAll());
        }

        public IActionResult AddEvent() => View();

        [HttpPost]
        public async Task<IActionResult> AddEvent(EventDetails model)
        {
            if (ModelState.IsValid)
            {
                if (model.EventDate <= DateTime.Now)
                {
                    ModelState.AddModelError("", "Event date must be future");
                    return View(model);
                }

                await _eventRepo.Add(model);
                return RedirectToAction("EventList");
            }
            return View(model);
        }



        public async Task<IActionResult> EditEvent(int id)
        {
            return View(await _eventRepo.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(EventDetails model)
        {
            await _eventRepo.Update(model);
            return RedirectToAction("EventList");
        }

        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventRepo.Delete(id);
            return RedirectToAction("EventList");
        }

        // ================= SESSION =================
        // --- SESSIONS WITH CATEGORY ---
        // GET: Admin/AddSession
        // GET: Admin/AddSession

        // 1. GET ALL SESSIONS
        // GET: Admin/SessionList
        public async Task<IActionResult> SessionList()
        {
            // This calls your GetAll() in SessionServices
            
            return View(await _sessionRepo.GetAll());
        }

        // 2. SHOW ADD FORM
        public async Task<IActionResult> AddSession()
        {
            ViewBag.Events = new SelectList(await _eventRepo.GetAll(), "EventId", "EventName");
            ViewBag.Speakers = new SelectList(await _speakerRepo.GetAll(), "SpeakerId", "SpeakerName");
            return View();
        }

        // 3. SAVE NEW SESSION
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSession(SessionInfo session)
        {
            if (ModelState.IsValid)
            {
                await _sessionRepo.Add(session);
                return RedirectToAction("SessionList");
            }

            // If it fails, reload the dropdowns
            ViewBag.Events = new SelectList(await _eventRepo.GetAll(), "EventId", "EventName");
            ViewBag.Speakers = new SelectList(await _speakerRepo.GetAll(), "SpeakerId", "SpeakerName");
            return View(session);
        }

        public async Task<IActionResult> DeleteSession(int id)
        {
            await _sessionRepo.Delete(id);
            return RedirectToAction("SessionList");
        }


        // ================= Speaker =================
        public async Task<IActionResult> SpeakerList()
        {
            var speakers = await _speakerRepo.GetAll();
            return View(speakers);
        }

        // Show Add Speaker Form
        public IActionResult AddSpeaker()
        {
            return View();
        }

        // Process Add Speaker
        [HttpPost]
        public async Task<IActionResult> AddSpeaker(SpeakersDetails model)
        {
            if (ModelState.IsValid)
            {
                await _speakerRepo.Add(model);
                return RedirectToAction("SpeakerList");
            }
            return View(model);
        }

        // Delete Speaker
        public async Task<IActionResult> DeleteSpeaker(int id)
        {
            await _speakerRepo.Delete(id);
            return RedirectToAction("SpeakerList");
        }
    }
}


