using System;
using EspacioAtaque;
using EspacioPersonaje;
using EspacioPosiciones;


namespace EspacioDuelo
{
    public class Duelo
    {

        public bool compararPosiciones(Posiciones posicion1, Posiciones posicion2)
        {
            if(posicion1 == Posiciones.Defensivo && posicion2 == Posiciones.Agresivo
            || posicion1 == Posiciones.Agresivo && posicion2 == Posiciones.Furtivo
            || posicion1 == Posiciones.Furtivo && posicion2 == Posiciones.Defensivo)
            {
                return true;
            }else{
                return false;
            }
        }
        public void CalcularDanio(Ataque ataque, Personaje jugador)
        {
            string propiedadDestacada;
            int nivelPropiedadDestacada;

            if (!Enum.IsDefined(typeof(Posiciones), ataque.Posicion))
            {
                throw new ArgumentOutOfRangeException(nameof(ataque.Posicion), ataque.Posicion, "El valor no pertenece al rango del enum Posiciones");
            }

            switch (ataque.Posicion)
            {
                case Posiciones.Agresivo:
                    propiedadDestacada = "violencia";
                    nivelPropiedadDestacada = jugador.Caracteristica.Violencia;
                    break;
                case Posiciones.Defensivo:
                    propiedadDestacada = "resistencia";
                    nivelPropiedadDestacada = jugador.Caracteristica.Resistencia;
                    break;
                case Posiciones.Furtivo:
                    propiedadDestacada = "discreción";
                    nivelPropiedadDestacada = jugador.Caracteristica.Discrecion;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ataque.Posicion), ataque.Posicion, "El valor no pertenece al rango del enum Posiciones");
            }

            if (nivelPropiedadDestacada > 3)
            {
                Console.WriteLine($"¡{jugador.Dato.Nombre} tiene niveles de {propiedadDestacada} altos!");
            }
        }
    }
}