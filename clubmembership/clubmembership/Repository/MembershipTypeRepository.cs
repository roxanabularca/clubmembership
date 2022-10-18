using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class MembershipTypeRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public MembershipTypeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public MembershipTypeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private MembershipTypeModel MapDBObjectToModel(MembershipType dbobject)
        {
            var model = new MembershipTypeModel();
            if (dbobject != null)
            {
                model.IdMembershipType = dbobject.IdMembershipType;
                model.Name = dbobject.Name;
                model.Description = dbobject.Description;
                model.SubscriptionLenghtInMonths = dbobject.SubscriptionLenghtInMonths;
               
            }
            return model;
        }
        private MembershipType MapModelToDBObject(MembershipTypeModel model)
        {
            var dbobject = new MembershipType();
            if (model != null)
            {
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLenghtInMonths = model.SubscriptionLenghtInMonths;
            }
            return dbobject;
        }
        public List<MembershipTypeModel> GetAllMembershipType()
        {
            var list = new List<MembershipTypeModel>();
            foreach (var dbobject in _DBContext.MembershipTypes)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public MembershipTypeModel GetMembershipTypeById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id));
        }
        public void InsertMembershipType(MembershipTypeModel model)
        {
            model.IdMembershipType = Guid.NewGuid();
            _DBContext.MembershipTypes.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }
        public void UpdateMembershipType(MembershipTypeModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == model.IdMembershipType);
            if (dbobject != null)
            {
                dbobject.IdMembershipType = model.IdMembershipType;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.SubscriptionLenghtInMonths = model.SubscriptionLenghtInMonths;
                _DBContext.SaveChanges();
            }
        }
        public void DeleteMembershipType(MembershipTypeModel model)
        {
            var dbobject = _DBContext.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == model.IdMembershipType);
            if (dbobject != null)
            {
                _DBContext.MembershipTypes.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }


    }
}
