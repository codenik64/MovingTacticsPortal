using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyViewModel
    {
        public IEnumerable<SurveyQuestions> SurveyQuestions { get; set; }
        public IEnumerable<SurveyOptions> SurveyOptions { get; set; }

        public Survey Survey { get; set; }

    }
}
