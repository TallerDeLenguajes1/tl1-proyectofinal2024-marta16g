using System;
using EspacioDuelo;
using EspacioPosiciones;
namespace EspacioMovimiento
{
    class Movimiento{
        private Posiciones posicion; 
        private string? hechizo;
        private string? descripcion;
        private int danio;

        public Posiciones Posicion {get;set;}
        public string? Hechizo {get;set;}
        public string? Descripcion{get;set;}
        public int Danio{get;set;}

        public Movimiento(Posiciones posicion, string hechizo, string descripcion, int danio)
        {
            this.posicion = posicion;
            this.hechizo = hechizo;
            this.descripcion = descripcion;
            this.danio = danio;
        }

    }
}