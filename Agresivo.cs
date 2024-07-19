using System;

namespace EspacioMovimiento
{
    class Movimiento{
        private string? hechizo;
        private string? descripcion;
        private int danio;

        public string? Hechizo {get;set;}
        public string? Descripcion{get;set;}
        public int Danio{get;set;}

        public Movimiento(string hechizo, string descripcion, int danio)
        {
            this.hechizo = hechizo;
            this.descripcion = descripcion;
            this.danio = danio;
        }

    }
}