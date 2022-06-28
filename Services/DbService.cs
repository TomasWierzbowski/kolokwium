using kolokwium.DTO;
using kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public class DbService : IDbService
    {
        private const bool V = true;
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddMember(Member member)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<SomeSortOfTeam>> GetTeam(int TeamID)
        {
            return await _dbContext.Teams
        .Include(e => e.Organizations)
            .ThenInclude(e =>e.Members)
        .Select(e => new SomeSortOfTeam
        {
            TeamName = e.TeamName,
            TeamDescription = e.TeamDescription,
            Members = e.Memberships.Select(e => new Member
            {
                MemberName = e.Member.MemberName,
                MemberSurname = e.Member.MemberSurname,
            }).ToList()
        })
        .Where(e => e.TeamID == TeamID)
        .ToListAsync();
        }

    }
}
