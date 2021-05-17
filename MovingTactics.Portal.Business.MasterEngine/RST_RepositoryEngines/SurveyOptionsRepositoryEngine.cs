using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_GenericRepository;
using MovingTactics.Portal.Customs.Helpers;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines
{
    public class SurveyOptionsRepositoryEngine : GenericRepository<SurveyOptions>, ISurveyOptionsRepositoryEngine
    {
        public SurveyOptionsRepositoryEngine(MovingTacticsEntities dbContext):base(dbContext)
        {

        }

        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public void AddSurveyOption(SurveyOptions surveyOptions)
        {
            SurveyOptions options = new SurveyOptions
            {
                OptionType = surveyOptions.OptionType,
                Title = surveyOptions.Title,
                MemberId = GlobalMTHelper.GetMemberId(),
                SurveyId = surveyOptions.SurveyId
            };
            Add(options);
        }
    }
}
