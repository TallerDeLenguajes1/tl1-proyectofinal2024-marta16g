using System;
using EspacioPersonaje;


namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes()
    {
        List<Personaje> personajes = new();
        
        public FabricaDePersonajes(int cantidadDePersonajes, string nombre, string casa, string varita, int vidas)
        {
            for (int i = 0; i < cantidadDePersonajes; i++)
            {
                var unPersonaje = new Personaje(nombre, casa, varita, vidas);
                personajes.Add(unPersonaje);
            }
        }
    }
}