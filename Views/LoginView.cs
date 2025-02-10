using System;
using SignInLoginProject.FieldValidators;
using SignInLoginProject.Data;
using SigninLoginProject.Model;
using System.Runtime.CompilerServices;
using ClubMembershipApplication.Views;
namespace SignInLoginProject.Views{
    public class LoginView : IView{
        ILogin _loginClient=null;
        
       public  IFieldValidator FieldValidator=>null;
        public LoginView(ILogin login){
            _loginClient=login;
        }
        public void RunView(){
            Outputtext.WriteMainHeading();
            Outputtext.WriteLoginHeading();
            System.Console.WriteLine();
          
            System.Console.WriteLine("Enter ur Email :");
            string emailAddress=Console.ReadLine();
            System.Console.WriteLine("Enter ur password  :");
            string password=Console.ReadLine();
            Client client=_loginClient.Login(emailAddress,password);
            if(client != null){
                WelcomeClientView welcomeClientVie= new WelcomeClientView(client);
                welcomeClientVie.RunView();
            }else{
                Console.Clear();
                OutputFormat.ChangeFontTheme(FontColors.Red);
                System.Console.WriteLine($"The credentials u placed dont match any of our records");
                OutputFormat.ChangeFontTheme(FontColors.White);
                Console.ReadKey();
            }
        }

    }
}