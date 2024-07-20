using System;
using EspacioMovimiento;
using EspacioPosiciones;

namespace EspacioAtaque
{
    public class Ataque
    {
        private Posiciones posicion;
        private Movimiento movimiento;
        public Posiciones Posicion { get; set; }
        public Movimiento Movimiento
        {
            get => movimiento; set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "El movimiento no debe ser nulo");

                }
                movimiento = value;
                
            }
        }

        public Ataque (Posiciones posicion, Movimiento movimiento)
        {
            this.posicion = posicion;
            this.movimiento = movimiento;
        }


    }
}