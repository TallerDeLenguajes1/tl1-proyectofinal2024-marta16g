using System;
using EspacioDuelo;
using EspacioPosiciones;
namespace EspacioMovimiento
{
    public class Movimiento{
        private Posiciones posicion; 
        private string? hechizo;
        private string? descripcion;
        private int persona;
        private uint danio;

        public Posiciones Posicion {get;set;}
        public string? Hechizo {get;set;}
        public string? Descripcion{get;set;}
        public int Persona{get;set;}

        public uint Danio{get;set;}

        public Movimiento(Posiciones posicion, string hechizo, string descripcion, int persona, uint danio)
        {
            this.posicion = posicion;
            this.hechizo = hechizo;
            this.descripcion = descripcion;
            this.persona = persona;
            this.danio = danio;
        }

    }
}