using System;
using EspacioDato;
using EspacioCaracteristica;

namespace EspacioPersonaje
{
    public class Personaje
    {
        Dato dato;
        Caracteristica caracteristica;
        public Personaje(string nombre, string apodo, string casa, string varita, int vidas)
        {
            this.dato = new Dato(nombre, apodo, casa, varita);
            this.caracteristica = new Caracteristica(vidas);
        }
    }
   
}