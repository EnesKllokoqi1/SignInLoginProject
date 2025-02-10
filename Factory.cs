using System;
using System.Collections.Generic;
using System.Text;
using SignInLoginProject.Views;
using SignInLoginProject.Data;
using SignInLoginProject.FieldValidators;
using SigninLoginProject.Model;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication
{
    public static class Factory
    {
        public static IView GetMainViewObject()
        {
          ILogin login=new LoginClient();
          IRegister register=new RegisterClient();
          IFieldValidator clientRegistrationValidator=new ClientRegistrationFieldValidator(register);
          clientRegistrationValidator.InitialiseFieldValidatorDelegates();
          IView loginView=new LoginView(login);
          IView registerView=new RegisterView(register,clientRegistrationValidator);
          IView mainView=new MainView(registerView,loginView);
          return mainView;

        }
    }
}