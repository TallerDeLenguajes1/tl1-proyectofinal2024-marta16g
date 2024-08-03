using EspacioDuelo;
using EspacioFabricaDePersonajes;
using EspacioMovimientoJson;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPersonajesJS;
using EspacioPosiciones;

namespace EspacioJuego
{
    public class Juego
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const int cantJugadores = 3;
        private const int cantEnemigos = 10;
        private const int cantMovimientos = 4;
        private const int maxSalud = 100;
        private Duelo claseDuelo;
        private Movimiento claseMovimiento;
        private PersonajesJson personajesJson;
        private MovimientosJson movimientosJson;
        private FabricaDePersonajes fabricaDePersonajes;
        private List<Personaje> jugadores;
        private List<Personaje> enemigos;
        private List<Movimiento> movimientos;
        private List<Movimiento> filtrados;
        private Personaje jugador;
        private Personaje enemigo;
        private Movimiento movimientoSeleccionado;
        private int seleccionJugador;
        private Posiciones posicion1;
        private Posiciones posicion2;
        private int danioCalculado;
        private int saludJugador;
        private int saludEnemigo;
        private string? input;
        private int validez;
        private bool bandera;
        private bool otraBandera;
        private Random rand;


        public Juego()
        {
            claseDuelo = new Duelo();
            claseMovimiento = new Movimiento();
            personajesJson = new PersonajesJson();
            movimientosJson = new MovimientosJson();
            fabricaDePersonajes = new FabricaDePersonajes();
            jugadores = new List<Personaje>();
            enemigos = new List<Personaje>();
            movimientos = new List<Movimiento>();
            filtrados = new();
            jugador = new();
            enemigo = new();
            movimientoSeleccionado = new();
            rand = new();
        }

