using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clubmembership.Controllers
{
    public class MemberShipController : Controller
    {
        private MembershipRepository _membershipRepository;
        public MemberShipController(ApplicationDbContext dbcontext)
        {
            _membershipRepository= new MembershipRepository(dbcontext);
        }
        // GET: MemberShipController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MemberShipController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberShipController/Create
        public ActionResult Create()
        {
            return View("CreateMmembership");
        }

        // POST: MemberShipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _membershipRepository.InsertMembership(model);
                }

                return View("CreateMmembership");
            }
            catch
            {
                return View("CreateMmembership");
            }
        }

        // GET: MemberShipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberShipController/Edit/5
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

        // GET: MemberShipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberShipController/Delete/5
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
