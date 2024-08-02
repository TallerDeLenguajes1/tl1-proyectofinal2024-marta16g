using System;

namespace EspacioCaracteristica
{
    public class Caracteristica
    {
        private static readonly Random rand = new();
        private int violencia;
        private int resistencia;
        private int discrecion;
        private int salud;
        private int vidas;
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
        public int Salud
        {
            get => salud;
            set => salud = value;
        }
        public int Vidas
        {
            get => vidas;
            set => vidas = value;
        }
        public Caracteristica()
        {
            Violencia = rand.Next(1, 6);
            Resistencia = rand.Next(1, 6);
            Discrecion = rand.Next(1, 6);
            Salud = 100;
            Vidas = 3;

        }
        public Caracteristica(int violencia, int resistencia, int discrecion, int salud, int vidas)
        {
            Violencia = violencia;
            Resistencia = resistencia;
            Discrecion = discrecion;
            Salud = salud;
            Vidas = vidas;
        }

    }
}