using MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_UnitOfWork;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.DataAccess.EntityFramework;
using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovingTacticsPortal.Controllers
{
    public class MembersController : Controller
    {
        readonly IUnitOfWork unitOfWork = new UnitOfWork(new MovingTacticsEntities());
        public ActionResult Index()
        {
            var moduleList = unitOfWork.Members.GetAll();
            return View(moduleList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Members Member)
        {
            IdentityStoreManager.AddIdentityUser(Member.EmailAddress, "Passw0rd123*");
            unitOfWork.Members.Add(Member);
            unitOfWork.SaveChanges();
            return View();
        }
    }
}