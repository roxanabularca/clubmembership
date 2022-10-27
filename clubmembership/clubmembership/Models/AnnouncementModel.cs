using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class AnnouncementModel
    {
        public Guid IdAnnouncement { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidForm { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidTo { get; set; }

        [StringLength(250,ErrorMessage = "Maxim 250 caractere")]
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}
