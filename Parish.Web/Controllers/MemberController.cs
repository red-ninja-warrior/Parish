using Microsoft.AspNetCore.Mvc;
using Parish.Data;
using Parish.Web.Models;
using System;
using System.Linq;

namespace Parish.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IParishRepository _repo;
        public MemberController(IParishRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Get()
        {
            try
            {
                var members = (from fm in _repo.FamilyMembers
                               join m in _repo.Members on fm.MemberId equals m.MemberId
                               join f in _repo.Families on fm.FamilyId equals f.FamilyId
                               select new FamilyMember
                               {
                                   FamilyMemberId = fm.FamilyMemberId,
                                   FamilyId = f.FamilyId,
                                   FamilyName = f.FamilyName,
                                   MemberId = m.MemberId,
                                   FirstName = m.FirstName,
                                   LastName = m.LastName,
                                   Email = m.Email,
                                   Phone = m.Phone,
                                   IsPrimaryMember = fm.IsPrimary,
                                   IsRegistered = f.IsRegistered
                               }).ToList();

                return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}