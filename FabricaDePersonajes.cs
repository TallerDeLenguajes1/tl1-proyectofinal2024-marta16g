using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {
        private List<Personaje> personajes;        

        private List<string> nombres = new List<string>
        {
            "Cho Chang",
            "Draco Malfoy",
            "Severus Snape",
            "Luna Lovegood",
            "Ginny Weasley",
            "Sirius black",
            "Bellatrix Lestrange",
            "Albus Dumbledore",
            "Seamus Finnigan",
            "Lavender Brown",
            "Minerva McGonagall",
            "Lucius Malfoy",
            "Neville Longbottom",
            "Dolores Umbridge",
            "George Weasley",
            "Fred Weasley",
            "Fleur Delacour",
            "Nymphadora Tonks"
        };

        private List<string> varitas = new List<string>
        {
            "Cerezo y pelos de Veela",
            "Pino y bigotes de trol",
            "Roble y pelo de gato Wampus",
            "Cedro y pelo de cola de unicornio",
            "Acebo y Coral",
            "Cedro y plumas de cola de ave del trueno",
            "Cerezo y pluma de cola de ave Fénix",
            "Arce y pelo de rougarou",
            "Cedro y fibra de corazón de dragón",
            "Roble y pelo de Veela",
            "Acebo y pelo de kelpie",
            "Arce y pelo de cola de thestral",
            "Pino y pelo de gato Wampus"
        };

        
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