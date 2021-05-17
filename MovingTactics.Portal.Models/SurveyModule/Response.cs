using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public int QuestionId { get; set; }
        public int MemberId { get; set; }
        public int SurveyId { get; set; }
        public string ResponseValue { get; set; }
        public string Comment { get; set; }
        public int YesQuestionCount { get; set; }
        public string DateCreated { get; set; }
        public int SurveyResponseId { get; set; }

    }
}
