using MovingTactics.Portal.DataAccess;
using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MovingTactics.Portal.Customs.Helpers
{
    public static class GlobalMTHelper
    {
        public static string LoggedInUser()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public static string Username()
        {
            var Getusername = UserNameHelper(LoggedInUser());
            return Getusername;
        }

        public static Members GenericUserIdentityHelper(string UserEmail)
        {
            using (MovingTacticsEntities dbContext = new MovingTacticsEntities())
            {


                var UserInfo = from user in dbContext.Members
                               join IdentityUser in dbContext.AspNetUsers
                                on user.EmailAddress equals IdentityUser.Email
                               where user.EmailAddress == UserEmail
                               select user;

                return (Members)UserInfo.FirstOrDefault();


            }
        }

        public static string UserNameHelper(string UserEmail)
        {

            var username = GenericUserIdentityHelper(UserEmail).MemberName;
            return username.ToString();


        }

        public static int FindMemberId(string EmailAddress)
        {
            using (MovingTacticsEntities dbContext = new MovingTacticsEntities())
            {
                var userLambda = dbContext.Members.Join(dbContext.AspNetUsers, Members => Members.EmailAddress, AspUser => AspUser.Email, (Members, AspUser) =>
                new { Members, AspUser }).Where(x => x.Members.EmailAddress == EmailAddress);

                var Memberuid = userLambda.FirstOrDefault().Members.MemberId;

                return Memberuid;
            }
        }

        public static int GetMemberId()
        {
            var MemberId = FindMemberId(LoggedInUser());
            return MemberId;
        }
    }
}
