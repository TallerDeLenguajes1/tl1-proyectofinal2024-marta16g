using System;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioRondas;

namespace Espaciomensaje
{
    public class Mensaje
    {
        public static void ImprimirMensajeCentro(string mensaje)
        {
            int windowWidth = Console.WindowWidth;
            int padding = (windowWidth - mensaje.Length) / 2;
            if (padding > 0)
            {
                Console.WriteLine(new string(' ', padding) + mensaje);
            }
            else
            {
                Console.WriteLine(mensaje);
            }
        }
        public static void ImprimirMensajeDerecha(string mensaje)
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
                Console.WriteLine();
                ImprimirMensajeCentro("-------------------------------");
                ImprimirMensajeCentro($"{cuenta} RONDA");
                ImprimirMensajeCentro($"{jugador.Dato.Nombre} vs {enemigo.Dato.Nombre}");
                ImprimirMensajeCentro("-------------------------------");
                Console.WriteLine();
                Console.ResetColor();
                ImprimirMensajeDerecha($"Vidas: {jugador.Caracteristica.Vidas}");
            }
            else
            {
                Console.WriteLine("El valor de i no pertenece al rango de enum Rondas");
            }

        }

        public static void MostrarSalud(Personaje jugador, Personaje enemigo)
        {
            Console.WriteLine("----------");
            Console.WriteLine($"{enemigo.Dato.Nombre}");
            Console.WriteLine($"{enemigo.Caracteristica.Salud}%");
            Console.WriteLine("----------");
            ImprimirMensajeDerecha("----------");
            ImprimirMensajeDerecha($"{jugador.Dato.Nombre}");
            ImprimirMensajeDerecha($"{jugador.Caracteristica.Salud}%");
            ImprimirMensajeDerecha("----------");
        }
        public static void MostrarPosiciones()
        {
            Console.WriteLine("Elige tu posición");
            Console.WriteLine("1: AGRESIVO");
            Console.WriteLine("2: DEFENSIVO");
            Console.WriteLine("3: FURTIVO");
            ImprimirMensajeDerecha("Ingrese número (1, 2 o 3): ");
            Console.ResetColor();
        }
        public static void MostrarMovimientos(List<Movimiento> lista, int cantMovimientos)
        {
            for (int i = 0; i < cantMovimientos; i++)
            {
                Console.WriteLine($"||{i + 1}||");
                Console.WriteLine(lista[i]);
            }
            ImprimirMensajeDerecha("Presiona el número del conjuro (1, 2, 3 o 4)");
            Console.ResetColor();
        }
    }
}