using System;

namespace EspacioFabricaDePersonajes
{
     public class FabricaDePersonajes()
    {
        List<Personaje> personajes;

        public FabricaDePersonajes(int cantidadDePersonajes){
            for (int i=0; i<cantidadDePersonajes; i++){
                var unPersonaje = new Personaje();
                personajes.Add(unPersonaje);
            }
        }
    }
}