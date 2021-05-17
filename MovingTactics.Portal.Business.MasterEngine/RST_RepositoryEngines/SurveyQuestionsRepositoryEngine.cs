using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_GenericRepository;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovingTactics.Portal.Customs.Helpers;

namespace MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines
{
    public class SurveyQuestionsRepositoryEngine : GenericRepository<SurveyQuestions>,ISurveyQuestionRepositoryEngine
    {
        public SurveyQuestionsRepositoryEngine(MovingTacticsEntities dbContext):base(dbContext)
        {

        }

        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public void AddQuestion(SurveyQuestions surveyQuestions)
        {
            SurveyQuestions questionModel = new SurveyQuestions
            {
                QuestionBody = surveyQuestions.QuestionBody,
                MemberId = GlobalMTHelper.GetMemberId(),
                SurveyId = surveyQuestions.SurveyId
            };
            Add(questionModel);
        }
    }
}
