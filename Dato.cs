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
        public string? Nombre
        {
            get => nombre;
            set
            {
                nombre = value ?? throw new ArgumentNullException(nameof(value), "El nombre no puede ser nulo.");
            }
        }
        public string? Apodo
        {
            get => apodo;
            set
            {
                apodo = value ?? throw new ArgumentNullException(nameof(value), "El apodo no puede ser nulo.");
            }
        }
        public string? Casa
        {
            get => casa; set
            {
                casa = value ?? throw new ArgumentNullException(nameof(value), "La casa no puede ser nula.");
            }
        }
        public string? Varita
        {
            get => varita; set
            {
                varita = value ?? throw new ArgumentNullException(nameof(value), "La varita no puede ser nula.");
            }
        }


        public Dato() { }
        public Dato(string nombre, string apodo, string casa, string varita)
        {
            this.nombre = nombre;
            this.apodo = apodo;
            this.casa = casa;
            this.varita = varita;
        }

    }

}