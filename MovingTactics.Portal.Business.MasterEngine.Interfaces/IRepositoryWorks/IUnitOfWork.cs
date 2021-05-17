using MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepositoryEngine Members { get; }
        ISurveyCategoryRepositoryEngine SurveyTypes { get; }
        ISurveyRepositoryEngine Survey { get; }
        ISurveyQuestionRepositoryEngine SurveyQuestions { get; }
        ISurveyOptionTypeRepositoryEngine SurveyOptionsType { get;}
        ISurveyOptionsRepositoryEngine SurveyOptions{ get; }
        ISurveyFeedbackRepositoryEngine SurveyFeedback { get;}

        int SaveChanges();

    }
}
