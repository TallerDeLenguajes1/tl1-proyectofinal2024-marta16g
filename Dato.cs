using System;

namespace EspacioDato
{
    public class Dato
    {
        private Random Rand = new();
        private string? nombre;
        private string? apodo;
        private string? casa;
        private string? varita;
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public string? Casa { get => casa; set => casa = value; }
        public string? Varita { get => varita; set => varita = value; }


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

        private List<string> casas = new List<string>
        {
            "Gryffindor",
            "Ravenclaw",
            "Slytherin",
            "Hufflepuff"
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


        public Dato(int iNombre, int iApodo, int iCasa, int iVarita)
        {
            this.nombre = nombres[iNombre];
            this.apodo = apodos[iApodo];
            this.casa = casas[iCasa];
            this.varita = varitas[iVarita];

            nombres.RemoveAt(iNombre);
            apodos.RemoveAt(iApodo);
            casas.RemoveAt(iCasa);
            varitas.RemoveAt(iVarita);
        }
        public Dato(string nombre, string apodo, string casa, string varita)
        {
            this.nombre = nombre;
            this.apodo = apodo;
            this.casa = casa;
            this.varita = varita;
        }

    }

}