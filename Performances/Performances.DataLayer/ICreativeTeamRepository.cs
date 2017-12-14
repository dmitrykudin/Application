using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performances.Model;

namespace Performances.DataLayer
{
    public interface ICreativeTeamRepository
    {
        CreativeTeam AddCreativeTeam(CreativeTeam creativeTeam);
        void DeleteCreativeTeam(CreativeTeam creativeTeam);
        void DeleteCreativeTeam(int creativeTeamId);
        CreativeTeam UpdateCreativeTeam(CreativeTeam oldCreativeTeam, CreativeTeam newCreativeTeam);
        CreativeTeam GetCreativeTeamById(int creativeTeamId);
    }
}
