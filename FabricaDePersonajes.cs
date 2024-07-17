using System;
using System.Collections;
using EspacioPersonaje;

namespace EspacioFabricaDePersonajes
{
    public class FabricaDePersonajes
    {

        private Random Rand = new();
        private List<Personaje> personajes;

        private List<string> nombres = new List<string>
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

        private List<string> apodos = new List<string>
        {
            "Sabelotodo",
            "Rana",
            "Guardián",
            "Rayo escarlata",
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

        private List<string> varitas = new List<string>
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

        private List<string> casas = new List<string>
        {
            "Gryffindor",
            "Ravenclaw",
            "Slytherin",
            "Hufflepuff"
        };


        public FabricaDePersonajes()
        {
            personajes = new List<Personaje>();

            for (int i = 0; i < 10; i++)
            {
                int iNombreYApodo = Rand.Next(20);
                int iVarita = Rand.Next(13);
                int iCasa = Rand.Next(4);

                string randomNombre = nombres[iNombreYApodo];
                string randomApodo = apodos[iNombreYApodo];
                string randomVarita = varitas[iVarita];
                string randomCasa = casas[iCasa];

                bool existe = personajes.Any(p => p.Dato.Nombre == randomNombre);

                if (existe)
                {
                    i--;
                }
                else
                {
                    var unPersonaje = new Personaje(randomNombre, randomApodo, randomCasa, randomVarita);
                    personajes.Add(unPersonaje);
                }

            }
        }

        public Personaje mostrarUnPersonaje(int eleccion)
        {
            return personajes[eleccion-1];
        }
    }
}