using Core.Domain.Entities.Item;
using Core.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class MyDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyDbContext(DbContextOptions<MyDbContext> options, IHttpContextAccessor httpContextAccessor) : base (options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Userx> Users { get; set; }
        public DbSet<CatalogueItem> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
