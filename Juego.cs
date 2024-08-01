using System;
using EspacioDuelo;
using EspacioFabricaDePersonajes;
using EspacioMovimientoJson;
using EspacioPersonaje;
using EspacioPersonajesJS;
using EspacioPosiciones;

namespace EspacioJuego
{
    public class Juego
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const int cantJugadores = 3;
        private const int cantEnemigos = 10;
        private Duelo claseDuelo;
        private PersonajesJson personajesJson;
        private MovimientosJson movimientosJson;
        private Posiciones enumPosiciones;
        private FabricaDePersonajes fabricaDePersonajes;
        private List<Personaje> jugadores;
        private List<Personaje> enemigos;
        private Personaje jugador;
        private Personaje enemigo;
        private string? input;
        private bool validez;
        private int seleccionJugador;
        private Posiciones posicion1;
        private Posiciones posicion2;
        private Random rand;


        public Juego()
        {
            claseDuelo = new Duelo();
            personajesJson = new PersonajesJson();
            movimientosJson = new MovimientosJson();
            enumPosiciones = new Posiciones();
            fabricaDePersonajes = new FabricaDePersonajes();
            jugadores = new List<Personaje>();
            enemigos = new List<Personaje>();
            jugador = new();
            enemigo = new();
            rand = new();
        }

        public void Inicializar()
        {
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            enemigos = fabricaDePersonajes.GenerarPersonajesAleatorios();
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
        }
            

            input = Console.ReadLine();
            if (int.TryParse(input, out int estadoNumero))
            {
                if (Enum.IsDefined(typeof(Posiciones), estadoNumero))
                {
                    posicion1 = (Posiciones)estadoNumero;
                    Console.WriteLine($"La posición del personaje es: {posicion1}");
                }
            }
                posicion2 = Posiciones.Defensivo;

                bool quienGana = claseDuelo.CompararPosiciones(posicion1, posicion2);
                if(quienGana)
                {
                    Console.WriteLine($"{jugador.Dato.Nombre} tiene la jugada");
                }else{
                    Console.WriteLine($"{enemigos[0].Dato.Nombre} tiene la jugada");
                }
            }

        }
    }