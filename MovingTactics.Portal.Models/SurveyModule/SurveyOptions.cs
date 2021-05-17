using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyOptions
    {
        [Key]
        public int OptionId { get; set; }
        public string Title { get; set; }
        public string OptionType { get; set; }
        public int MemberId { get; set; }
        public Members Member { get; set; }
        public int SurveyId { get; set; }
    }
}
