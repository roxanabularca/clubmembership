﻿using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
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
            return View();
        }

        // GET: AnnouncementController/Details/5
        public ActionResult Details(int id)
        {
            return View("CreateAnnouncement");
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
                    _announcementRepository.InsertAnnouncement(model);
                }
                return View("CreateAnnouncement");
            }
            catch (Exception error)
            {
                return View("CreateAnnouncement");
            }
        }

        // GET: AnnouncementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnnouncementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
