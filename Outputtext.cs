using System;
using System.Threading.Tasks.Dataflow;
namespace SignInLoginProject{
    public static class Outputtext{
        private static string MainHeading{
            get{
                string heading="Welcome to the project : ";
                return$"{heading}{Environment.NewLine}{new string('-',heading.Length)}";
            }
        }
          private static string RegistrationHeading{
            get{
                string heading="Register :  ";
                return$"{heading}{Environment.NewLine}{new string('-',heading.Length)}";
            }
        }
         private static string LoginHeading{
            get{
                string heading="Login :  ";
                return$"{heading}{Environment.NewLine}{new string('-',heading.Length)}";
            }
        }
        public static void  WriteMainHeading(){
        System.Console.WriteLine(MainHeading);
        System.Console.WriteLine();
        System.Console.WriteLine();
        }
         public static void  WriteRegisterHeading(){
        System.Console.WriteLine(RegistrationHeading);
        System.Console.WriteLine();
        System.Console.WriteLine();
        }
        public static void  WriteLoginHeading(){
        System.Console.WriteLine(LoginHeading);
        System.Console.WriteLine();
        System.Console.WriteLine();
        }
    }
}