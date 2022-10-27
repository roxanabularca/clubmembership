using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace clubmembership.Controllers
{
    public class AnnouncementController : Controller
    {
        private AnnoucementRepository _announcementRepository;
        // GET: AnnouncementController

        public AnnouncementController(ApplicationDbContext dbcontext)
        {
            _announcementRepository = new AnnoucementRepository(dbcontext);
        }

        public ActionResult Index()
        {
            var list = _announcementRepository.GetAllAnnoucements();
            return View(list);
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _announcementRepository.GetAnnouncementById(id);
            return View("DetailsAnnouncement", model);
        }

        // GET: AnnouncementController/Create
        public ActionResult Create()
        {
            return View("CreateAnnouncement");
        }

        // POST: AnnouncementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    if (model.IdAnnouncement == Guid.Empty)
                    {
                        _announcementRepository.InsertAnnouncement(model);
                    }
                    else
                    {
                        _announcementRepository.UpdateAnnoucement(model);
                    }
                }
                return View("CreateAnnouncement");// sau RedirectToAction("Index")
            }
            catch (Exception error)
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _announcementRepository.GetAnnouncementById(id);
            return View("EditAnnouncement",model);
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AnnouncementModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                 if (task.Result)
                    {
                        _announcementRepository.UpdateAnnoucement(model);
                    }
                    return RedirectToAction(nameof(Index));// daca punem doar RedirectToAction este un pas in plus pt PC vs return View ("Index")
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: AnnouncementController/Delete/5

        [Authorize(Roles= "User, Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _announcementRepository.GetAnnouncementById(id);

            return View("DeleteAnnouncement",model);
        }

        // POST: AnnouncementController/Delete/5

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _announcementRepository.DeleteAnnouncement(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",id); // folosim View daca nu tr sa dam si id, se foloseste REdirect pt ca avem id
            }
        }
    }
}
