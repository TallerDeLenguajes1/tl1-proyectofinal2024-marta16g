using System;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPosiciones;
using EspacioRondas;


namespace EspacioDuelo
{
    public class Duelo
    {
        public static void InicioDeRondas(Personaje jugador, Personaje enemigo, int i)
        {
            if (Enum.IsDefined(typeof(Rondas), i))
            {
                Rondas cuenta = (Rondas)i;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("-------------------");
                Console.WriteLine($"{cuenta} RONDA");
                Console.WriteLine($"{jugador.Dato.Nombre} vs {enemigo.Dato.Nombre}");
                Console.WriteLine("-------------------");
                Console.ResetColor();
                Console.WriteLine($"Vidas: {jugador.Caracteristica.Vidas}");
            }
            else
            {
                Console.WriteLine("El valor de i no pertenece al rango de enum Rondas");
            }

        }
        public static int CompararPosiciones(Posiciones posicion1, Posiciones posicion2, Personaje mago)
        {
            if (posicion1 == posicion2)
            {
                return 0;
            }
            else
            {
                if (posicion1 == Posiciones.Defensivo && posicion2 == Posiciones.Agresivo
                || posicion1 == Posiciones.Agresivo && posicion2 == Posiciones.Furtivo
                || posicion1 == Posiciones.Furtivo && posicion2 == Posiciones.Defensivo)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{posicion1} vence a {posicion2}");
                    Console.WriteLine($"Tienes el movimiento ¡Rápido! elige un conjuro ");
                    Console.ResetColor();
                    Console.WriteLine("Presiona el número del conjuro (1, 2, 3 o 4)");

                    return 1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{posicion2} vence a {posicion1}");
                    Console.WriteLine($"{mago.Dato.Nombre} tiene el movimiento ¡Prepárate para recibir un ataque!");
                    Console.ResetColor();
                    return 2;
                }

            }
        }
        public static int CalcularDanio(Posiciones posicion, Movimiento movimiento, Personaje jugador)
        {
            string propiedadDestacada;
            int nivelPropiedadDestacada;
            int incremento;
            int danioFinal;


            if (!Enum.IsDefined(typeof(Posiciones), posicion))
            {
                Console.WriteLine("ERROR: La posición no es válida para el enum Posiciones");
            }

            switch (posicion)
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
                    throw new ArgumentOutOfRangeException(nameof(posicion), posicion, "El valor no pertenece al rango del enum Posiciones");
            }

            if (nivelPropiedadDestacada > 3)
            {
                Console.WriteLine($"¡{jugador.Dato.Nombre} tiene niveles de {propiedadDestacada} altos!");
                incremento = 2 * nivelPropiedadDestacada;
                danioFinal = movimiento.Danio + incremento;
                return danioFinal;
            }
            else
            {
                return movimiento.Danio;
            }
        }

        public static void AtacarPersonaje(Personaje personaje, int saludPersonaje, int danioCalculado)
        {
            saludPersonaje -= danioCalculado;
            if (saludPersonaje < 0)
            {
                saludPersonaje = 0;
            }
            Console.WriteLine($"{personaje.Dato.Nombre} recibe {danioCalculado} de daño");
            personaje.Caracteristica.Salud = saludPersonaje;
            Console.WriteLine($"Salud de {personaje.Dato.Nombre}: {personaje.Caracteristica.Salud}");
        }

        public static void SanarPersonaje(Personaje personaje, int saludPersonaje, int danioCalculado, int maxSalud)
        {

            saludPersonaje += danioCalculado;
            if (saludPersonaje > maxSalud)
            {
                int auxDanio = maxSalud - personaje.Caracteristica.Salud;
                saludPersonaje = maxSalud;
                Console.WriteLine($"{personaje.Dato.Nombre} sana {auxDanio} de vida");
            }
            else
            {
                Console.WriteLine($"{personaje.Dato.Nombre} sana {danioCalculado} de vida");
            }
            personaje.Caracteristica.Salud = saludPersonaje;
            Console.WriteLine($"Salud de {personaje.Dato.Nombre}: {personaje.Caracteristica.Salud}");

        }
        public static int ValidarEntrada(string? input, int min, int max)
        {
            if (int.TryParse(input, out int numero) && numero <= max && numero >= min)
            {
                return numero;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Por favor no intente romper el juego e ingrese algo.");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Por favor ingrese un número válido");
                    return 0;
                }
            }
        }

        public static void MostrarPosiciones()
        {
            Console.WriteLine("Elige tu posición");
            Console.WriteLine("1: AGRESIVO");
            Console.WriteLine("2: DEFENSIVO");
            Console.WriteLine("3: FURTIVO");
            Console.WriteLine("Ingrese número (1, 2 o 3): ");
        }

        public static void MostrarMovimientos(List<Movimiento> lista, int cantMovimientos)
        {
            for (int i = 0; i < cantMovimientos; i++)
            {
                Console.WriteLine($"{i + 1}");
                Console.WriteLine(lista[i]);
            }
        }
    }
}