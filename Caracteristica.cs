using System;

namespace EspacioCaracteristica
{
    public class Caracteristica
    {
        private Random rand = new();
        private int violencia;
        private int resistencia; 
        private int discrecion ;
        private int salud;
        private int vidas;
        public int Violencia { get;set; }
        public int Resistencia { get;set; }
        public int Discrecion { get;set; }
        public int Salud { get;set;} = 100;
        public int Vidas { get;set; } = 3;

        public Caracteristica(int violencia, int resistencia, int discrecion)
        {
            this.violencia = violencia;
            this.resistencia = resistencia;
            this.discrecion = discrecion;
            this.salud = 100;
            this.vidas = 3;
        }

    }
}