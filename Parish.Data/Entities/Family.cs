using System.Collections.Generic;

namespace Parish.Data.Entities
{
    public partial class Family
    {
        public Family()
        {
            Contribution = new HashSet<Contribution>();
            FamilyMember = new HashSet<FamilyMember>();
        }

        public long FamilyId { get; set; }
        public string FamilyName { get; set; }
        public long MemberId { get; set; }
        public bool IsRegistered { get; set; }

        public Member Member { get; set; }
        public ICollection<Contribution> Contribution { get; set; }
        public ICollection<FamilyMember> FamilyMember { get; set; }
    }
}
