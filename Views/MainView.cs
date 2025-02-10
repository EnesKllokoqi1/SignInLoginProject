using System;
using System.Collections.Generic;
using System.Text;
using SignInLoginProject;
using SignInLoginProject.FieldValidators;
using SignInLoginProject.Views;


namespace ClubMembershipApplication.Views
{
 class MainView : IView
    {
        public IFieldValidator FieldValidator => null;

        IView _registerView = null;
        IView _loginView = null;
        public MainView(IView registerView, IView loginView)
        {
            _registerView = registerView;
            _loginView = loginView;
        }
        public void RunView()
        {
            Outputtext.WriteMainHeading();

            Console.WriteLine("Please press 'l' to login or if you are not yet registered please press 'r'");
            System.Console.WriteLine();

            ConsoleKey key = Console.ReadKey().Key;
            System.Console.WriteLine();
            System.Console.WriteLine();

            if (key == ConsoleKey.R)
            {
                RunRegistrationView();
                RunLoginView();
            }
            else if (key == ConsoleKey.L)
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Goodbye");
                Console.ReadKey();
               
            }
        
        }

        private void RunRegistrationView()
        {
            _registerView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }

    }
}