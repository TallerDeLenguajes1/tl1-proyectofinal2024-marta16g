using System;
using EspacioHistorial;
using EspacioHistorialJson;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPosiciones;
using EspacioRondas;
using Spectre.Console;


namespace EspacioDuelo
{
    public class Duelo
    {
        public static int ValidarEntrada(int min, int max)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int numero) && numero <= max && numero >= min)
                {
                    return numero;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Por favor no intente romper el juego e ingrese algo.");
                    }
                    else
                    {
                        Console.WriteLine("Por favor ingrese un número válido");
                    }
                }
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
        public static int TurnoJugador(Personaje jugador, int cantMovimientos, Posiciones posicion, int maxSalud)
        {
            var pregunta = true;
            do
            {
                var numero = Duelo.ValidarEntrada(1, cantMovimientos);
                if (numero != 0)
                {
                    if (posicion == Posiciones.Defensivo && numero == 1 && jugador.Caracteristica.Salud == maxSalud && pregunta)
                    {
                        Console.WriteLine("¿Estás seguro de utilizar este hechizo? Tienes 100 de salud, no hay daño que curar");
                        Console.WriteLine("Ingresa nuevamente la opción de conjuro que quieras");
                        pregunta = false;
                    }
                    else
                    {
                        return numero;
                    }
                }

            } while (true);
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
            Console.WriteLine();

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
            Console.WriteLine();
        }


        public static void PierdePersonaje(Personaje jugador, Personaje enemigo, int quien)
        {
            if (quien == 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"¡Oh no! {jugador.Dato.Nombre} fue derrotado por {enemigo.Dato.Nombre}");
                Console.ResetColor();
                Console.WriteLine($"Pierdes una vida");
                jugador.Caracteristica.Vidas--;
                Console.WriteLine($"Te queda/n {jugador.Caracteristica.Vidas}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"¡Derrotaste a {enemigo.Dato.Nombre}! ¡Sigue así!");
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                Console.ResetColor();
            }
        }

        public static bool PierdeTodasLasVidas(Personaje jugador)
        {
            ConsoleKeyInfo keyInfo = new();
            Console.WriteLine($"Parece que el poder de {jugador.Dato.Nombre} ha llegado a su fin. No queda más magia en él");
            while (true)
            {
                Console.WriteLine("¿Deseas jugar de nuevo?[y/n]");
                keyInfo = Console.ReadKey();
                Console.WriteLine();
                var caracter = keyInfo.KeyChar;
                if (caracter == 'Y' || caracter == 'y')
                {

                    return true;
                }

                if (caracter == 'N' || caracter == 'n')
                {
                    Console.WriteLine("Nos vemos pronto gran mago...");
                    return false;
                }
            }
        }

        public static void GanaJugador(int puntos, string archivoHistorial)
        {
            Historial ganador = new();
            HistorialJson historialjson = new();

            AnsiConsole.Write(
           new FigletText("¡Ganaste!")
        .Color(Color.Yellow1));
            Console.ResetColor();

            bool validez;
            do
            {
                Console.WriteLine("Ingrese su nombre o apodo (menos de 10 caracteres)");
                var input = Console.ReadLine();
                if (input.Length > 10)
                {
                    Console.WriteLine("El nombre no debe ser mayor a 10 caracteres");
                    validez = false;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("El nombre no debe ser vacío");
                        validez = false;
                    }
                    else
                    {
                        ganador.Participante = input;
                        ganador.Daniototal = puntos;
                        historialjson.GuardarGanador(ganador, archivoHistorial);
                        validez = true;
                    }
                }
            } while (!validez);



        }

    }
}