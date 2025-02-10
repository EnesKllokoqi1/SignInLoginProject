using System;
using SignInLoginProject.FieldValidators;
namespace SignInLoginProject.Views{
   
        public interface IView{
            void RunView();
            IFieldValidator FieldValidator{get;}
        }
    
}