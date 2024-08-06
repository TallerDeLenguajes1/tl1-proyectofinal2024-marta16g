using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {

        private static Random Rand = new();
        private List<Personaje> personajes;

        private List<string> nombres = new()
        {
            "Alyssa Goldworthy",
            "Jasper Nightshade",
            "Elara Moonstone",
            "Cedric Thistledown",
            "Fiona Ravenshade",
            "Orion Ashcroft",
            "Lilith Hawthorne",
            "Thaddeus Stormrider",
            "Luna Brightwood",
            "Felix Darkwater",
            "Morgana Spellbound",
            "Silas Windwalker",
            "Ivy Greenbriar",
            "Gideon Shadowmire",
            "Daphne Silverleaf",
            "Lysander Blackthorn",
            "Penelope Starfall",
            "Rowan Frostwood",
            "Selene Emberheart",
            "Cassius Ironwood"
        };

        private List<string> apodos = new()
        {
            "Sabelotodo",
            "Rana",
            "Guardián",
            "Rayo McQueen",
            "Bomba de Azufre",
            "Tiqui-Taca",
            "Seda majestuosa",
            "Caramelo de cianuro",
            "Doble cara",
            "Diablo en botella",
            "Majestad",
            "Lince",
            "Fantasma de Canterville",
            "Espectro del bosque",
            "Chispa de Luz",
            "Media Naranja",
            "Luna llena",
            "Catástrofe",
            "Encanto",
            "Corazón de Piedra"
        };

        private List<string> casas = new()
        {
            "Gryffindor",
            "Ravenclaw",
            "Slytherin",
            "Hufflepuff"
        };
        private List<string> varitas = new()
        {
            "Cerezo y pelos de Veela",
            "Pino y bigotes de trol",
            "Roble y pelo de gato Wampus",
            "Cedro y pelo de cola de unicornio",
            "Acebo y Coral",
            "Cedro y plumas de cola de ave del trueno",
            "Cerezo y pluma de cola de ave Fénix",
            "Arce y pelo de rougarou",
            "Cedro y fibra de corazón de dragón",
            "Roble y pelo de Veela",
            "Acebo y pelo de kelpie",
            "Arce y pelo de cola de thestral",
            "Pino y pelo de gato Wampus"
        };
        public FabricaDePersonajes()
        {
            this.personajes = [];
        }

        public List<Personaje> GenerarPersonajesAleatorios(int numPersonajes)
        {
            personajes.Clear();

            List<string> nombresDisponibles = new List<string>(nombres);
            List<string> apodosDisponibles = new List<string>(apodos);
            List<string> casasDisponibles = new List<string>(casas);
            List<string> varitasDisponibles = new List<string>(varitas);

            for (int i = 0; i < numPersonajes; i++)
            {
                int iNombre = Rand.Next(nombresDisponibles.Count);
                int iApodo = Rand.Next(apodosDisponibles.Count);
                int iCasa = Rand.Next(casasDisponibles.Count);
                int iVarita = Rand.Next(varitasDisponibles.Count);

                var unPersonaje = new Personaje(nombresDisponibles[iNombre], apodosDisponibles[iApodo], casasDisponibles[iCasa], varitasDisponibles[iVarita]);

                personajes.Add(unPersonaje);

                nombresDisponibles.RemoveAt(iNombre);
                apodosDisponibles.RemoveAt(iApodo);
            }

            return personajes;
        }


        public Personaje DevolverUnPersonaje(int eleccion)
        {
            return personajes[eleccion - 1];
        }

        public static void MostrarListaDePersonajes(List<Personaje> listaPersonajes, int cantPersonajes, string tipoLista)
        {
            for (int i = 0; i < cantPersonajes; i++)
            {
                Console.WriteLine($"--{tipoLista} NÚMERO {i+1}--");

                Console.WriteLine($"Nombre: {listaPersonajes[i].Dato.Nombre}");
                Console.WriteLine($"Apodo: {listaPersonajes[i].Dato.Apodo}");
                Console.WriteLine($"Casa: {listaPersonajes[i].Dato.Casa}");
                Console.WriteLine($"Varita: {listaPersonajes[i].Dato.Varita}");
                Console.WriteLine($"Violencia: {listaPersonajes[i].Caracteristica.Violencia}");
                Console.WriteLine($"Resistencia: {listaPersonajes[i].Caracteristica.Resistencia}");
                Console.WriteLine($"Discrecion: {listaPersonajes[i].Caracteristica.Discrecion}");

                Console.WriteLine("------------------");
            }
        }
    }
}