using Core.Domain.Entities.Item;
using Core.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    //IdentityDbContext is a class which has inherited from DbContext.
    //To use Identities i need to inherit from IdentityDbContext instead of DbContext

    public class MyDbContext : IdentityDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base (options)
        {
        }

        public DbSet<CatalogueItem> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //for IdentityDbContext
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            //add seed data here if you need!

            /*
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = 001,
                    Name = "NameUserSeed001"                    
                });

                and so on...
            */
        }
    }
}
