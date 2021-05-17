using MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_UnitOfWork;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovingTacticsPortal.Controllers
{
    public class SurveyCategoryController : Controller
    {
        readonly IUnitOfWork unitOfWork = new UnitOfWork(new MovingTacticsEntities());
        // GET: SurveyCategories
        public ActionResult Index()
        {
            return View(unitOfWork.SurveyTypes.GetAllCategories());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyCategory surveyCategory)
        {
            unitOfWork.SurveyTypes.AddCategory(surveyCategory);
            unitOfWork.SaveChanges();
            return RedirectToAction("index");
        }
    }
}