using System;
namespace zaliczenie_2_semestr
{
    public class Display
    {
        public void ConsolePrint(string content, bool newLine = true)
        {
            if (!newLine){
                Console.Write(content);
                return;
            }

            Console.WriteLine(content);
        }
    }
}