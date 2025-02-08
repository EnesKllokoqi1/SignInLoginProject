using System;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using SigninLoginProject.Data;
using SigninLoginProject.Model;
namespace SignInLoginProject.Data{
    class LoginClient  : ILogin{
        public Client Login(string emailAddress,string password){
            Client client=null;
             using(var dbContext= new DbContextSqlite()){
                client=dbContext.Clients.FirstOrDefault(c=>c.EmailAddress.ToUpper().Trim() == emailAddress.ToUpper().Trim() && c.Password.Equals(password));
              
            }
            return client;

        }
    }
}