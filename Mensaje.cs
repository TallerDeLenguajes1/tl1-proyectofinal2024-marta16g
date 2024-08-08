using System;

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
    }
}