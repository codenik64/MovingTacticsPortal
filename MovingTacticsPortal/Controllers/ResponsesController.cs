using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovingTacticsPortal.Controllers
{
    public class ResponsesController : Controller
    {
        

        public ActionResult Index()
        {
            List<ResponseViewModel> ListModel = new List<ResponseViewModel>();
            using (MovingTacticsEntities dbContext = new MovingTacticsEntities())
            {
                var query = (from survey in dbContext.Survey
                             join surveyQuestion in dbContext.SurveyQuestions
                             on survey.SurveyId equals surveyQuestion.SurveyId
                             join response in dbContext.Responses
                             on surveyQuestion.QuestionId equals response.QuestionId
                             join member in dbContext.Members
                             on response.MemberId equals member.MemberId
                             select new
                             {
                                 survey.SurveyTitle,
                                 surveyQuestion.QuestionBody,
                                 response.ResponseValue,
                                 response.Comment,
                                 member.MemberName
                             }).ToList();

                foreach (var item in query)
                {
                    ResponseViewModel model = new ResponseViewModel
                    {
                        Question = item.QuestionBody,
                        ResponseValue = item.ResponseValue,
                        Comment = item.Comment,
                        Survey = item.SurveyTitle,
                        Member = item.MemberName
                       
                    };
                    ListModel.Add(model);
                }
                return View(ListModel);
            }
           
        }
    }
}