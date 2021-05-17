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
    public class SurveyOptionTypesController : Controller
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MovingTacticsEntities());
        // GET: SurveyOptions
        public ActionResult Index()
        {
            var modelList = unitOfWork.SurveyOptionsType.GetAll();
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SurveyOptionsType surveyOptionsType)
        {
            unitOfWork.SurveyOptionsType.AddOptionType(surveyOptionsType);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}