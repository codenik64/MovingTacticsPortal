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
    public class SurveyQuestionsController : Controller
    {

        IUnitOfWork unitOfWork = new UnitOfWork(new MovingTacticsEntities());
        // GET: SurveyQuestions
        public ActionResult Index()
        {
            var modelList = unitOfWork.SurveyQuestions.GetAll();
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyQuestions surveyQuestions)
        {
            unitOfWork.SurveyQuestions.AddQuestion(surveyQuestions);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}