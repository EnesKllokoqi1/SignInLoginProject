using System;
using Microsoft.EntityFrameworkCore;
using SigninLoginProject.Model;
namespace SigninLoginProject.Data{
    class DbContextSqlite : DbContext{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source={AppDomain.CurrentDomain.BaseDirectory}SigninLogin.db");
             base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Client> Clients{get;set;}
        
    }
}