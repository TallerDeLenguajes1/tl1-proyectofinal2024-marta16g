using System;
using EspacioMovimiento;
using EspacioPosiciones;

namespace EspacioDuelo
{
    public class Duelo
    {
        private List<Movimiento> listaDeMovimientos = new();
        private Posiciones posicion;
        public List<Movimiento> ListaDeMovimientos
        {
            get => listaDeMovimientos; set
            {
                if (value == null) 
                { 
                    throw new ArgumentNullException(nameof(value), "La lista no puede estar vacía."); 
                }else
                {
                    listaDeMovimientos = value;
                }
            }
        }
        public Posiciones Posicion { get; set; }
    }
}