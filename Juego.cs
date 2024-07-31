using System;
using EspacioPersonaje;
using EspacioPersonajesJS;

namespace EspacioJuego
{
    public class Juego()
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const int cantJugadores = 3;
        private const int cantPersonajes = 10;
        private int posicion1;
        private int posicion2;
        public void Jugar()
        {
            Console.WriteLine("Bienvenido al Juego de Harry Potter: Duelo de varitas");
            Console.WriteLine("Seleccione el personaje para jugar");

            List<Personaje> jugadores = new();
            PersonajesJson pruebaPersonajesJson = new();

            jugadores = pruebaPersonajesJson.LeerPersonajes(archivoJugadores);

            Personaje personjeCS = new() ;

            foreach (var jugador in jugadores)
            {
               string frase = personjeCS.MostrarPersonaje(jugador);
               Console.WriteLine(frase);
            }
        }

    }
}