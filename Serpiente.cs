using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Serpiente 
    {
        List<Posicion> Cola { get; set; }   
       public  Direccion Direccion { get; set; }
        public int Puntos { get; set; }    
       public bool Viva { get; set; }

        public Serpiente(int x , int y)
        {            
            Posicion posicioninicial = new Posicion(x,y);
            Cola = new List<Posicion>() { posicioninicial};
            Direccion = Direccion.Abajo;
            Puntos = 0;
            Viva = true;
        }
        public void DibujarSerp()
        {
            foreach (Posicion posicion in Cola)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Util.DibujarPosiciones(posicion.x, posicion.y, "x");
                Console.ResetColor();   
            }
        }

        public void ComprobarSiMuere(Tablero tablero)
        {

            
            //Si chocamos contra nosotros
            Posicion primeraPosicion = Cola.First();
            Viva =!((Cola.Count(a => a.x == primeraPosicion.x && a.y == primeraPosicion.y) > 1) || CabezaenPared(tablero , Cola.First()));
        }
  
        // Si la primera posicion esta en cualquiera de los muros morimos 
        private bool CabezaenPared(Tablero tablero, Posicion PrimeraPosicion)
        {
            return PrimeraPosicion.y == 0 || PrimeraPosicion.y == tablero.Altura 
                || PrimeraPosicion.x == 0 || PrimeraPosicion.x == tablero.Ancho;

        }


        public void Moverse(bool Hacomido)
        {
            List<Posicion> NuevaCola =  new List<Posicion>();
            NuevaCola.Add(ObtenerNuevaPosicion());
            NuevaCola.AddRange(Cola);
            Cola = NuevaCola;
            if (!Hacomido)
            {
                NuevaCola.Remove(NuevaCola.Last());

            }
        }
        private Posicion ObtenerNuevaPosicion()
        {
            int x = Cola.First().x;
            int y = Cola.First().y;
                
            switch (Direccion)
            {
                case Direccion.Abajo:
                    y += 1;
                    break;
                case Direccion.Arriba:
                    y -= 1;
                    break;
                case Direccion.Derecha:
                    x+= 1;  
                    break;
                case Direccion.Izquierda:
                    x-=1;
                    break;

            }
            return new Posicion(x, y);
        }
        public bool Comer(Caramelo caramelo,Tablero tablero )
        {
            if (PosicionEnCola(caramelo.posicion.x, caramelo.posicion.y))
            {
                Puntos += 10;
                tablero.ContieneCara = false;
                return true;
            }

            return false;
            
        }
        public void AddAlaCola(int x, int y)
        {

        }
        public bool PosicionEnCola(int x , int y)
        {
            return Cola.Any(a => a.x == x && a.y == y);
        }

    }
}
    