using System;
using SigninLoginProject.Model;
namespace SignInLoginProject.Data{
   public  interface ILogin{
        Client Login(string emailAddress,string password);
    }
}
