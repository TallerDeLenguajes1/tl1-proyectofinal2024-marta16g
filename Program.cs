using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;

class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("---BIENVENIDA---");

        Console.WriteLine("-----Probando Fábrica de personajes-----");

        FabricaDePersonajes pruebaFabrica = new();
        Console.WriteLine("Mostrando un personaje");

        var unPersonaje = pruebaFabrica.devolverUnPersonaje(1);
        Console.WriteLine(unPersonaje.Dato.Nombre);
       


        // List<Personaje>? PruebaDepersonajes = new();
        // PersonajesJson pruebaArchivoNuevo = new();

        // string nombreArchivo = "PRUEBA.json";

        // // PruebaDepersonajes = pruebaArchivoNuevo.LeerPersonajes(nombreArchivo);

        // Personaje p1 = new Personaje("Harry", "Wachin", "Gryffindor", "Palo santo");
        // Personaje p2 = new Personaje("Ronald", "Ron el pelirrojo", "Ravenclaw", "Escoba", 1, 2, 3);

        // PruebaDepersonajes.Add(p1);
        // PruebaDepersonajes.Add(p2);

        // pruebaArchivoNuevo.GuardarPersonajes(PruebaDepersonajes, nombreArchivo);


    }
}
