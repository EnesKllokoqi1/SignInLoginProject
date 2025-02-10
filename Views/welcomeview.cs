using SignInLoginProject.FieldValidators;
using SigninLoginProject.Model;
using System;
using SignInLoginProject.Views;
using System.Collections.Generic;
using System.Text;
using SignInLoginProject;
using Microsoft.EntityFrameworkCore.Metadata;
using IView = SignInLoginProject.Views.IView;

namespace ClubMembershipApplication.Views
{
    

    public class WelcomeClientView : IView
    {
        Client _client = null;

        public WelcomeClientView(Client client)
        {
            _client = client;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            Console.Clear();
            Outputtext.WriteMainHeading();

           OutputFormat.ChangeFontTheme(FontColors.Green);
           Console.WriteLine($"Hi {_client.Name}!!{Environment.NewLine}Welcome!!");
           OutputFormat.ChangeFontTheme(FontColors.White);
           Console.ReadKey();
        }
    }
}
