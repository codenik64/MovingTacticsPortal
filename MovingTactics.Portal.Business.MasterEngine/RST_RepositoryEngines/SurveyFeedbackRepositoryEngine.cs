using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_GenericRepository;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines
{
    public class SurveyFeedbackRepositoryEngine : GenericRepository<SurveyViewModel>, ISurveyFeedbackRepositoryEngine
    {
        public SurveyFeedbackRepositoryEngine(MovingTacticsEntities dbContext):base(dbContext)
        {

        }

        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public List<SurveyViewModel> SurveyView(int Id)
        {
   
            var query = (from a in MovingTacticsEntities.Survey
                         join b in MovingTacticsEntities.SurveyQuestions
                         on a.SurveyId equals b.SurveyId
                         join c in MovingTacticsEntities.SurveyOptions
                         on a.SurveyId equals c.SurveyId
                         where a.SurveyId == Id
                         select new SurveyViewModel {
                              SurveyQuestions = MovingTacticsEntities.SurveyQuestions.ToList(),
                              SurveyOptions = MovingTacticsEntities.SurveyOptions.ToList()
                         });

            

            return query.ToList();



        }
    }
}
