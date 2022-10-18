using clubmembership.Data;
using clubmembership.Models;
using clubmembership.Models.DBObjects;

namespace clubmembership.Repository
{
    public class AnnoucementRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public AnnoucementRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public AnnoucementRepository (ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private AnnouncementModel MapDBObjectToModel(Announcement dbobject)
        { 
            var model = new AnnouncementModel();
            if (dbobject != null)
            {
                model.IdAnnouncement=dbobject.IdAnnouncement;
                model.ValidForm=dbobject.ValidForm;
                model.ValidTo=dbobject.ValidTo;
                model.Title = dbobject.Title;
                model.Text = dbobject.Text;
                model.EventDateTime=dbobject.EventDateTime;
                model.Tags = dbobject.Tags;
            }
            return model;
        }
        private Announcement MapModelToDBObject(AnnouncementModel model)
        { 
            var dbobject = new Announcement();
            if (model != null)
            { 
                dbobject.IdAnnouncement=model.IdAnnouncement;
                dbobject.ValidForm = model.ValidForm;
                dbobject.ValidTo=model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime=model.EventDateTime;
                dbobject.Tags = model.Tags;
            }
            return dbobject;
        }
        public List<AnnouncementModel> GetAllAnnoucement()
        { 
            var list = new List<AnnouncementModel>();
            foreach (var dbobject in _DBContext.Announcements)
            {
                list.Add(MapDBObjectToModel(dbobject));
            }
            return list;
        }
        public AnnouncementModel GetAnnouncementById(Guid id)
        {
            return MapDBObjectToModel(_DBContext.Announcements.FirstOrDefault(x => x.IdAnnouncement == id));
        }
        public void InsertAnnouncement(AnnouncementModel model)
        { 
            model.IdAnnouncement=Guid.NewGuid();
            _DBContext.Announcements.Add(MapModelToDBObject(model));
            _DBContext.SaveChanges();
        }
        public void UpdateAnnoucement(AnnouncementModel model)
        {
            var dbobject = _DBContext.Announcements.FirstOrDefault(x => x.IdAnnouncement == model.IdAnnouncement);
            if (dbobject != null)
            {
                dbobject.IdAnnouncement = model.IdAnnouncement;
                dbobject.ValidForm = model.ValidForm;
                dbobject.ValidTo = model.ValidTo;
                dbobject.Title = model.Title;
                dbobject.Text = model.Text;
                dbobject.EventDateTime = model.EventDateTime;
                dbobject.Tags = model.Tags;
                _DBContext.SaveChanges();
            }
        }
        public void DeleteAnnouncement(AnnouncementModel model)
        {
            var dbobject = _DBContext.Announcements.FirstOrDefault(x => x.IdAnnouncement == model.IdAnnouncement);
            if (dbobject != null)
            {
                _DBContext.Announcements.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }


    }
}
