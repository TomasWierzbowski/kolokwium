using kolokwium.Models;
using System.Collections.Generic;

namespace kolokwium.DTO
{
    public class SomeSortOfTeam
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}
