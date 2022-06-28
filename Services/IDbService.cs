using kolokwium.DTO;
using kolokwium.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfTeam>> GetTeam(int TeamID);
        Task<bool> AddMember(Member member);
    }
}
