using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Tablero
    {
        public readonly int Altura;
        public readonly int Ancho;
        public bool ContieneCara;
        public Tablero(int Altura, int Ancho)
        {
            this.Altura= Altura;
            this.Ancho = Ancho;
            ContieneCara = false;    
        } 

        public void Dibujo()
        {
            for (int  i = 0; i <=Altura;  i++)
            {
                Util.DibujarPosiciones(Ancho,i,"#");
                Util.DibujarPosiciones(0, i, "#");
            }
            for (int i = 0; i <=Ancho; i++)
            {
                Util.DibujarPosiciones(i, 0, "#");
                Util.DibujarPosiciones(i, Altura, "#");  

            }

        }
    }
}
