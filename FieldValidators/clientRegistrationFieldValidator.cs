using System;
using  SignInLoginProject.FieldvalidatorsAPI;
using SignInLoginProject.FieldValidators;
using SigninLoginProject.Data;
using System.Diagnostics.Metrics;
using SignInLoginProject.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
namespace SignInLoginProject.FieldValidators{
    class  ClientRegistrationFieldValidator{
        const int FirstName_Min_Length=2;
        const int FirstName_Max_Length=100;
        const int LastName_Min_Length=2;
        const int LastName_Max_Length=100;
        RequiredValidDel _requiredValidDel=null;
        StringLengthFieldValidDel _stringLengthFieldValidDel=null;
        PatternMatchValidDel _patternMatchValidDel=null;
        CompareFieldsValidDel _compareFieldsValidDel=null;
        delegate bool EmailExists (string emailAddress);
        EmailExists _emailExists=null;
        IRegister _register=null;
        FieldValidatorDel _fieldValidator=null;
        string[]  _fieldArray=null;
        public ClientRegistrationFieldValidator(IRegister register){
            _register=register;

        }
      
        FieldValidatorDel FieldValidator=>_fieldValidator;
        public string[] FieldArray{
            get{
                if(_fieldArray == null){
                     _fieldArray= new string[Enum.GetValues(typeof(FieldConstants.ClientRegistrationField)).Length];
                }
                return _fieldArray;
            }
        }
        public void InitialiseFieldValidatorDelegates(){
            _emailExists= new EmailExists(_register.EmailExists);
            _requiredValidDel= CommonFieldValidatorFunctions.RequiredFieldValidator;
            _stringLengthFieldValidDel=CommonFieldValidatorFunctions.StringLengthFieldValidator;
            _patternMatchValidDel=CommonFieldValidatorFunctions.PatternMatchValidator;
            _compareFieldsValidDel=CommonFieldValidatorFunctions.CompareFieldsValidator;
            _fieldValidator = new FieldValidatorDel(ValidFields);

        }
        private bool ValidFields(string fieldVal,int index,string[] fieldArray,out string fieldInvalidMessage){
             fieldInvalidMessage="";
             FieldConstants.ClientRegistrationField clientRegistrationField= (FieldConstants.ClientRegistrationField)index;
             switch(clientRegistrationField){
                case FieldConstants.ClientRegistrationField.Name :
                fieldInvalidMessage=(!_requiredValidDel(fieldVal))? $"Pls enter a value for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)} " : " "; 
                fieldInvalidMessage=(fieldInvalidMessage=="" && _stringLengthFieldValidDel(fieldInvalidMessage,FirstName_Min_Length,FirstName_Max_Length))? $"Please enter between Min and Max Characters  for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)}{Environment.NewLine}" : fieldInvalidMessage;
                break;
                case FieldConstants.ClientRegistrationField.EmailAddress:
                  fieldInvalidMessage=(fieldInvalidMessage == "" && _compareFieldsValidDel(fieldVal,fieldArray[(int)FieldConstants.ClientRegistrationField.EmailAddress]))?  $"Your input did not match ur passowrd : " : fieldInvalidMessage;
                fieldInvalidMessage=(!_requiredValidDel(fieldVal))? $"Pls enter a value for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)} " : " "; 
                fieldInvalidMessage=(fieldInvalidMessage == "" && _emailExists(fieldVal))? $"Email already exists enter in another email {Environment.NewLine}" : fieldInvalidMessage;
                break;
                case FieldConstants.ClientRegistrationField.LastName: 
                 fieldInvalidMessage=(!_requiredValidDel(fieldVal))? $"Pls enter a value for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)} " : " "; 
                fieldInvalidMessage=(fieldInvalidMessage=="" && _stringLengthFieldValidDel(fieldInvalidMessage,FirstName_Min_Length,FirstName_Max_Length))? $"Please enter between Min and Max Characters  for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)}{Environment.NewLine}" : fieldInvalidMessage;
                 break;
                 case FieldConstants.ClientRegistrationField.Password:
                   fieldInvalidMessage=(!_requiredValidDel(fieldVal))? $"Pls enter a value for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)} " : " ";
                   fieldInvalidMessage=(fieldInvalidMessage == "" && !_patternMatchValidDel(fieldVal,CommonRegularExpressionValidationPatterns.Strong_Password_RegEx_Pattern))?  $"Enter a strong Password for {Enum.GetName(typeof(FieldConstants.ClientRegistrationField),clientRegistrationField)}{Environment.NewLine}"  : fieldInvalidMessage;
                 break;
                 case FieldConstants.ClientRegistrationField.PasswordCompare:
                 fieldInvalidMessage=(fieldInvalidMessage == "" && _compareFieldsValidDel(fieldVal,fieldArray[(int)FieldConstants.ClientRegistrationField.Password]))?  $"Your input did not match ur passowrd : " : fieldInvalidMessage;
                 break;
                default:
                throw new Exception();
             }
          
            return (fieldInvalidMessage == "");

        }


    }
}