using MovingTactics.Portal.Business.MasterEngine.Interfaces.IRepositoryWorks;
using MovingTactics.Portal.Business.MasterEngine.RST_UnitOfWork;
using MovingTactics.Portal.Customs.Helpers;
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using MovingTactics.Portal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovingTacticsPortal.Controllers
{
    public class SurveyController : Controller
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MovingTacticsEntities());

        public ActionResult Index()
        {
            var modelList = unitOfWork.Survey.GetAll();
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Survey survey)
        {
            unitOfWork.Survey.AddSurvey(survey);
            unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var survey = unitOfWork.Survey.FindById(Id);
            return View(survey);
        }


        public ActionResult SurveyFeedback(int Id, SurveyViewModel model)
        {
            //var surveyModule = unitOfWork.SurveyFeedback.SurveyView(Id);
            using (MovingTacticsEntities db = new MovingTacticsEntities())
            {
                model.SurveyQuestions = db.SurveyQuestions.Where(x => x.SurveyId == Id).ToList();
                model.SurveyOptions = db.SurveyOptions.Where(x => x.SurveyId == Id).ToList();
                model.Survey = db.Survey.FirstOrDefault(x => x.SurveyId == Id);
                return View(model);
            }
        }


        [HttpPost]
        public ActionResult SurveyFeedbackForm(FormCollection formCollection)
        {
            using (MovingTacticsEntities db = new MovingTacticsEntities())
            {
                int ResponseID = 0;
                int SurveyResponseId = 0;
                var x = Request.Form["SurveyId"];//Getting Survey Id from the form hidden field.

                #region Survey Responses
                SurveyResponses surveyResponses = new SurveyResponses
                {
                    SurveyId = Int32.Parse(x.ToString()),
                    MemberId = GlobalMTHelper.GetMemberId(),
                    DateCreated = DateTime.Now.ToLongDateString(),
                    TimeCreated = DateTime.Now.ToLongTimeString(),
                };

                db.SurveyResponses.Add(surveyResponses);
                db.SaveChanges();
                SurveyResponseId = surveyResponses.SurveyResponseId;
                #endregion

                for (int i = 1; i < formCollection.Keys.Count; i++)
                {
                    #region Getting Values for each question in the form collection and taking them one by one
                    var formTest = formCollection.GetValues(i);
                    var formKey = formCollection.GetKey(i);
                    //string value = formCollection[i];
                    //string[] variable = value.Split(',');
                    #endregion

                    #region Check If theres a comment value in Array
                    var option = formTest.Count() > 1 ? formTest[1].ToString() == string.Empty ? null : formTest[1].ToString() : null;
                    #endregion

                    #region Storing the responses for each question
                    Response response = new Response
                    {
                        QuestionId = Convert.ToInt32(formKey),
                        MemberId = GlobalMTHelper.GetMemberId(),
                        SurveyId = Int32.Parse(x.ToString()),
                        ResponseValue = formTest[0].ToString(),
                        Comment = option,
                        YesQuestionCount = 10,
                        DateCreated = DateTime.Now.ToLongDateString(),
                        SurveyResponseId = SurveyResponseId
                    };
                    db.Responses.Add(response);
                    db.SaveChanges();
                    ResponseID = response.ResponseId;
                    #endregion

                    #region Checking File count According to question
                    var FileCount = Request.Files.GetMultiple(formKey).Count();
                    var CheckFiles = Request.Files.GetMultiple(formKey);
                    #endregion

                    #region Media
                    // the count of the files and looping it
                    for (int v = 0; v < FileCount; v++)
                    {
                        //going through each file and checking if its null
                        var file = CheckFiles[v];
                        if (file != null && file.ContentLength > 0)
                        {
                            #region Saving media files for each response question
                            SurveyMedia media = new SurveyMedia
                            {
                                QuestionId = Convert.ToInt32(formKey),
                                MemberId = GlobalMTHelper.GetMemberId(),
                                SurveyId = Int32.Parse(x.ToString()),
                                ResponseId = ResponseID,
                                DateCreated = DateTime.Now.ToLongDateString()

                            };

                            using (var reader = new System.IO.BinaryReader(file.InputStream))
                            {
                                media.MediaContent = reader.ReadBytes(file.ContentLength);
                            }

                            db.SurveyMedias.Add(media);
                            db.SaveChanges();
                            #endregion
                        }
                    }
                    #endregion

                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult SurveyResponses(int Id)
        {
            using (MovingTacticsEntities db = new MovingTacticsEntities())
            {
                List<SurveyResponseViewModel> model = new List<SurveyResponseViewModel>();
                var query = (from survey in db.Survey
                             join surveyResponses in db.SurveyResponses
                             on survey.SurveyId equals surveyResponses.SurveyId
                             join member in db.Members
                             on surveyResponses.MemberId equals member.MemberId
                             where survey.SurveyId == Id
                             select new
                             {
                                 survey.SurveyTitle,
                                 member.MemberName,
                                 surveyResponses.DateCreated,
                                 surveyResponses.TimeCreated,
                                 surveyResponses.SurveyResponseId
                             }).ToList();

                foreach (var item in query)
                {
                    SurveyResponseViewModel responseModel = new SurveyResponseViewModel
                    {
                        SurveyResponseId = item.SurveyResponseId,
                        Survey = item.SurveyTitle,
                        Member = item.MemberName,
                        DateCreated = item.DateCreated,
                        TimeCreated = item.TimeCreated
                    };
                    model.Add(responseModel);
                }
                return View(model);
            }

        }

        public ActionResult ResponseSummary(int Id)
        {
            using (MovingTacticsEntities db = new MovingTacticsEntities())
            {
                List<ResponseSummaryViewModel> responseForm = new List<ResponseSummaryViewModel>();
                var queryForm = (from survey in db.Survey
                             join surveyResponses in db.SurveyResponses
                             on survey.SurveyId equals surveyResponses.SurveyId
                             join member in db.Members
                             on surveyResponses.MemberId equals member.MemberId
                             join response in db.Responses
                             on surveyResponses.SurveyResponseId equals response.SurveyResponseId
                             join question in db.SurveyQuestions
                             on response.QuestionId equals question.QuestionId
                             where surveyResponses.SurveyResponseId == Id
                             select new
                             {
                                 survey.SurveyTitle,
                                 member.MemberName,
                                 surveyResponses.DateCreated,
                                 surveyResponses.TimeCreated,
                                 surveyResponses.SurveyResponseId,
                                 question.QuestionBody,
                                 question.QuestionId,
                                 response.ResponseValue
                                 
                             }).ToList();

                foreach (var query in queryForm)
                {
                    ResponseSummaryViewModel responseSummaryViewModel = new ResponseSummaryViewModel
                    {
                        QuestionId = query.QuestionId,
                        Question = query.QuestionBody,
                        ResponseValue = query.ResponseValue,
                        Member = query.MemberName,
                        Survey = query.SurveyTitle
                    };
                    responseForm.Add(responseSummaryViewModel);
                }

    
                return View(responseForm);
            }

        }

        public ActionResult MediaSummary(int Id)
        {
            using (MovingTacticsEntities db = new MovingTacticsEntities())
            {
                List<MediaViewModel> mediaModel = new List<MediaViewModel>();

                var mediaQuery = (from survey in db.Survey
                                  join response in db.Responses
                                  on survey.SurveyId equals response.SurveyId
                                  join question in db.SurveyQuestions
                                  on response.QuestionId equals question.QuestionId
                                  join media in db.SurveyMedias
                                  on response.QuestionId equals media.QuestionId
                                  where question.QuestionId == Id
                                  select new
                                  {
                                      media.MediaContent,
                                      question.QuestionId
                                  }).ToList();


                foreach (var query in mediaQuery)
                {
                    MediaViewModel responseSummaryViewModel = new MediaViewModel
                    {
                      QuestionId = query.QuestionId,
                      MediaContent = query.MediaContent
                    };
                    mediaModel.Add(responseSummaryViewModel);
                }
                return View(mediaModel);
            }
        }




    }
}