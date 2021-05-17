using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyQuestions
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionBody { get; set; }
        public int SurveyId { get; set; }
        public int MemberId { get; set; }
        public Members Members { get; set; }
        //public List<SurveyOptions> SurveyOptions { get; set; }


    }
}
