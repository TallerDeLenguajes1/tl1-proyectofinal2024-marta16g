using System;
using EspacioPersonaje;
using EspacioPersonajesJS;

Console.WriteLine("BIENVENIDA");

Console.WriteLine("Probando traída de json personajes");

List<Personaje>? PruebaDepersonajes = new();
PersonajesJson pruebaArchivoNuevo = new();

string nombreArchivo = "Personajes.json";

PruebaDepersonajes = pruebaArchivoNuevo.LeerPersonajes(nombreArchivo);

foreach (var personaje in PruebaDepersonajes)
{
    Console.WriteLine(personaje.mostrarPersonaje());
}

