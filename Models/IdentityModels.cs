using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace testest.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez que l'authenticationType doit correspondre à celui défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter des revendications utilisateur personnalisées ici
            return userIdentity;
        }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public virtual ICollection<Resultat_Test> Resultat_Tests { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.SetInitializer<ApplicationDbContext>(null);
        }


        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }
        public DbSet<Test> Tests { get; set; }
        public DbSet<testest.Models.Resultat_Test> Resultat_Tests { get; set; }

        //public virtual DbSet<testest.Models.C__MigrationHistory> C__MigrationHistory { get; set; }
        //public virtual DbSet<testest.Models.AspNetRoles> AspNetRoles { get; set; }
        //public virtual DbSet<testest.Models.AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual DbSet<testest.Models.AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual DbSet<testest.Models.AspNetUsers> AspNetUsers { get; set; }
        public DbSet<testest.Models.Question> Questions { get; set; }

        //public System.Data.Entity.DbSet<testest.Models.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<testest.Models.Reponse> Reponses { get; set; }
        public DbSet<testest.Models.Test_Question> Test_Questions { get; set; }


        //public System.Data.Entity.DbSet<testest.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}