using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_GenericRepository;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines
{
    public class SurveyOptionTypeRepositoryEngine : GenericRepository<SurveyOptionsType>, ISurveyOptionTypeRepositoryEngine
    {
        public SurveyOptionTypeRepositoryEngine(MovingTacticsEntities dbContext):base(dbContext)
        {

        }

        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public void AddOptionType(SurveyOptionsType surveyOption)
        {
            SurveyOptionsType option = new SurveyOptionsType
            {
                SurveyOptionType = surveyOption.SurveyOptionType
            };
            Add(option);
        }
    }
}
