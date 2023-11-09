using ConsumoPokemonApi.Model;
using ConsumoPokemonApi.Service;
using ConsumoPokemonApi.View;
using RestSharp;
using System.Text.Json;

namespace ConsumoPokemonApi.Controller
{
    public class PokemonController
    {
        public static string Apresentacao()
        {
            PokemonView.BoasVindas();
            string nomePessoa = Console.ReadLine();
            return nomePessoa;

        }

        public static void Menu(string nomePessoa)
        {
            PokemonView.MenuInicial(nomePessoa);
            int.TryParse(Console.ReadLine(), out int menuGeral);

            switch (menuGeral)
            {
                case 1:
                    EscolherMascote(nomePessoa);
                    break;
                case 2:
                    {
                        PokemonView.NaoTemMascote();
                        Menu(nomePessoa);
                    }
                    break;
                case 3:
                    PokemonView.Sair();
                    break;
            }

        }

        public static void EscolherMascote(string nomePessoa)
        {
            PokemonView.EscolherMascote(nomePessoa);
            int.TryParse(Console.ReadLine(), out int menuAdotar);

            switch (menuAdotar)
            {
                case 1:
                    {
                        string nomePokemon = "Bulbasaur";
                        int numPokedex = 1;
                        InfoMascote(nomePokemon, nomePessoa, numPokedex);
                    }
                    break;
                case 2:
                    {
                        string nomePokemon = "Charmander";
                        int numPokedex = 4;
                        InfoMascote(nomePokemon, nomePessoa, numPokedex);
                    }
                    break;
                case 3:
                    {
                        string nomePokemon = "Squirtle";
                        int numPokedex = 7;
                        InfoMascote(nomePokemon, nomePessoa, numPokedex);
                    }
                    break;
                case 4:
                    {
                        PokemonView.PokemonEspecifico();
                        int.TryParse(Console.ReadLine(), out int outroPok);
                        InvocarGet(outroPok, nomePessoa);
                    }
                    break;
                case 5:
                    {
                        Menu(nomePessoa);
                    }
                    break;

            }
        }

        public static void InfoMascote(string nomePokemon, string nomePessoa, int numPokedex)
        {
            PokemonView.InfoMascote(nomePokemon);
            int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

            if (menuPokemonSelect == 1)
            {
                InvocarGet(numPokedex, nomePessoa);
            }
            else if (menuPokemonSelect == 2)
            {
                AdotarPokemon(nomePessoa, nomePokemon, numPokedex);
            }
            else
            {
                EscolherMascote(nomePessoa);
            }
        }

        public static void InvocarGet(int numPokedex, string nomePessoa)
        {
            InfoPokemon? listaPokemons = PokemonService.ObterInfoPokemon(numPokedex);

            if (listaPokemons != null)
            {
                MapperInfosPokemon(listaPokemons.name, numPokedex, 1, 1);
                Console.WriteLine("\r\nE agora, o que deseja?");
                Console.WriteLine($"1 - Adotar o {listaPokemons.name}\r\n2 - Voltar");
                int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

                if (menuPokemonSelect == 1)
                {
                    string nomePokemon = listaPokemons.name;
                    AdotarPokemon(nomePessoa, nomePokemon, numPokedex);
                }
                else
                {
                    EscolherMascote(nomePessoa);
                }
            }
            else
            {
                Console.WriteLine("Erro ao obter informações do Pokémon.");
            }
            Console.ReadKey();

        }

        public static void AdotarPokemon(string nomePessoa, string nomePokemon, int numPokedex)
        {
            Console.WriteLine($"Parabéns {nomePessoa}! Seu {nomePokemon} foi escolhido!\r\nVamos dar uma olhada nos atributos do seu {nomePokemon}?");
            MapperInfosPokemon(nomePokemon, numPokedex, 1, 1);
            MenuPokemonAdotado(nomePokemon, numPokedex);
        }

        public static void MapperInfosPokemon(string nomePokemon, int numPokedex, int fome, int sono)
        {
            InfoPokemon? listaPokemons = PokemonService.ObterInfoPokemon(numPokedex);
            if (listaPokemons != null)
            {
                PokemonAdopted pokemonAdopted = new PokemonAdopted();
                InfoPokemon pokemonInfo = new InfoPokemon();
                pokemonInfo.name = nomePokemon;
                pokemonInfo.id = listaPokemons.id;
                pokemonInfo.height = listaPokemons.height;
                pokemonInfo.types = listaPokemons.types;
                pokemonInfo.abilities = listaPokemons.abilities;
                pokemonAdopted.DataAdocao = DateTime.Now;
                pokemonAdopted.Fome = fome;
                pokemonAdopted.Sono = sono;
                PokemonView.ExibirInformacoesPokemon(pokemonAdopted, pokemonInfo);

            }
            else { Console.WriteLine("Erro ao obter informações do Pokémon."); };
        }

        public static void MenuPokemonAdotado(string nomePokemon, int numPokedex)
        {
            PokemonView.InfoMascoteAdotado(nomePokemon);
            int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

            PokemonAdopted pokemonAdopted = new PokemonAdopted();
            switch (menuPokemonSelect)
            {
                case 1:
                    {
                        MapperInfosPokemon(nomePokemon, numPokedex, 1, 1);
                        MenuPokemonAdotado(nomePokemon, numPokedex);
                    }
                    break;
                case 2:
                    {
                        pokemonAdopted.Fome++;
                        PokemonView.ExibirFome(nomePokemon, pokemonAdopted.Fome);
                        return;
                    }
                case 3:
                    {
                        pokemonAdopted.Sono++;
                        PokemonView.ExibirSono(nomePokemon, pokemonAdopted.Sono);
                        MenuPokemonAdotado(nomePokemon, numPokedex);
                    }
                    break;
                default: { break; }

            }
        }
    }
}
