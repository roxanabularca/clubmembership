using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class MembershipModel
    {
        public Guid Idmembership { get; set; }
        public Guid Idmember { get; set; }
        public Guid IdmembershipType { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string? EndDate { get; set; }
        public int Level { get; set; }
    }
}
