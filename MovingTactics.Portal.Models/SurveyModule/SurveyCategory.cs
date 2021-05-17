using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public List<Survey> Surveys { get; set; }

    }
}
