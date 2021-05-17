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
    public class SurveyCategoryRepositoryEngine : GenericRepository<SurveyCategory>, ISurveyCategoryRepositoryEngine
    {
        public SurveyCategoryRepositoryEngine(MovingTacticsEntities dbContext) : base(dbContext)
        {

        }
        public MovingTacticsEntities MovingTacticsEntities
        {
            get { return dbContext as MovingTacticsEntities; }
        }

        public IEnumerable<SurveyCategory> GetAllCategories()
        {
            return MovingTacticsEntities.SurveyCategory.ToList();
        }

        public void AddCategory(SurveyCategory surveyCategory)
        {
            SurveyCategory surveyType = new SurveyCategory
            {
                CategoryTitle = surveyCategory.CategoryTitle
            };

            Add(surveyType);
        }
    } 
}
