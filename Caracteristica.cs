using System;

namespace EspacioCaracteristica
{
    public class Caracteristica
    {
        private static readonly Random rand = new();
        private int violencia;
        private int resistencia; 
        private int discrecion ;
        public int Violencia
        {
            get => violencia;
            set => violencia = value;
        }

        public int Resistencia
        {
            get => resistencia;
            set => resistencia = value;
        }

        public int Discrecion
        {
            get => discrecion;
            set => discrecion = value;
        }
        public int Salud { get; } = 100;
        public int Vidas { get; } = 3;
        public Caracteristica()
        {
            Violencia = rand.Next(1,6);
            Resistencia = rand.Next(1,6);
            Discrecion = rand.Next(1,6);

        }
        public Caracteristica(int violencia, int resistencia, int discrecion)
        {
            Violencia = violencia;
            Resistencia = resistencia;
            Discrecion = discrecion;
        }

    }
}