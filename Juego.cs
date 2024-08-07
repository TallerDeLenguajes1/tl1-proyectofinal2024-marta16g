using EspacioDuelo;
using EspacioFabricaDePersonajes;
using EspacioMovimientoJson;
using EspacioMovimiento;
using EspacioPersonaje;
using EspacioPersonajesJS;
using EspacioPosiciones;
using EspacioApi;
using EspacioHistorialJson;
using Spectre.Console;
using Espaciomensaje;

namespace EspacioJuego
{
    public class Juego
    {
        private const string archivoJugadores = "json/Jugadores.json";
        private const string archivoPersonajes = "json/Personajes.json";
        private const string archivoMovimientos = "json/Movimientos.json";
        private const string archivoHistorial = "json/Historial.json";
        private const int cantJugadores = 3;
        private const int cantEnemigos = 10;
        private const int cantMovimientos = 4;
        private const int maxSalud = 100;
        private Movimiento claseMovimiento = new();
        private PersonajesJson personajesJson = new();
        private MovimientosJson movimientosJson = new();
        private HistorialJson historialJson = new();
        private FabricaDePersonajes fabricaDePersonajes = new();
        private List<Personaje> jugadores = new();
        private List<Personaje> enemigos = new();
        private List<Movimiento> movimientos = new();
        private List<Movimiento> filtrados = new();
        private Personaje jugador = new();
        private Personaje enemigo = new();
        private Movimiento movimientoSeleccionado = new();
        private Posiciones posicion1;
        private Posiciones posicion2;
        private Random rand = new();
        private int seleccionJugador;
        private int danioCalculado;
        private int contador;
        private int puntos;
        private int numero;
        private bool jugar;
        private bool bandera;

        public void Inicializar()
        {
            movimientos = movimientosJson.LeerMovimientos(archivoMovimientos);
            jugadores = personajesJson.LeerPersonajes(archivoJugadores);
            contador = 0;
            puntos = 0;
            jugar = false;
            bandera = true;
            numero = 0;
        }
        public async Task Jugar()
        {
            AnsiConsole.Write(
           new FigletText("Duelo Mágico")
           .Centered()
        .Color(Color.Red));
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
                Console.WriteLine("SELECCIONE UN PERSONAJE PARA JUGAR:");
                Console.WriteLine();
                FabricaDePersonajes.MostrarListaDePersonajes(jugadores, cantJugadores, "PERSONAJE");
                Mensaje.ImprimirMensajeDerecha("Apriete 1, 2 o 3");

                seleccionJugador = Duelo.ValidarEntrada(1, 3);
                jugador = jugadores[seleccionJugador - 1];

                Console.WriteLine("Elegiste el personaje: ");
                Console.WriteLine(jugador.Dato.Nombre);
                Console.WriteLine("------------------------");
                Console.WriteLine("TTUS ENEMIGOS:");
                Console.WriteLine();
                FabricaDePersonajes.MostrarListaDePersonajes(enemigos, cantEnemigos, "ENEMIGO");
                AnsiConsole.Write(
           new FigletText("Que empiece la batalla")
           .Centered()
        .Color(Color.Cyan1));

                await Api.ObtenerApi();

                for (int i = 0; i < cantEnemigos; i++)
                {
                    bandera = true;
                    enemigo = enemigos[i];
                    Mensaje.InicioDeRondas(jugador, enemigo, i);
                    jugador.Caracteristica.Salud = maxSalud;
                    enemigo.Caracteristica.Salud = maxSalud;

                    do
                    {
                        Mensaje.MostrarSalud(jugador, enemigo);
                        Mensaje.MostrarPosiciones();
                        numero = Duelo.ValidarEntrada(1, 3);

                        posicion1 = (Posiciones)numero;
                        posicion2 = (Posiciones)rand.Next(1, 4);

                        Mensaje.ImprimirMensajeDerecha($"{jugador.Dato.Apodo} decidió elegir una posición de tipo {posicion1}");
                        Console.WriteLine($"{enemigo.Dato.Apodo} ha elegido una posición de tipo {posicion2}");

                        int quienGana = Duelo.CompararPosiciones(posicion1, posicion2, enemigo);

                        if (quienGana != 0)
                        {
                            if (quienGana == 1)
                            {
                                filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion1);
                                Mensaje.MostrarMovimientos(filtrados, cantMovimientos);
                                int index = Duelo.TurnoJugador(jugador, cantMovimientos, posicion1, maxSalud);

                                movimientoSeleccionado = filtrados[index - 1];
                                Mensaje.ImprimirMensajeDerecha($"Seleccionaste {movimientoSeleccionado.Hechizo}");
                                danioCalculado = Duelo.CalcularDanio(posicion1, movimientoSeleccionado, jugador);

                                if (movimientoSeleccionado.Persona == 1)
                                {
                                    Duelo.SanarPersonaje(jugador, jugador.Caracteristica.Salud, danioCalculado, maxSalud);
                                }
                                else
                                {
                                    Duelo.AtacarPersonaje(enemigo, enemigo.Caracteristica.Salud, danioCalculado);
                                    puntos += danioCalculado;
                                }
                            }
                            else
                            {
                                filtrados = claseMovimiento.FiltrarMovimientos(movimientos, posicion2);
                                int randIndex = rand.Next(0, cantMovimientos);
                                movimientoSeleccionado = filtrados[randIndex];
                                Console.WriteLine($"{enemigo.Dato.Nombre} ha utilizado {movimientoSeleccionado.Hechizo}");
                                danioCalculado = Duelo.CalcularDanio(posicion2, movimientoSeleccionado, enemigo);
                                if (movimientoSeleccionado.Persona == 1)
                                {
                                    Duelo.SanarPersonaje(enemigo, enemigo.Caracteristica.Salud, danioCalculado, maxSalud);
                                }
                                else
                                {
                                    Duelo.AtacarPersonaje(jugador, jugador.Caracteristica.Salud, danioCalculado);
                                    puntos -= 10;
                                }
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Mensaje.ImprimirMensajeCentro($"Ambos magos optaron por la misma posición ¡Elige nuevamente!");
                            Console.ResetColor();
                        }
                        if (enemigo.Caracteristica.Salud <= 0)
                        {
                            bandera = false;
                            Duelo.PierdePersonaje(jugador, enemigo, 2);
                        }

                        if (jugador.Caracteristica.Salud <= 0)
                        {
                            bandera = false;
                            Duelo.PierdePersonaje(jugador, enemigo, 1);

                            if (jugador.Caracteristica.Vidas == 0)
                            {
                                i = cantEnemigos;
                                jugar = Duelo.PierdeTodasLasVidas(jugador);
                            }
                            else
                            {
                                i--;
                                Console.WriteLine($"Deberás enfrentarte a {enemigo.Dato.Nombre} nuevamente");
                            }
                        }
                    } while (bandera);

                    Console.ResetColor();
                    contador = i;
                }
                if (contador == cantEnemigos - 1 && jugador.Caracteristica.Vidas > 0)
                {
                    Duelo.GanaJugador(puntos, archivoHistorial);
                    jugar = false;
                }
            } while (jugar);

            if (PersonajesJson.ExisteArchivo(archivoHistorial))
            {
                Console.WriteLine("LISTA DE GANADORES");
                var listaGanadores = historialJson.LeerGanadores(archivoHistorial).OrderByDescending(p => p.Daniototal);
                var j = 1;
                foreach (var item in listaGanadores)
                {
                    Console.WriteLine($"{j}: {item}");
                    j++;
                }
            }
        }
    }
}