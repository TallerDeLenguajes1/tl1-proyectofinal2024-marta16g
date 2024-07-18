﻿using System;
using EspacioPersonaje;
using EspacioCaracteristica;
using EspacioPersonajesJS;
using EspacioFabricaDePersonajes;

class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("---BIENVENIDA---");

        Console.WriteLine("-----Probando Fábrica de personajes y json-----");

        FabricaDePersonajes pruebaFabrica = new();
        List<Personaje> listache = pruebaFabrica.GenerarPersonajesAleatorios();

        PersonajesJson pruebaJson = new();

        bool existeono = pruebaJson.ExisteArchivo("personajes.json");


        pruebaJson.GuardarPersonajes(listache, "personajes.json");

        Console.WriteLine("Mostrando lista de personajes");

        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine($"--PERSONAJE NÚMERO {i}--");
            var unPersonaje = pruebaFabrica.DevolverUnPersonaje(i);
            Console.WriteLine($"Nombre: {unPersonaje.Dato.Nombre}");
            Console.WriteLine($"Apodo: {unPersonaje.Dato.Apodo}");
            Console.WriteLine($"Casa: {unPersonaje.Dato.Casa}");
            Console.WriteLine($"Varita: {unPersonaje.Dato.Varita}");
            Console.WriteLine($"Violencia: {unPersonaje.Caracteristica.Violencia}");
            Console.WriteLine($"Resistencia: {unPersonaje.Caracteristica.Resistencia}");
            Console.WriteLine($"Discrecion: {unPersonaje.Caracteristica.Discrecion}");
        }




    }
}
