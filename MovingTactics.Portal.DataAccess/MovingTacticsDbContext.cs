using MovingTactics.Portal.Models.SurveyModule;
using MovingTactics.Portal.Models.UserModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingTactics.Portal.DataAccess
{
    public partial class MovingTacticsEntities : DbContext
    {
        public MovingTacticsEntities() : base("name=MovingTacticsEntities")
        {
        }
        public static MovingTacticsEntities Create()
        {
            return new MovingTacticsEntities();
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        #region User Module Tables
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<UserAccessTable> UserAccessTable { get; set; }
        #endregion

        #region Error Module Tables
        #endregion

        #region Survey Module Tables
        public DbSet<Survey> Survey { get; set; }
        public DbSet<SurveyOptionsType> SurveyOptionsType { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<SurveyOptions> SurveyOptions { get; set; }
        public DbSet<SurveyQuestions> SurveyQuestions { get; set; }
        public DbSet<SurveyCategory> SurveyCategory { get; set; }
        public DbSet<SurveyMedia> SurveyMedias { get; set; }

        public DbSet<SurveyResponses> SurveyResponses { get; set; }


        #endregion






    }
}
