using System;
namespace SignInLoginProject{
    public enum FontColors{
           White,
           Red,
           Green

        }
    public static class OutputFormat{
        public static void ChangeFontTheme(FontColors fontColors){
            if(fontColors ==FontColors.Red){
                Console.BackgroundColor=ConsoleColor.Red;
                Console.ForegroundColor=ConsoleColor.White;
            }else if(fontColors == FontColors.Green){
                Console.BackgroundColor=ConsoleColor.Green;
                Console.ForegroundColor=ConsoleColor.White;
            }else{
                Console.ResetColor();
            }
        }
        


    }

}