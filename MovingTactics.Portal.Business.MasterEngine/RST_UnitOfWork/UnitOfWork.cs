using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_RepositoryEngines;
using MovingTactics.Portal.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.RST_UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovingTacticsEntities _dbContext;

        public UnitOfWork(MovingTacticsEntities dbContext)
        {
            _dbContext = dbContext;
            Members = new MembersRepositoryEngine(_dbContext);
            SurveyTypes = new SurveyCategoryRepositoryEngine(_dbContext);
            Survey = new SurveyRepositoryEngine(_dbContext);
            SurveyQuestions = new SurveyQuestionsRepositoryEngine(_dbContext);
            SurveyOptionsType = new SurveyOptionTypeRepositoryEngine(_dbContext);
            SurveyOptions = new SurveyOptionsRepositoryEngine(_dbContext);
            SurveyFeedback = new SurveyFeedbackRepositoryEngine(_dbContext);
        }

        public IMemberRepositoryEngine Members { get; private set; }
        public ISurveyCategoryRepositoryEngine SurveyTypes { get; private set; }
        public ISurveyRepositoryEngine Survey { get; private set; }
        public ISurveyQuestionRepositoryEngine SurveyQuestions { get; private set; }
        public ISurveyOptionTypeRepositoryEngine SurveyOptionsType { get; private set; }
        public ISurveyOptionsRepositoryEngine SurveyOptions { get; private set; }
        public ISurveyFeedbackRepositoryEngine SurveyFeedback { get; private set; }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
