using MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Business.MasterEngine.Interfaces.IMasterEngineWorks
{
    public interface ISurveyCategoryRepositoryEngine : IGenericRepository<SurveyCategory>
    {
        IEnumerable<SurveyCategory> GetAllCategories();
        void AddCategory(SurveyCategory surveyCategory);
    }
}
