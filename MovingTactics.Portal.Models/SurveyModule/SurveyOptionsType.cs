using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyOptionsType
    {
        [Key]
        public int SurveyOptionTypeId { get; set; }
        public string SurveyOptionType { get; set; }
    }
}
