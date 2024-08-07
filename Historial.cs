using System;

namespace EspacioHistorial
{
    public class EspacioHistorial
    {
        private string participante;
        private int puntos;
        public string Participante { get => participante; set => participante = value; }
        public int Daniototal { get => puntos; set => puntos = value; }

        public EspacioHistorial(string participante, int danioTotal)
        {
            this.puntos = danioTotal;
            this.participante = participante;
        }
    }
}