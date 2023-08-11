using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Util
    {
        public static void DibujarPosiciones(int x ,int y, string Caracter)
        {
           
            Console.SetCursorPosition(x, y);
            Console.WriteLine(Caracter);

        }
    }
}
