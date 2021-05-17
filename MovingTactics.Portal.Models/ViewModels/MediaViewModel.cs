using MovingTactics.Portal.Models.SurveyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.ViewModels
{
    public class MediaViewModel
    {
        public int QuestionId { get; set; }
        public byte[] MediaContent { get; set; }
    }
}
