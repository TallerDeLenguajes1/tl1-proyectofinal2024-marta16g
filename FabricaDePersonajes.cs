using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {

        private Random Rand = new();
        private List<Personaje> personajes;

        public FabricaDePersonajes()
        {
            personajes = new List<Personaje>();

            for (int i = 0; i < 10; i++)
            {
                int iNombreYApodo = Rand.Next(20);
                int iVarita = Rand.Next(13);
                int iCasa = Rand.Next(4);

                var unPersonaje = new Personaje();
                personajes.Add(unPersonaje);
                

            }
        }

        public Personaje devolverUnPersonaje(int eleccion)
        {
            return personajes[eleccion-1];
        }
    }
}