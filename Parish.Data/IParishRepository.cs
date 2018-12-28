using System.Linq;
using Parish.Data.Entities;

namespace Parish.Data
{
    public interface IParishRepository
    {
        IQueryable<Contribution> Contributions { get; }
        IQueryable<Family> Families { get; }
        IQueryable<FamilyMember> FamilyMembers { get; }
        IQueryable<Member> Members { get; }
    }
}