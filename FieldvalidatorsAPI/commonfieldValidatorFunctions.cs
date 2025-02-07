using System;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyModel.Resolution;

namespace SignInLoginProject.FieldValidatorsAPI
{
    class CommonFieldValidatorFunctions
    {
        // Delegate declarations
       public delegate bool RequiredValidDel(string fieldValue);
        public delegate bool PatternMatchValidDel(string fieldValue, string pattern);
        public delegate bool CompareFieldsValidDel(string field1, string field2);
        public delegate bool StringLengthFieldValidDel(string fieldVal, int min, int max);

        // Delegate instances
        private static RequiredValidDel _requiredValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;
        private static StringLengthFieldValidDel _stringLengthFieldValidDel = null;

       
        public static RequiredValidDel RequiredFieldValidator
        {
            get
            {
                if (_requiredValidDel == null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                }
                return _requiredValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchValidator{
            get{
                if(_patternMatchValidDel==null){
                    _patternMatchValidDel= new PatternMatchValidDel(PaternFieldValid);
                }
                return _patternMatchValidDel;
            }

        }
        public static CompareFieldsValidDel CompareFieldsValidator{
            get{
                if(_compareFieldsValidDel==null){
                    _compareFieldsValidDel= new CompareFieldsValidDel(CompareFieldValid);
                }
                return _compareFieldsValidDel;
           
            }

        }
        public static StringLengthFieldValidDel StringLengthFieldValidator{
            get{
                if(_stringLengthFieldValidDel == null){
                    _stringLengthFieldValidDel= new StringLengthFieldValidDel(StringLengthFieldValid);
                }
                return _stringLengthFieldValidDel;
            }
        }
        private static bool RequiredFieldValid(string fieldVal){
            if(!string.IsNullOrEmpty(fieldVal)){
                return true;
            }else{
                return false;
            }
        }
        private static bool StringLengthFieldValid(string fieldValue,int min,int max){
            if(fieldValue.Length>=min && fieldValue.Length<=max){
                return true;
            }else{
                return false;
            }
        }
        private static bool CompareFieldValid(string field1,string field2){
            if(field1.Equals(field2)){
                return true;
            }else{
                return false;
            }
        }
        private static bool PaternFieldValid(string fieldVal,string pattern){
            Regex regex = new Regex(pattern);
            if(regex.IsMatch(fieldVal)){
                return true;
            }else{
                return false;
            }
        }
        

       

    }
}