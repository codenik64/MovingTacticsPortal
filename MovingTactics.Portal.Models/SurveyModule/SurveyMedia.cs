using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MovingTactics.Portal.Models.SurveyModule
{
    public class SurveyMedia
    {
        [Key]
        public int MediaId { get; set; }

        public byte[] MediaContent { get; set; }

        public int QuestionId { get; set; }

        public int ResponseId { get; set; }

        public int SurveyId { get; set; }

        public int MemberId { get; set; }

        public string DateCreated { get; set; }
    }
}
