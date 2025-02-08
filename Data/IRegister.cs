using System;
using System.Security.Cryptography;
namespace SignInLoginProject.Data{
public interface IRegister{
    bool Register(string[] fields);
    bool EmailExists(string emailAddress);
    
}
}