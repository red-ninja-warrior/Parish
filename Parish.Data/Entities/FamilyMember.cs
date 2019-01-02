namespace Parish.Data.Entities
{
    public partial class FamilyMember
    {
        public long FamilyMemberId { get; set; }
        public long FamilyId { get; set; }
        public long MemberId { get; set; }
        public bool IsPrimary { get; set; }

        public Family Family { get; set; }
        public Member Member { get; set; }
    }
}
