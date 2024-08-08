using System;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioRondas;

namespace Espaciomensaje
{
    public class Mensaje
    {
        static void ImprimirMensajeDerecha(string mensaje)
        {
            int windowWidth = Console.WindowWidth;
            string nuevoMensaje = $"{mensaje}";
            int padding = windowWidth - nuevoMensaje.Length;
            if (padding > 0)
            {
                Console.WriteLine(new string(' ', padding) + nuevoMensaje);
            }
            else
            {
                Console.WriteLine(nuevoMensaje);
            }
        }
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
                Console.WriteLine($"||{i + 1}||");
                Console.WriteLine(lista[i]);
            }
        }
    }
}