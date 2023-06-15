using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp30
{
   static class РандомИЦвета
    {
      static  Random random = new Random();
        public static int РандомЦифри(int min, int max)
        {
            
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }

        public static ConsoleColor Цвета(int Цифра)
        {
            if (Цифра == 0)
                return ConsoleColor.White;
            else if (Цифра == 1)
                return ConsoleColor.Blue;
            else if (Цифра == 2)
                return ConsoleColor.Yellow;
            else if (Цифра == 3)
                return ConsoleColor.Cyan;
            else if (Цифра == 4)
                return ConsoleColor.Red;
            else if (Цифра == 5)
                return ConsoleColor.DarkRed;
            else if (Цифра == 6)
                return ConsoleColor.DarkCyan;
            else if (Цифра == 7)
                return ConsoleColor.DarkGreen;
            else if (Цифра == 8)
                return ConsoleColor.Magenta;
            else if (Цифра == 9)
                return ConsoleColor.Green;
            else if (Цифра == 10)
                return ConsoleColor.Gray;
            else if (Цифра == 11)
                return ConsoleColor.DarkGray;
            else if (Цифра == 12)
                return ConsoleColor.DarkMagenta;
            else if (Цифра == 13)
                return ConsoleColor.DarkYellow;
            else
                return ConsoleColor.White;
        }
    }

}
