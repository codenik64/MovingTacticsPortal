
using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MovingTactics.Portal.Customs.Helpers
{
    public static class RST_MovingTactics_DropdownBuilder
    {
        static readonly MovingTacticsEntities dbContext = new MovingTacticsEntities();

        public static IEnumerable<SelectListItem> GetSurveyTypes()
        {
            List<SelectListItem> surveyItem = new List<SelectListItem> {
                new SelectListItem{ Text = "Select Survey Type" , Value ="-1".ToString()}
            };

            var type = dbContext.SurveyCategory.Select(x => new SelectListItem
            {
                Text = x.CategoryTitle,
                Value = x.CategoryId.ToString()
            });
            surveyItem.AddRange(type);

            return surveyItem;
        }

        public static IEnumerable<SelectListItem> GetMembers()
        {
            List<SelectListItem> memberItem = new List<SelectListItem> {
                new SelectListItem{ Text = "Select Member" , Value ="-1".ToString()}
            };

            var type = dbContext.Members.Select(x => new SelectListItem
            {
                Text = x.MemberName,
                Value = x.MemberId.ToString()
            });
            memberItem.AddRange(type);

            return memberItem;
        }

        public static IEnumerable<SelectListItem> GetSurveys()
        {
            List<SelectListItem> surveyItem = new List<SelectListItem> {
                new SelectListItem{ Text = "Select Survey" , Value ="-1".ToString()}
            };

            var type = dbContext.Survey.Select(x => new SelectListItem
            {
                Text = x.SurveyTitle,
                Value = x.SurveyId.ToString()
            });
            surveyItem.AddRange(type);

            return surveyItem;
        }

        public static IEnumerable<SelectListItem> GetSurveyOptionTypes()
        {
            List<SelectListItem> surveyOptionItem = new List<SelectListItem> {
                new SelectListItem{ Text = "Select Survey Option Type" , Value ="-1".ToString()}
            };

            var type = dbContext.SurveyOptionsType.Select(x => new SelectListItem
            {
                Text = x.SurveyOptionType,
                Value = x.SurveyOptionType.ToString()
            });
            surveyOptionItem.AddRange(type);

            return surveyOptionItem;
        }

    }
}
