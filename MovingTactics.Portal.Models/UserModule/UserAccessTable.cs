using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.Models.UserModule
{
    public class UserAccessTable
    {
        [Key]
        public int AccessId { get; set; }
        public string UserGuidId { get; set; }
        public string RoleGuidId { get; set; }
        public System.DateTime DateEnrolled { get; set; }
        public int FunctionId { get; set; }
        public bool UserRevoked { get; set; }
        public string UserName { get; set; }
    }
}
