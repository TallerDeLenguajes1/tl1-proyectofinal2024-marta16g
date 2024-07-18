using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> personajes;

        public FabricaDePersonajes()
        {
            personajes = new List<Personaje>();

            for (int i = 0; i < 10; i++)
            {
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