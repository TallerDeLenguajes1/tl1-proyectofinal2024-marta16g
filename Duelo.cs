using System;
using EspacioAtaque;
using EspacioPersonaje;


namespace EspacioDuelo
{
    public class Duelo
    {
        public int calcularDanio(Ataque ataque, Personaje jugador)
        {
            string propiedadDestacada;
            int nivelPropiedadDestacada;
            switch ((int)ataque.Posicion)
            {
                case 1:
                    propiedadDestacada = "violencia";
                    nivelPropiedadDestacada = jugador.Caracteristica.Violencia;
                    break;
                case 2:
                    propiedadDestacada = "resistencia";
                    nivelPropiedadDestacada = jugador.Caracteristica.Resistencia;
                    break;
                case 3:
                    propiedadDestacada = "discreción";
                    nivelPropiedadDestacada = jugador.Caracteristica.Discrecion;
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(ataque.Posicion), "El valor no pertenece al rango enum de Posiciones");
            }

            if(nivelPropiedadDestacada > 3)
            {
                Console.WriteLine($"¡{jugador.Dato.Nombre} tiene niveles de {propiedadDestacada} altos!");
            }
            return 1;
        }
    }
}