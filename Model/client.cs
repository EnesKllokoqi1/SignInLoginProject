using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
namespace SigninLoginProject.Model{
    public class Client{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        public string Name{get;set;}
        public string LastName{get;set;}
        public string EmailAddress{get;set;}
        public string Password{get;set;}
       
    }
}