using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.ViewModels
{
    public class SurveyResponseViewModel
    {
        public int SurveyResponseId { get; set; }
        public string Survey { get; set; }

        public string Member { get; set; }

        public string DateCreated { get; set; }

        public string TimeCreated { get; set; }

    }
}
