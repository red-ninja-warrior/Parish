using System;
using System.Collections.Generic;

namespace Parish.Data.Entities
{
    public partial class Member
    {
        public Member()
        {
            Family = new HashSet<Family>();
            FamilyMember = new HashSet<FamilyMember>();
        }

        public long MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Family> Family { get; set; }
        public ICollection<FamilyMember> FamilyMember { get; set; }
    }
}
