using EspacioDuelo;
using EspacioFabricaDePersonajes;
using EspacioMovimientoJson;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPersonajesJS;
using EspacioPosiciones;
using EspacioApi;
using EspacioHistorial;
using EspacioHistorialJson;

namespace EspacioJuego
{
    public class Juego
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const string archivoHistorial = "json/Historial.json";
        private const int cantJugadores = 3;
        private const int cantEnemigos = 2;
        private const int cantMovimientos = 4;
        private const int maxSalud = 100;
        private const int maxvidas = 3;
        private Movimiento claseMovimiento;
        private PersonajesJson personajesJson;
        private MovimientosJson movimientosJson;
        private HistorialJson historialJson;
        private FabricaDePersonajes fabricaDePersonajes;
        private List<Personaje> jugadores;
        private List<Personaje> enemigos;
        private List<Movimiento> movimientos;
        private List<Movimiento> filtrados;
        private Personaje jugador;
        private Personaje enemigo;
        private Historial ganador;
        private Movimiento movimientoSeleccionado;
        private int seleccionJugador;
        private Posiciones posicion1;
        private Posiciones posicion2;
        private int danioCalculado;
        private int saludJugador;
        private int saludEnemigo;
        private int contador;
        private int puntos;
        private string? input;
        private int validez;
        private bool jugar;
        private bool bandera;
        private bool pregunta;
        private Random rand;
        private ConsoleKeyInfo keyInfo;
        private char caracter;


        public Juego()
        {
            claseMovimiento = new Movimiento();
            personajesJson = new PersonajesJson();
            movimientosJson = new MovimientosJson();
            historialJson = new();
            fabricaDePersonajes = new();
            jugadores = new List<Personaje>();
            enemigos = new List<Personaje>();
            movimientos = new List<Movimiento>();
            filtrados = new();
            jugador = new();
            enemigo = new();
            ganador = new();
            movimientoSeleccionado = new();
            rand = new();
        }

