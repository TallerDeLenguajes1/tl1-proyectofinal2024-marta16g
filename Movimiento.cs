using System;
using EspacioPosiciones;
namespace EspacioMovimiento
{
    public class Movimiento
    {
        private Posiciones posicion;
        private string hechizo;
        private string descripcion;
        private int persona;
        private int danio;

        public Posiciones Posicion { get; set; }
        public string Hechizo { get; set; }
        public string Descripcion { get; set; }
        public int Persona { get; set; }

        public int Danio { get; set; }

        public Movimiento() {
            Posicion = Posiciones.Agresivo;
            Hechizo = string.Empty;
            Descripcion = string.Empty;
            Persona = 2;
            Danio = 10;

         }
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
            return movimientos.Where(m=> m.Posicion == posicion).ToList();
        }

    }
}