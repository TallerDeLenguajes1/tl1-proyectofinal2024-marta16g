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

        public override string ToString()
        {
            return $"Nombre: {this.Dato.Nombre}\n" +
            $"Apodo: {this.Dato.Apodo}\n" +
            $"Casa: {this.Dato.Casa}\n" +
            $"Varita: {this.Dato.Varita}\n" +
            $"Violencia: {this.Caracteristica.Violencia}\n" +
            $"Resistencia: {this.Caracteristica.Resistencia}\n" +
            $"Discrecion: {this.Caracteristica.Discrecion}\n" +
            $"Salud: {this.Caracteristica.Salud}\n" +
            $"Vidas: {this.Caracteristica.Vidas}";
        }
    }
   
}