        public void Inicializar()
        {
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            enemigos = fabricaDePersonajes.GenerarPersonajesAleatorios();
            movimientos = movimientosJson.LeerMovimientos(archivoMovimientos);
            saludJugador = jugador.Caracteristica.Salud;
            saludEnemigo = enemigo.Caracteristica.Salud;
            bandera = true;
            otraBandera = false;
            validez = 0;
        }
        public void Jugar()
        {
            Inicializar();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Bienvenido al Juego de Harry Potter: Duelo de varitas");
            Console.WriteLine("Seleccione el personaje para jugar");
            fabricaDePersonajes.MostrarListaDePersonajes(jugadores, cantJugadores, "PERSONAJE");
            do
            {
                input = Console.ReadLine();
                seleccionJugador = claseDuelo.ValidarEntrada(input, 1, 3);
            } while (seleccionJugador == 0);


            jugador = jugadores[seleccionJugador - 1];

            Console.WriteLine("Elegiste el personaje: ");
            Console.WriteLine(jugador.Dato.Nombre);
            Console.WriteLine("------------------------");
            Console.WriteLine("Estos son tus enemigos");
            fabricaDePersonajes.MostrarListaDePersonajes(enemigos, cantEnemigos, "ENEMIGO");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");
            Console.WriteLine("QUE EMPIECE LA BATALLA");
            Console.WriteLine("------------------------");
            Console.WriteLine("------------------------");


            for (int i = 0; i < cantEnemigos; i++)
            {
                bandera = true;
                enemigo = enemigos[i];
                claseDuelo.InicioDeRondas(jugador, enemigo, i);
                Console.WriteLine($"Vidas: {jugador.Caracteristica.Vidas}");

                do
                {
                    jugador.Caracteristica.Salud = saludJugador;
                    enemigo.Caracteristica.Salud = saludEnemigo;
                    Console.WriteLine($"Salud: {jugador.Caracteristica.Salud}");

                    claseDuelo.MostrarPosiciones();

                    do
                    {
                        input = Console.ReadLine();
                        validez = claseDuelo.ValidarEntrada(input, 1, 3);
                    } while (validez == 0);
                    posicion1 = (Posiciones)validez;
                    posicion2 = (Posiciones)rand.Next(1, 4);

                    Console.WriteLine($"{jugador.Dato.Apodo} decidió elegir una posición de tipo {posicion1}");
                    Console.WriteLine($"{enemigo.Dato.Apodo} ha elegido una posición de {posicion2}");

                    int quienGana = Duelo.CompararPosiciones(posicion1, posicion2);

                    if (quienGana != 0)
                    {
                        if (quienGana == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{posicion1} vence a {posicion2}");
                            Console.WriteLine($"Tienes el movimiento ¡Rápido! elige un conjuro ");
                            Console.ResetColor();

                            filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion1);
                            claseDuelo.MostrarMovimientos(filtrados, cantMovimientos);

                            Console.WriteLine("Presiona el número del conjuro (1, 2, 3 o 4)");
                            input = Console.ReadLine();
                            do
                            {
                                input = Console.ReadLine();
                                validez = claseDuelo.ValidarEntrada(input, 1, cantMovimientos);
                            } while (validez == 0);

                            movimientoSeleccionado = filtrados[validez - 1];
                            Console.WriteLine($"Seleccionaste {movimientoSeleccionado.Hechizo}");
                            danioCalculado = claseDuelo.CalcularDanio(posicion1, movimientoSeleccionado, jugador);


                            if (movimientoSeleccionado.Persona == 1)
                            {
                                saludJugador += danioCalculado;
                                Console.WriteLine($"{jugador.Dato.Nombre} sana {danioCalculado} de vida");
                                jugador.Caracteristica.Salud = saludJugador;
                            }
                            else
                            {
                                saludEnemigo -= danioCalculado;
                                if (saludEnemigo < 0)
                                {
                                    saludEnemigo = 0;
                                }
                                Console.WriteLine($"{enemigo.Dato.Nombre} recibe {danioCalculado} de daño");
                                enemigo.Caracteristica.Salud = saludEnemigo;
                                Console.WriteLine($"Salud del enemigo: {enemigo.Caracteristica.Salud}");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{posicion2} vence a {posicion1}");
                            Console.WriteLine($"{enemigo.Dato.Nombre} tiene el movimiento ¡Prepárate para recibir un ataque!");
                            Console.ResetColor();
                            filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion2);
                            int randIndex = rand.Next(0, 4);
                            movimientoSeleccionado = filtrados[randIndex];
                            Console.WriteLine($"{enemigo.Dato.Nombre} ha utilizado {movimientoSeleccionado.Hechizo}");
                            danioCalculado = claseDuelo.CalcularDanio(posicion2, movimientoSeleccionado, enemigo);
                            saludJugador -= danioCalculado;
                            if (saludJugador < 0)
                            {
                                jugador.Caracteristica.Salud = 0;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Ambos magos optaron por la misma posición ¡Elige nuevamente!");
                        bandera = true;
                    }
                    if (saludEnemigo <= 0)
                    {
                        bandera = false;
                        saludJugador = maxSalud;
                        saludEnemigo = maxSalud;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine($"¡Derrotaste a {enemigo.Dato.Nombre}! ¡Sigue así!");
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Te queda/n {jugador.Caracteristica.Vidas} vida/s");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (saludJugador <= 0)
                        {
                            bandera = false;
                            saludJugador = maxSalud;
                            saludEnemigo = maxSalud;
                            Console.WriteLine($"¡Oh no! {jugador.Dato.Nombre} fue derrotado por {enemigo.Dato.Nombre}");
                            Console.WriteLine($"Pierdes una vida");
                            jugador.Caracteristica.Vidas--;
                            Console.WriteLine($"Vidas: {jugador.Caracteristica.Vidas}");
                            if (jugador.Caracteristica.Vidas == 0)
                            {
                                Console.WriteLine($"Parece que el poder de {jugador.Dato.Nombre} ha llegado a su fin. No queda más magia en él");
                                Console.WriteLine("¿Deseas jugar de nuevo?[y/n]");
                            }
                            else
                            {
                                bandera = true;
                                i--;
                                Console.WriteLine($"Deberás enfrentarte a {enemigo.Dato.Nombre} nuevamente");
                            }
                        }
                    }
                } while (bandera);

                Console.ResetColor();
            }
        }



    }
}