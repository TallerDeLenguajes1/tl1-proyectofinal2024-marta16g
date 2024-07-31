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

class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Probando calcularDanio");

        MovimientosJson pruebaJsonMovimientos = new();
        FabricaDePersonajes pruebaFabrica = new();
        List<Personaje> pruebaListaDePersonajes = new();
        
        pruebaListaDePersonajes = pruebaFabrica.GenerarPersonajesAleatorios();

        List<Movimiento>? listaMovimientosche = new();

        listaMovimientosche = pruebaJsonMovimientos.LeerMovimientos("Movimientos.json");

        Ataque pruebaAtaque = new(Posiciones.Furtivo, listaMovimientosche[2]);
        Duelo pruebaDuelo = new();

        pruebaDuelo.CalcularDanio(pruebaAtaque, pruebaListaDePersonajes[9]);
    
        
    }
}
