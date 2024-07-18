using System;

namespace EspacioDato
{
    public class Dato
    {
        private Random Rand = new();
        private string? nombre;
        private string? apodo;
        private string? casa;
        private string? varita;
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public string? Casa { get => casa; set => casa = value; }
        public string? Varita { get => varita; set => varita = value; }


        public Dato(){}
        public Dato(string nombre, string apodo, string casa, string varita)
        {
            this.nombre = nombre;
            this.apodo = apodo;
            this.casa = casa;
            this.varita = varita;
        }

    }

}