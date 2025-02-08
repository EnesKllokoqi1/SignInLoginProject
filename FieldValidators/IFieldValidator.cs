using System;
namespace SignInLoginProject.FieldValidators{
    delegate bool FieldValidatorDel(string fieldValue,int index,string[] FieldArary,out string fieldInvalidMessage);
 interface IFieldValidator{
    FieldValidatorDel ValidatorDel{get;}
    void InitialiseFieldValidatorDelegates();
    string[] FieldArary{get;}

 }
}