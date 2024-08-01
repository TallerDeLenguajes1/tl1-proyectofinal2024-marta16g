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
        private const int cantPersonajes = 10;
        private Personaje clasePersonaje;
        private Duelo claseDuelo;
        private PersonajesJson personajesJson;
        private MovimientosJson movimientosJson;
        private Posiciones posiciones;
        private FabricaDePersonajes fabricaDePersonajes;
        private List<Personaje> jugadores;
        private List<Personaje> enemigos;
        private Personaje jugador;
        private Personaje contrincante;
        private string? input;
        private bool validez;
        private int seleccionJugador;
        private int posicion1;
        private int posicion2;


        public Juego()
        {
            clasePersonaje = new Personaje();
            claseDuelo = new Duelo();
            personajesJson = new PersonajesJson();
            movimientosJson = new MovimientosJson();
            posiciones = new Posiciones();
            fabricaDePersonajes = new FabricaDePersonajes();
            jugadores = new List<Personaje>();
            enemigos = new List<Personaje>();
        }

        public void Inicializar()
        {
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            enemigos = fabricaDePersonajes.GenerarPersonajesAleatorios();
            validez = false;
        }
        public void Jugar()
        {
            Console.WriteLine("Bienvenido al Juego de Harry Potter: Duelo de varitas");
            do
            {
                Console.WriteLine("Seleccione el personaje para jugar");
                Inicializar();

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

            jugador = jugadores[seleccionJugador-1];

            Console.WriteLine("Elegiste el personaje: ");
            Console.WriteLine(jugador.Dato.Nombre);
            Console.WriteLine("------------------------");

            fabricaDePersonajes.MostrarListaDePersonajes(enemigos, 10, "ENEMIGO");







        }

    }
}