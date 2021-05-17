using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovingTactics.Portal.DataAccess.EntityFramework.Identity;
using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.DataAccess.EntityFramework
{
    public static class IdentityStoreManager
    {
        public static void AddIdentityUser(string EmailAddress, string MemberPassword)
        {
            try
            {
                #region Declare Manager
                var IdentityManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MovingTacticsDbContext()));
                #endregion

                var UserAccount = EmailAddress;
                var ExistingUser = IdentityManager.FindByName(UserAccount);
                if (ExistingUser == null)
                {
                    #region instance of AspNetUser
                    var Member = new ApplicationUser();

                    Member.Email = EmailAddress;
                    Member.UserName = EmailAddress;
                    string Password = MemberPassword;
                    #endregion

                    var IdentityUser = IdentityManager.Create(Member, Password);

                }
            }
            catch (Exception identityException)

            {
                var Exception = identityException.Message;
                string CustomError = "the user being  created already exists in the database";
                Exception = CustomError.ToString();


            }
        }
        public static void CreateUserPermission(string UserRole, string GlobalId)
        {

            using (MovingTacticsEntities dbContext = new MovingTacticsEntities())
            {
                AspNetRole permission = new AspNetRole
                {
                    Id = GlobalId.ToString(),
                    Name = UserRole
                };

                dbContext.AspNetRoles.Add(permission);
                dbContext.SaveChanges();
            }
        }
        public static void AddUserToRole(string UserGuid, string RoleGuid)
        {
            using (MovingTacticsEntities dbContext = new MovingTacticsEntities())
            {
                var IdentityManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new MovingTacticsDbContext()));
                IdentityManager.AddToRole(UserGuid, RoleGuid);

            }
        }
    }
}
