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
    public class SurveyRepositoryEngine : GenericRepository<Survey>,ISurveyRepositoryEngine
    {
        public SurveyRepositoryEngine(MovingTacticsEntities dbContext):base(dbContext)
        {

        }
        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public void AddSurvey(Survey survey)
        {
            Survey surveyModel = new Survey
            {
                SurveyTitle = survey.SurveyTitle,
                CategoryId = survey.CategoryId
            };
            Add(surveyModel);
        }
    }
}
