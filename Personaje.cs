using System;
using EspacioDato;
using EspacioCaracteristica;

namespace EspacioPersonaje
{
    public class Personaje
    {
        private Dato? dato;
        private Caracteristica? caracteristica;
        public Dato? Dato{ get => dato; set => dato = value; }
        public Caracteristica? Caracteristica{ get => caracteristica; set => caracteristica = value; }
        
        public Personaje()
        {
            Dato = new Dato();
            Caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita)
        {
            Dato = new Dato(nombre, apodo, casa, varita);
            Caracteristica = new Caracteristica();
        }
        public Personaje(string nombre, string apodo, string casa, string varita, int violencia, int resistencia, int discrecion, int salud, int vidas)
        {
            Dato = new Dato(nombre, apodo, casa, varita);
            Caracteristica = new Caracteristica(violencia, resistencia, discrecion, salud, vidas);
        }

        public override string ToString()
        {
            return $"Nombre: {dato.Nombre}\n" +
            $"Apodo: {dato.Apodo}\n" +
            $"Casa: {dato.Casa}\n" +
            $"Varita: {dato.Varita}\n" +
            $"Violencia: {caracteristica.Violencia}\n" +
            $"Resistencia: {caracteristica.Resistencia}\n" +
            $"Discrecion: {caracteristica.Discrecion}\n" +
            $"Salud: {caracteristica.Salud}\n" +
            $"Vidas: {caracteristica.Vidas}";
        }
    }
   
}