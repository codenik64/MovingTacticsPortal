using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.UserModule
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string ContactNumber { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
