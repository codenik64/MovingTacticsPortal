using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.ViewModels
{
    public class ResponseSummaryViewModel
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string ResponseValue { get; set; }
        public string Survey { get; set; }
        public string Member { get; set; }
    }
}
