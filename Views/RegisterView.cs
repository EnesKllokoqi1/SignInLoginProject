using System;
using System.Reflection.Metadata;
using SigninLoginProject.Model;
using SignInLoginProject.Data;
using SignInLoginProject.FieldValidators;
namespace SignInLoginProject.Views;
public class RegisterView : IView{
    IRegister _register=null;
    IFieldValidator _fieldValidator=null;
    public IFieldValidator FieldValidator=> _fieldValidator;
    public RegisterView(IRegister register,IFieldValidator fieldValidatorDel){
        _register=register;
        _fieldValidator=fieldValidatorDel;
    }
    public void RunView(){
        Outputtext.WriteMainHeading();
        Outputtext.WriteRegisterHeading();
        _fieldValidator.FieldArray[(int)FieldConstants.ClientRegistrationField.Name]=GetInputFromUser(FieldConstants.ClientRegistrationField.Name,"Please enter ur name : ");
        _fieldValidator.FieldArray[(int)FieldConstants.ClientRegistrationField.LastName]=GetInputFromUser(FieldConstants.ClientRegistrationField.LastName,"Please enter ur last name :");
        _fieldValidator.FieldArray[(int)FieldConstants.ClientRegistrationField.EmailAddress]=GetInputFromUser(FieldConstants.ClientRegistrationField.EmailAddress,"Please enter ur email :");
        _fieldValidator.FieldArray[(int)FieldConstants.ClientRegistrationField.Password]=GetInputFromUser(FieldConstants.ClientRegistrationField.Password, $"Please enter your password.{Environment.NewLine}(Your password must contain at least 1 small-case letter,{Environment.NewLine}1 Capital letter, 1 digit, 1 special character{Environment.NewLine} and the length should be between 6-10 characters)");
        _fieldValidator.FieldArray[(int)FieldConstants.ClientRegistrationField.PasswordCompare]=GetInputFromUser(FieldConstants.ClientRegistrationField.PasswordCompare,"Please re-enter your password: ");
        RegisterClient();

        
        
        
    }
    private  string GetInputFromUser(FieldConstants.ClientRegistrationField field, string text){
       string  fieldVal="";
        do{
            System.Console.WriteLine(text);
            fieldVal=Console.ReadLine();
            
        }while(!FieldValid(field, fieldVal));

        return fieldVal;
    }
    private void RegisterClient(){
        _register.Register(_fieldValidator.FieldArray);
        OutputFormat.ChangeFontTheme(FontColors.Green);
        System.Console.WriteLine("You have been registered!!!");
        System.Console.WriteLine("Press any key to continue ");
        OutputFormat.ChangeFontTheme(FontColors.White);
        Console.ReadLine();
        

    }
    private bool FieldValid(FieldConstants.ClientRegistrationField field,string fieldVal){
        if(!_fieldValidator.ValidatorDel((int)field,fieldVal,_fieldValidator.FieldArray, out string invalidMessage)){
            OutputFormat.ChangeFontTheme(FontColors.Red);
            System.Console.WriteLine(invalidMessage);
            OutputFormat.ChangeFontTheme(FontColors.White);
            return false;

        }
        return true;
    }
    

}
