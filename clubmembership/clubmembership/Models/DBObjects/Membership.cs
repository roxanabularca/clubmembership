using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class Membership
    {
        public Guid Idmembership { get; set; }
        public Guid Idmember { get; set; }
        public Guid IdmembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Level { get; set; }

        public virtual MembershipType IdmembershipTypeNavigation { get; set; } = null!;
    }
}
