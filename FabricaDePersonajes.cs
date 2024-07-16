using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> personajes;        

        // private List<string> nombre = new List<string>
        // {
        //     "Cho Chang",
        //     "Draco Malfoy",
            
        // };
        public FabricaDePersonajes(int cantidadDePersonajes, string nombre, string apodo, string casa, string varita, int violencia, int resistencia, int discrecion)
        {
            personajes = new List<Personaje>(); 
            
            for (int i = 0; i < cantidadDePersonajes; i++)
            {
                var unPersonaje = new Personaje(nombre, apodo, casa, varita, violencia, resistencia, discrecion);
                personajes.Add(unPersonaje);
            }
        }
    }
}