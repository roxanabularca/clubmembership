using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clubmembership.Controllers
{
    public class CodeSnippetController : Controller
    {
        private CodeSnippetRepository _codesnippetRepository;
        private MemberRepository _memberRepository;

        public CodeSnippetController(ApplicationDbContext dbcontext)
        {
            _memberRepository = new MemberRepository(dbcontext);

            _codesnippetRepository = new CodeSnippetRepository(dbcontext);
        }
        // GET: CodeSnippetController
        public ActionResult Index()
        {
            var list = _codesnippetRepository.GetAllCodeSnippets();
            return View(list);
        }

        // GET: CodeSnippetController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _codesnippetRepository.GetCodeSnippetById(id);
            return View("DetailsCodeSnippet", model);
        }

        // GET: CodeSnippetController/Create
        public ActionResult Create()
        {
            var members = _memberRepository.GetAllMembers();
            var memberList = members.Select(x=> new SelectListItem(x.Name,x.IdMember.ToString()));
            var model = new CodeSnippetModel();
            model.IdSnippetPreviousVersion = _codesnippetRepository.GetLatestCodeSnippet().IdCodeSnippet;
            ViewBag.MemberList = memberList;
            //ViewBag.lastcodesnippetversion = _codesnippetRepository.GetLatestCodeSnippet().IdCodeSnippet.ToString();
            return View("CreateCodeSnippet",model);
        }

        // POST: CodeSnippetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new CodeSnippetModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    if (model.IdCodeSnippet == Guid.Empty)
                    {
                        _codesnippetRepository.InsertCodeSnippet(model);
                    }
                    else
                    {
                        _codesnippetRepository.UpdateCodeSnippet(model);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception error)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CodeSnippetController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _codesnippetRepository.GetCodeSnippetById(id);
            
            return View("EditCodeSnippet",model);
        }

        // POST: CodeSnippetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CodeSnippetModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _codesnippetRepository.UpdateCodeSnippet(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CodeSnippetController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _codesnippetRepository.GetCodeSnippetById(id);

            return View("DeleteCodeSnippet",model);
        }

        // POST: CodeSnippetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _codesnippetRepository.DeleteCodeSnippet(id); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Delete",id);
            }
        }
    }
}
