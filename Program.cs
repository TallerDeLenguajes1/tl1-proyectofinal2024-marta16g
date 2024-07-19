using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;

class Program
{
    private static void Main(string[] args)
    {

        PersonajesJson pruebaPersonaje = new();

        FabricaDePersonajes pruebaFabrica = new();

        List<Personaje> listaPruebDePersonajes = new();

        listaPruebDePersonajes = pruebaFabrica.GenerarPersonajesAleatorios();


        pruebaPersonaje.GuardarPersonajes(listaPruebDePersonajes, "Personajes.json");





    }
}
