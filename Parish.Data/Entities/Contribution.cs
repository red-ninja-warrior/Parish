using System;

namespace Parish.Data.Entities
{
    public partial class Contribution
    {
        public long ContributionId { get; set; }
        public long FamilyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Family Family { get; set; }
    }
}
