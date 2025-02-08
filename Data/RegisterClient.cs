using System;
using System.Linq;
using System.Data;
using System.Reflection.Metadata;
using SigninLoginProject.Model;
using Microsoft.EntityFrameworkCore;
using SigninLoginProject.Data;
using SignInLoginProject.FieldValidators;
using SignInLoginProject.Data;
class RegisterClient : IRegister{
    
    public bool EmailExists(string emailAddress){
      bool emailExists;
      using(var dbContext= new DbContextSqlite()){
       emailExists=dbContext.Clients.Any(c=>c.EmailAddress.ToUpper().Trim() == emailAddress.ToUpper().Trim());
       return emailExists;
      }
    }public bool Register(string[] fields){
        using(var dbContext= new DbContextSqlite()){
        Client client= new Client(){
            EmailAddress=fields[(int)FieldConstants.ClientRegistrationField.EmailAddress],
            Name=fields[(int)FieldConstants.ClientRegistrationField.Name],
            LastName=fields[(int)FieldConstants.ClientRegistrationField.Name],
            Password=fields[(int)FieldConstants.ClientRegistrationField.Password]
        };
        dbContext.Add(client);
        dbContext.SaveChanges();

    }
    return true;

}
}