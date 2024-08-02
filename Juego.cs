using System;
using EspacioDuelo;
using EspacioFabricaDePersonajes;
using EspacioMovimientoJson;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPersonajesJS;
using EspacioPosiciones;
using EspacioAtaque;

namespace EspacioJuego
{
    public class Juego
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const int cantJugadores = 3;
        private const int cantEnemigos = 10;
        private const int cantMovimientos = 4;
        private Duelo claseDuelo;
        private Movimiento claseMovimiento;
        private PersonajesJson personajesJson;
        private MovimientosJson movimientosJson;
        private FabricaDePersonajes fabricaDePersonajes;
        private List<Personaje> jugadores;
        private List<Personaje> enemigos;
        private List <Movimiento> movimientos;
        private Personaje jugador;
        private Personaje enemigo;
        private Ataque ataque;
        private string? input;
        private bool validez;
        private int seleccionJugador;
        private Posiciones posicion1;
        private Posiciones posicion2;
        private Random rand;


        public Juego()
        {
            claseDuelo = new Duelo();
            claseMovimiento = new Movimiento();
            personajesJson = new PersonajesJson();
            movimientosJson = new MovimientosJson();
            fabricaDePersonajes = new FabricaDePersonajes();
            jugadores = new List<Personaje>();
            enemigos = new List<Personaje>();
            movimientos = new List<Movimiento>();
            jugador = new();
            enemigo = new();
            ataque = new();
            rand = new();
        }

        public void Inicializar()
        {
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            enemigos = fabricaDePersonajes.GenerarPersonajesAleatorios();
            movimientos = movimientosJson.LeerMovimientos(archivoMovimientos);
            validez = false;
        }
        public void Jugar()
        {
            Inicializar();
            Console.WriteLine("Bienvenido al Juego de Harry Potter: Duelo de varitas");
            do
            {
                Console.WriteLine("Seleccione el personaje para jugar");

                fabricaDePersonajes.MostrarListaDePersonajes(jugadores, cantJugadores, "PERSONAJE");

                input = Console.ReadLine();
                validez = int.TryParse(input, out seleccionJugador);
                if (!validez)
                {
                    Console.WriteLine("Lo ingresado no es un número. Intenta de nuevo.");
                    validez = false;
                }
                else
                {
                    if (3 < seleccionJugador || seleccionJugador < 1)
                    {
                        Console.WriteLine("Lo ingresado no es un número válido. Intenta de nuevo.");
                        validez = false;
                    }
                    else
                    {
                        validez = true;
                    }
                }
            } while (!validez);

            jugador = jugadores[seleccionJugador - 1];

            Console.WriteLine("Elegiste el personaje: ");
            Console.WriteLine(jugador.Dato.Nombre);
            Console.WriteLine("------------------------");
            Console.WriteLine("Estos son tus enemigos");
            fabricaDePersonajes.MostrarListaDePersonajes(enemigos, cantEnemigos, "ENEMIGO");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("QUE EMPIECE LA BATALLA");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");


            for (int i = 0; i < cantEnemigos; i++)
            {
                enemigo = enemigos[i];
                claseDuelo.InicioDeRondas(jugador, enemigo, i);

                input = Console.ReadLine();
                if (int.TryParse(input, out int estadoNumero))
                {
                    if (Enum.IsDefined(typeof(Posiciones), estadoNumero))
                    {
                        posicion1 = (Posiciones)estadoNumero;
                        Console.WriteLine($"{jugador.Dato.Apodo} decidió elegir una posición de tipo {posicion1}");
                    }
                }
                posicion2 = (Posiciones)rand.Next(1,4);

                Console.WriteLine($"{enemigo.Dato.Apodo} ha elegido una posición de {posicion2}");

                bool quienGana = claseDuelo.CompararPosiciones(posicion1, posicion2);
                if (quienGana)
                {
                    Console.ForegroundColor = ConsoleColor.Green;   
                    Console.WriteLine($"Superaste a {enemigo.Dato.Nombre} ¡Rápido! elige un conjuro ");
                    Console.ResetColor();
                    List<Movimiento> filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion1);
                    
                    for (int j = 0; j < cantMovimientos; j++)
                    {
                        Console.WriteLine($"{j+1}");
                        Console.WriteLine(filtrados[j]);
                    }
                    Console.WriteLine("Presiona el número del conjuro");    
                    input = Console.ReadLine();
                    if(int.TryParse(input, out int index))
                    {
                       Console.WriteLine($"Seleccionaste {filtrados[index-1].Hechizo}");
                    }
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;   
                    Console.WriteLine($"{enemigo.Dato.Nombre} te ha superado. Prepárate para recibir un ataque");
                }

                Console.ResetColor();
            }
        }



    }
}