using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyResponses
    {
        [Key]
        public int SurveyResponseId { get; set; }

        public int SurveyId { get;set;}

        public int MemberId { get; set; }

        public string DateCreated { get; set; }

        public string TimeCreated { get; set; }
    }
}
