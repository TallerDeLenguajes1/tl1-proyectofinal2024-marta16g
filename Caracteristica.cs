using System;

namespace EspacioCaracteristica
{
    public class Caracteristica()
    {
        private Random rand = new();
        private int violencia { get;}
        private int resistencia { get;}
        private int discrecion { get;}
        private int salud { get;}
        private int vidas { get;}

        public Caracteristica()
        {
            this.violencia = rand.Next(1,5);
            this.discrecion = rand.Next(1,5);
            this.resistencia = rand.Next(1,5);
            this.salud = 100;
            this.vidas = 3;
        }

    }
}