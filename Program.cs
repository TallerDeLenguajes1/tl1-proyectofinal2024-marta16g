using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;
using EspacioDuelo;
using EspacioMovimiento;
using EspacioMovimientoJson;

class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("Probando Traer archivo de movimientos");

        MovimientosJson pruebaDeMovimientoJson = new();

        List<Movimiento>? listaDePrueba = pruebaDeMovimientoJson.LeerMovimientos("Movimientos.json");

        if(listaDePrueba != null)
        {
            foreach (var movimiento in listaDePrueba)
            {
                Console.WriteLine($"Nombre de la posicion: {movimiento.Posicion}");
                Console.WriteLine("------");
            }
        }

        
    }
}
