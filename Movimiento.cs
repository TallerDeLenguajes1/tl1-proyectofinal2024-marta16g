using System;
using EspacioPosiciones;
namespace EspacioMovimiento
{
    public class Movimiento
    {
        private Posiciones posicion;
        private string? hechizo;
        private string? descripcion;
        private int persona;
        private int danio;

        public Posiciones Posicion{ get => posicion; set => posicion = value; }
        public string? Hechizo { get => hechizo; set => hechizo = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Persona { get => persona; set => persona = value; }
        public int Danio { get => danio; set => danio = value; }

        public Movimiento(){}
        public Movimiento(Posiciones posicion, string hechizo, string descripcion, int persona, int danio)
        {
            this.posicion = posicion;
            this.hechizo = hechizo;
            this.descripcion = descripcion;
            this.persona = persona;
            this.danio = danio;
        }

        public override string ToString()
        {
            return $"{Hechizo}: {Descripcion}";
        }

        public List<Movimiento> FiltrarMovimientos(List<Movimiento> movimientos, Posiciones posicion)
        {
            return movimientos.Where(m => m.Posicion == posicion).ToList();
        }

    }
}