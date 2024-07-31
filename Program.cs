using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;
using EspacioAtaque;
using EspacioMovimiento;
using EspacioMovimientoJson;
using EspacioDuelo;
using EspacioPosiciones;
using EspacioJuego;

class Program
{
    private static void Main(string[] args)
    {
        Juego nuevoJuego = new();

        nuevoJuego.Jugar();
        
    }
}
