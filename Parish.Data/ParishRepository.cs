using Parish.Data.Entities;
using System.Linq;

namespace Parish.Data
{
    public class ParishRepository : IParishRepository
    {
        private readonly DbContext _context;

        public ParishRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<Member> Members => _context.Member;
        public IQueryable<Family> Families => _context.Family;
        public IQueryable<FamilyMember> FamilyMembers => _context.FamilyMember;
        public IQueryable<Contribution> Contributions => _context.Contribution;        
    }
}
