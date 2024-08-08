using EspacioJuego;

class Program
{
    private async static Task Main(string[] args)
    {
        Juego nuevoJuego = new();

        await nuevoJuego.Jugar();
        
    }
}
