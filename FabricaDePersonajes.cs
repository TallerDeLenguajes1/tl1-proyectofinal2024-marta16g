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
                int nombreYApodoLength = 20;
                int casaLength = 4;
                int varitaLength = 13;

                int iNombre = Rand.Next(nombreYApodoLength);
                int iApodo = Rand.Next(nombreYApodoLength);
                int iCasa = Rand.Next(casaLength);
                int iVarita = Rand.Next(varitaLength);

                var unPersonaje = new Personaje(iNombre, iApodo, iCasa, iVarita);
                personajes.Add(unPersonaje);

                nombreYApodoLength--;
                casaLength--;
                varitaLength--;

            }
        }

        public Personaje devolverUnPersonaje(int eleccion)
        {
            return personajes[eleccion-1];
        }
    }
}