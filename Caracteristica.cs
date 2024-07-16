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
        public int Salud { get; } = 100;
        public int Vidas { get; } = 3;
        public Caracteristica()
        {
            this.violencia = rand.Next(1,5);
            this.resistencia = rand.Next(1,5);
            this.discrecion = rand.Next(1,5);

        }
        public Caracteristica(int violencia, int resistencia, int discrecion)
        {
            this.violencia = violencia;
            this.resistencia = resistencia;
            this.discrecion = discrecion;
        }

    }
}