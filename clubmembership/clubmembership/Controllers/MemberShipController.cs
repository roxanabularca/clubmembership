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
            var list = _membershipRepository.GetAllMemberships();
            return View(list);
        }

        // GET: MemberShipController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _membershipRepository.GetMembershipById(id);
            return View("DetailsMemberShip", model);
        }

        // GET: MemberShipController/Create
        public ActionResult Create()
        {
            return View("CreateMembership");
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMmembership");
            }
        }

        // GET: MemberShipController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _membershipRepository.GetMembershipById(id);
            return View("EditMemberShip",model);
        }

        // POST: MemberShipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new MembershipModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _membershipRepository.UpdateMembership(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberShipController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _membershipRepository.GetMembershipById(id);
            return View("DeleteMemberShip",model);
        }

        // POST: MemberShipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _membershipRepository.DeleteMembership(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",id);
            }
        }
    }
}
