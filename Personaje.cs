using System;
using EspacioPersonajesJS;

namespace EspacioPersonaje
{
    public class Personaje
    {
        Dato dato;
        Caracteristica caracteristica;

        public Personaje(string nombre, string apodo, string casa, string varita)
        {
            this.datos = new Datos(nombre, apodo, casa, varita);
            this.caracteristicas = new Caracteristicas();
        }

    }
   
}