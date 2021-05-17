using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class Survey
    {
        [Key]
        public int SurveyId { get; set; }
        public string SurveyTitle { get; set; }
        public int CategoryId { get; set; }
        public SurveyCategory SurveyCategory { get; set; }

    }
}
