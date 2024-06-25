using System;
using EspacioPersonajesJS;

namespace EspacioPersonajes
{

    public class Datos()
    {
        private string? nombre { get; set; }
        private string? apodo { get; set; }
        private string? casa { get; set; }
        private string? varita { get; set; }

    }

    public class Caracteristicas()
    {
        private int violencia { get; set; }
        private int resistencia { get; set; }
        private int discrecion { get; set; }
        private int salud { get; set;}
        private int vidas { get; set; }

    }
    public class Personaje
    {
        Datos? Datos { get; set; }
        Caracteristicas? Caracteristicas { get; set; }

    }
    public class FabricaDePersonajes()
    {



    }
}