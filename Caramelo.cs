using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Caramelo
    {
        public Posicion posicion { get; set; }
        public Caramelo(int x ,int y)
        {
            posicion = new Posicion(x, y);
             
        }
        public void DibujarCaranelo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Util.DibujarPosiciones(posicion.x, posicion.y, "o");
            Console.ResetColor();
        }

        public static Caramelo CrearCaramelo(Serpiente serpiente, Tablero tablero)
        {
            bool CarameloValido = false;
            int x = 0;  
            int y = 0;  
            do
            { Random random = new Random();
                 x = random.Next(1,tablero.Ancho-1);
                y = random.Next(1, tablero.Altura - 1);
                CarameloValido = serpiente.PosicionEnCola(x, y); 


            } while (CarameloValido);
            tablero.ContieneCara = true;
            return new Caramelo(x, y);
        } 
    }
}
 