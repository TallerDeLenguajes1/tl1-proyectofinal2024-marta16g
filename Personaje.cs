using System;
using EspacioDato;
using EspacioCaracteristica;

namespace EspacioPersonaje
{
    public class Personaje
    {
        public Dato Dato{get;set;}
        public Caracteristica Caracteristica{get;set;}
        
        public Personaje()
        {
            this.Dato = new Dato();
            this.Caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita)
        {
            this.Dato = new Dato(nombre, apodo, casa, varita);
            this.Caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita, int violencia, int resistencia, int discrecion)
        {
            this.Dato = new Dato(nombre, apodo, casa, varita);
            this.Caracteristica = new Caracteristica(violencia, resistencia, discrecion);
        }

        public string mostrarPersonaje()
        {
            return($"nombre: {Dato.Nombre}, violencia: {Caracteristica.Violencia}, salud: {Caracteristica.Salud}");
        }
    }
   
}