using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.ErrorModule
{
   public class ErrorLog
    {
        [Key]
        public int ErrorLogId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorSourceObject { get; set; }
        public string TargetSite { get; set; }
        public System.DateTime DateLogged { get; set; }
    }
}
