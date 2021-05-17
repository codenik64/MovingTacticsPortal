using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_GenericRepository;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines
{
    public class MembersRepositoryEngine : GenericRepository<Members>, IMemberRepositoryEngine
    {

        public MembersRepositoryEngine(MovingTacticsEntities dbContext) : base(dbContext)
        {
        }

        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }


        public IEnumerable<Members> GetAllMembersActive()
        {
            return MovingTacticsEntities.Members.Where(x => x.IsActive == true).ToList();
        }

    }
}
