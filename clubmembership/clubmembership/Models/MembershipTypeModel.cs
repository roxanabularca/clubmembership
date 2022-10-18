namespace clubmembership.Models
{
    public class MembershipTypeModel
    {
        public Guid IdMembershipType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SubscriptionLenghtInMonths { get; set; }

    }
}
