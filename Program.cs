using System.Diagnostics;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tablero tablero = new Tablero(20,20);
            
            Serpiente serpiente = new Serpiente(10, 10);
            Caramelo caramelo = new Caramelo(0, 0);   
            bool haComido = false;  
            do
            {
                Console.Clear();
                tablero.Dibujo();              
                serpiente.ComprobarSiMuere(tablero);

                if (serpiente.Viva)
                {
                    serpiente.Moverse(haComido);
                    //Comprobar si come
                    haComido = serpiente.Comer(caramelo, tablero);

                    //Se dibuja la serpiente
                    serpiente.DibujarSerp();

                if (!tablero.ContieneCara)
                {
                    caramelo = Caramelo.CrearCaramelo(serpiente, tablero);

                }
                //Dibujamos caramelo
                caramelo.DibujarCaranelo();
                
                    //Se lee informacion de la direccion
                    var sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds <= 250)
                    {
                        serpiente.Direccion = LeerMovi(serpiente.Direccion);

                    }
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Util.DibujarPosiciones(tablero.Ancho/2, tablero.Altura/2,"Game Over");
                    Util.DibujarPosiciones(tablero.Ancho / 2, (tablero.Altura / 2)+1,$"Puntacion :  {serpiente.Puntos}");
                    Console.ResetColor();
                }
                

            } while (serpiente.Viva);

            Console.ReadKey();      
        }
        static Direccion LeerMovi(Direccion MovimiActual)
        {
            if (Console.KeyAvailable)
            {
                var Key = Console.ReadKey().Key;
                if(Key == ConsoleKey.UpArrow && MovimiActual != Direccion.Abajo)
                {
                    return Direccion.Arriba;
                }else if (Key == ConsoleKey.DownArrow &&MovimiActual != Direccion.Arriba)
                {
                    return Direccion.Abajo;

                }else if (Key == ConsoleKey.LeftArrow && MovimiActual != Direccion.Derecha)
                {
                    return Direccion.Izquierda;

                }else if (Key == ConsoleKey.RightArrow && MovimiActual != Direccion.Izquierda)
                {
                    return Direccion.Derecha;
                }

            }
            return MovimiActual;
        }

    }
}