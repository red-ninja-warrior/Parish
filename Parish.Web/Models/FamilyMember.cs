namespace Parish.Web.Models
{
    public class FamilyMember
    {
        public long FamilyMemberId { get; set; }
        public long FamilyId { get; set; }
        public string FamilyName { get; set; }
        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsPrimaryMember { get; set; }
    }
}
