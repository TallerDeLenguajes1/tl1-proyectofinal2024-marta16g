using System;
using EspacioDato;
using EspacioCaracteristica;

namespace EspacioPersonaje
{
    public class Personaje
    {
        Dato dato;
        Caracteristica caracteristica;

        public Personaje()
        {
            this.dato = new Dato();
            this.caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita)
        {
            this.dato = new Dato(nombre, apodo, casa, varita);
            this.caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita, int violencia, int resistencia, int discrecion)
        {
            this.dato = new Dato(nombre, apodo, casa, varita);
            this.caracteristica = new Caracteristica(violencia, resistencia, discrecion);
        }

        public string mostrarPersonaje()
        {
            return($"nombre: {dato.Nombre}");
        }
    }
   
}