using System;
namespace SignInLoginProject.FieldValidators{
   public  delegate bool FieldValidatorDel(int index,string fieldValue,string[] FieldArary,out string fieldInvalidMessage);
public  interface IFieldValidator{
    FieldValidatorDel ValidatorDel{get;}
    void InitialiseFieldValidatorDelegates();
    string[] FieldArray{get;}

 }
}