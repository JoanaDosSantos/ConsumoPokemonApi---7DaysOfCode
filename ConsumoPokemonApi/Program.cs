using ConsumoPokemonApi.Controller;

namespace Program.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomePessoa = PokemonController.Apresentacao();
            PokemonController.Menu(nomePessoa);
        }

    }
}

