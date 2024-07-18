using System;
using EspacioDato;
using EspacioCaracteristica;

namespace EspacioPersonaje
{
    public class Personaje
    {
        public Dato Dato{get;set;}
        public Caracteristica Caracteristica{get;set;}
        
        public Personaje(int iNombre, int iApodo, int iCasa, int iVarita)
        {
            this.Dato = new Dato(iNombre, iApodo, iCasa, iVarita);
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
            return($"Nombre: {Dato.Nombre}\n Apodo: {Dato.Apodo}\n Casa: {Dato.Casa}\n Varita: {Dato.Varita} Violencia: {Caracteristica.Violencia}\n Resistencia: {Caracteristica.Resistencia}\n Discrecion: {Caracteristica.Discrecion}\n Salud: {Caracteristica.Salud}\n Vidas: {Caracteristica.Vidas}");
        }
    }
   
}