using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class CodeSnippetRepository
    {
        private readonly ApplicationDbContext _DBContext;
        private MemberRepository _memberRepository;
        public CodeSnippetRepository()
        {
            _memberRepository = new MemberRepository();
            _DBContext = new ApplicationDbContext();
        }
        public CodeSnippetRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private CodeSnippetModel MapDBObjectToModel(CodeSnippet dbobject)
        {
            var model = new CodeSnippetModel();
            if (dbobject != null)
            {
                model.IdCodeSnippet = dbobject.IdCodeSnippet;
                model.Title = dbobject.Title;
                model.ContentCode = dbobject.ContentCode;
                model.IdMember = dbobject.IdMember;
                model.Revision = dbobject.Revision;
                model.IdSnippetPreviousVersion = dbobject.IdSnippetPreviousVersion;
                model.DateTimeAdded = dbobject.DateTimeAdded;
            }
            return model;
        }
        private CodeSnippet MapModelToDBObject(CodeSnippetModel model)
        {
            var dbobject = new CodeSnippet();
            if (model != null)
            {
                dbobject.IdCodeSnippet = model.IdCodeSnippet;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.IdMember = model.IdMember;
                dbobject.Revision = model.Revision;
                dbobject.IdSnippetPreviousVersion = model.IdSnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
            }
            return dbobject;
        }
        public List<CodeSnippetModel> GetAllCodeSnippets()
        {
            var list = new List<CodeSnippetModel>();
            foreach (var dbobject in _DBContext.CodeSnippets)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id));
        }
        public void InsertCodeSnippet(CodeSnippetModel model)
        {
            model.IdCodeSnippet = Guid.NewGuid();
            model.DateTimeAdded = DateTime.Now;
            //var dict = new SortedDictionary<DateTime, Guid>();
            //foreach (var dbOject in _DBContext.CodeSnippets)
            //{
            //    MapDBObjectToModel(dbOject);
            //    dict.Add(dbOject.DateTimeAdded, dbOject.IdCodeSnippet);
            //    model.IdSnippetPreviousVersion = dict.Values.Last();

            //}
            _DBContext.CodeSnippets.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }
        public void UpdateCodeSnippet (CodeSnippetModel model)
        {
            var dbobject = _DBContext.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == model.IdCodeSnippet);
            if (dbobject != null)
            {
                dbobject.IdCodeSnippet = model.IdCodeSnippet;
                dbobject.Title = model.Title;
                dbobject.ContentCode = model.ContentCode;
                dbobject.IdMember = model.IdMember;
                dbobject.Revision = model.Revision;
                dbobject.IdSnippetPreviousVersion = model.IdSnippetPreviousVersion;
                dbobject.DateTimeAdded = model.DateTimeAdded;
                _DBContext.SaveChanges();
            }
        }
        public void DeleteCodeSnippet(Guid id)
        {
            var dbobject = _DBContext.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id);
            if (dbobject != null)
            {
                _DBContext.CodeSnippets.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }

        public CodeSnippetModel GetLatestCodeSnippet()
        {
            //var list = new List<CodeSnippetModel>();
            //foreach (var dbobject in _DBContext.CodeSnippets)
            //{
            //    list.Add(MapDBObjectToModel(dbobject));
            //}

            return MapDBObjectToModel(_DBContext.CodeSnippets.OrderByDescending(x => x.DateTimeAdded).FirstOrDefault());
                                                   
        }

    }
}
