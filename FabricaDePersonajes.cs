using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> personajes;        
        public FabricaDePersonajes(int cantidadDePersonajes, string nombre, string apodo, string casa, string varita)
        {
            personajes = new List<Personaje>(); 
            
            for (int i = 0; i < cantidadDePersonajes; i++)
            {
                var unPersonaje = new Personaje(nombre, apodo, casa, varita);
                personajes.Add(unPersonaje);
            }
        }
    }
}