        public void Inicializar()
        {
            movimientos = movimientosJson.LeerMovimientos(archivoMovimientos);
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            saludJugador = maxSalud;
            saludEnemigo = maxSalud;
            contador = 0;
            puntos = 0;
            jugar = false;
            bandera = true;
            pregunta = true;
            validez = 0;
        }
        public async Task Jugar()
        {
            do
            {
                Inicializar();
                if (PersonajesJson.ExisteArchivo(archivoPersonajes))
                {
                    enemigos = personajesJson.LeerPersonajes(archivoPersonajes);
                }
                else
                {
                    enemigos = fabricaDePersonajes.GenerarPersonajesAleatorios(cantEnemigos);
                    personajesJson.GuardarPersonajes(enemigos, archivoPersonajes);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Bienvenido al Juego de Harry Potter: Duelo de varitas");
                Console.WriteLine("Seleccione el personaje para jugar");
                FabricaDePersonajes.MostrarListaDePersonajes(jugadores, cantJugadores, "PERSONAJE");
                do
                {
                    input = Console.ReadLine();
                    seleccionJugador = Duelo.ValidarEntrada(input, 1, 3);
                } while (seleccionJugador == 0);


                jugador = jugadores[seleccionJugador - 1];

                Console.WriteLine("Elegiste el personaje: ");
                Console.WriteLine(jugador.Dato.Nombre);
                Console.WriteLine("------------------------");
                Console.WriteLine("Tus enemigos son:");
                FabricaDePersonajes.MostrarListaDePersonajes(enemigos, cantEnemigos, "ENEMIGO");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");
                Console.WriteLine("QUE EMPIECE LA BATALLA");
                Console.WriteLine("------------------------");
                Console.WriteLine("------------------------");


                await Api.ObtenerApi();

                for (int i = 0; i < cantEnemigos; i++)
                {
                    bandera = true;
                    enemigo = enemigos[i];
                    Duelo.InicioDeRondas(jugador, enemigo, i);

                    do
                    {
                        jugador.Caracteristica.Salud = saludJugador;
                        enemigo.Caracteristica.Salud = saludEnemigo;
                        Console.WriteLine($"Salud: {jugador.Caracteristica.Salud}");

                        Duelo.MostrarPosiciones();

                        do
                        {
                            input = Console.ReadLine();
                            validez = Duelo.ValidarEntrada(input, 1, 3);
                        } while (validez == 0);
                        posicion1 = (Posiciones)validez;
                        posicion2 = Posiciones.Agresivo;

                        Console.WriteLine($"{jugador.Dato.Apodo} decidió elegir una posición de tipo {posicion1}");
                        Console.WriteLine($"{enemigo.Dato.Apodo} ha elegido una posición de {posicion2}");

                        int quienGana = Duelo.CompararPosiciones(posicion1, posicion2, enemigo);

                        if (quienGana != 0)
                        {
                            if (quienGana == 1)
                            {
                                filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion1);
                                Duelo.MostrarMovimientos(filtrados, cantMovimientos);

                                do
                                {
                                    input = Console.ReadLine();
                                    validez = Duelo.ValidarEntrada(input, 1, cantMovimientos);

                                    if (posicion1 == Posiciones.Defensivo && validez == 1 && saludJugador == maxSalud && pregunta)
                                    {
                                        Console.WriteLine("¿Estás seguro de utilizar este hechizo? Tienes 100 de salud, no hay daño que curar");
                                        Console.WriteLine("Ingresa nuevamente la opción de conjuro que quieras");
                                        pregunta = false;
                                        validez = 0;
                                    }
                                } while (validez == 0);

                                movimientoSeleccionado = filtrados[validez - 1];
                                Console.WriteLine($"Seleccionaste {movimientoSeleccionado.Hechizo}");
                                danioCalculado = Duelo.CalcularDanio(posicion1, movimientoSeleccionado, jugador);

                                if (movimientoSeleccionado.Persona == 1)
                                {
                                    Duelo.SanarPersonaje(jugador, saludJugador, danioCalculado, maxSalud);
                                    saludJugador = jugador.Caracteristica.Salud;

                                }
                                else
                                {
                                    Duelo.AtacarPersonaje(enemigo, saludEnemigo, danioCalculado);
                                    saludEnemigo = enemigo.Caracteristica.Salud;
                                    puntos += danioCalculado;
                                }
                            }
                            else
                            {
                                filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion2);
                                int randIndex = rand.Next(0, 4);
                                movimientoSeleccionado = filtrados[randIndex];
                                Console.WriteLine($"{enemigo.Dato.Nombre} ha utilizado {movimientoSeleccionado.Hechizo}");
                                danioCalculado = Duelo.CalcularDanio(posicion2, movimientoSeleccionado, enemigo);
                                if (movimientoSeleccionado.Persona == 1)
                                {
                                    Duelo.SanarPersonaje(enemigo, saludEnemigo, danioCalculado, maxSalud);
                                    saludEnemigo = enemigo.Caracteristica.Salud;
                                }
                                else
                                {
                                    Duelo.AtacarPersonaje(jugador, saludJugador, danioCalculado);
                                    saludJugador = jugador.Caracteristica.Salud;
                                    puntos -= 10;
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine($"Ambos magos optaron por la misma posición ¡Elige nuevamente!");
                            Console.ResetColor();
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
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"¡Oh no! {jugador.Dato.Nombre} fue derrotado por {enemigo.Dato.Nombre}");
                                Console.ResetColor();
                                Console.WriteLine($"Pierdes una vida");
                                jugador.Caracteristica.Vidas--;
                                Console.WriteLine($"Vidas: {jugador.Caracteristica.Vidas}");
                                if (jugador.Caracteristica.Vidas == 0)
                                {
                                    i = cantEnemigos;
                                    Console.WriteLine($"Parece que el poder de {jugador.Dato.Nombre} ha llegado a su fin. No queda más magia en él");
                                    do
                                    {
                                        Console.WriteLine("¿Deseas jugar de nuevo?[y/n]");
                                        keyInfo = Console.ReadKey();
                                        Console.WriteLine();
                                        caracter = keyInfo.KeyChar;
                                        if (caracter == 'Y' || caracter == 'y')
                                        {
                                            jugar = true;
                                            validez = 1;
                                        }
                                        else
                                        {
                                            if (caracter == 'N' || caracter == 'n')
                                            {
                                                jugar = false;
                                                Console.WriteLine("Nos vemos gran mago");
                                                validez = 1;
                                            }
                                            else
                                            {
                                                validez = 0;
                                            }
                                        }

                                    } while (validez == 0);
                                }
                                else
                                {
                                    i--;
                                    Console.WriteLine($"Deberás enfrentarte a {enemigo.Dato.Nombre} nuevamente");
                                }
                            }
                        }
                    } while (bandera);

                    Console.ResetColor();
                    contador = i;
                }
                if (contador == cantEnemigos - 1 && jugador.Caracteristica.Vidas > 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ganaste capo");
                    Console.ResetColor();
                    jugar = false;
                    do
                    {
                        Console.WriteLine("Ingrese su nombre o apodo (menos de 10 caracteres)");
                        input = Console.ReadLine();
                        if (input.Length > 10)
                        {
                            Console.WriteLine("El nombre no debe ser mayor a 10 caracteres");
                            validez = 0;
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(input))
                            {
                                validez = 0;
                            }
                        }
                    } while (validez == 0);

                    ganador.Participante = input;
                    ganador.Daniototal = puntos;

                    historialJson.GuardarGanador(ganador, archivoHistorial);
                }
            } while (jugar);

            if (PersonajesJson.ExisteArchivo(archivoHistorial))
            {
                Console.WriteLine("LISTA DE GANADORES");
                var listaGanadores = historialJson.LeerGanadores(archivoHistorial);
                foreach (var item in listaGanadores)
                {
                    Console.WriteLine($"1: {item}");
                }
            }
        }



    }
}