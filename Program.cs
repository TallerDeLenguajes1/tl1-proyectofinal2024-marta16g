using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;
using EspacioMovimiento;
using EspacioMovimientoJson;
using EspacioDuelo;
using EspacioPosiciones;
using EspacioJuego;

class Program
{
    private async static Task Main(string[] args)
    {
        Juego nuevoJuego = new();

        await nuevoJuego.Jugar();
        
    }
}
