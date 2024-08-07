using System;

namespace EspacioHistorial
{
    public class Historial
    {
        private string? participante;
        private int puntos;
        public string? Participante { get => participante; set => participante = value; }
        public int Daniototal { get => puntos; set => puntos = value; }

        public Historial(){}
        public Historial(string participante, int danioTotal)
        {
            this.puntos = danioTotal;
            this.participante = participante;
        }
        public override string ToString()
        {
            return $"{this.participante} - {this.Daniototal}";
        }
    }
}