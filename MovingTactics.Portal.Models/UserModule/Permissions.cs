using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.UserModule
{
    public class Permissions
    {
        [Key]
        public int UserGuidId { get; set; }
        public string UserGuid { get; set; }
        public string UserRole { get; set; }
        public int UserRoleId { get; set; }
        public System.DateTime DateEnrolled { get; set; }
        public string MemberEnrolled { get; set; }
    }
}
