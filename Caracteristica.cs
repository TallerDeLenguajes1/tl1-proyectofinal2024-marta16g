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
        public int Violencia { get => violencia; }
        public int Resistencia { get => resistencia; }
        public int Discrecion { get => discrecion; }
        public int Salud { get => salud; }
        public int Vidas { get => vidas; }

        public Caracteristica()
        {
            this.violencia = rand.Next(1,5);
            this.resistencia = rand.Next(1,5);
            this.discrecion = rand.Next(1,5);
            this.salud = 100;
            this.vidas = 3;
        }

    }
}