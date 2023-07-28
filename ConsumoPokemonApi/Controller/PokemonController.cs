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
                default:
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
                default:
                    PokemonView.Sair();
                    break;

            }
        }

        public static void InfoMascote(string nomePokemon, string nomePessoa, int numPokedex)
        {
            PokemonView.InfoMascote(nomePokemon);
            int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

            switch (menuPokemonSelect)
            {
                case 1:
                    {
                        InvocarGet(numPokedex, nomePessoa);
                    }
                    break;
                case 2:
                    {
                        AdotarPokemon(nomePessoa, nomePokemon, numPokedex);
                    }
                    break;
                case 3:
                    {
                        EscolherMascote(nomePessoa);
                    }
                    break;
                default:
                    {
                        PokemonView.Sair();
                    }
                    break;
            }
        }

        public static void InvocarGet(int numPokedex, string nomePessoa)
        {
            InfoPokemon? listaPokemons = PokemonService.ObterInfoPokemon(numPokedex);

            if (listaPokemons != null)
            {
                PokemonView.ExibirInformacoesPokemon(listaPokemons);
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

            InfoPokemon? listaPokemons = PokemonService.ObterInfoPokemon(numPokedex);
            if (listaPokemons != null)
            {
                PokemonAdopted pokemonAdopted = new PokemonAdopted();
                pokemonAdopted.PokemonInfo = new InfoPokemon();
                pokemonAdopted.PokemonInfo.name = listaPokemons.name;
                pokemonAdopted.PokemonInfo.id = listaPokemons.id;
                pokemonAdopted.PokemonInfo.height = listaPokemons.height;
                pokemonAdopted.Satisfeito = 4;
                pokemonAdopted.Humor = 3;
                pokemonAdopted.Disposicao = 5;
                pokemonAdopted.Limpeza = 6;
                pokemonAdopted.DataAdocao = DateTime.Now;

                PokemonView.AdotarPokemon(nomePessoa, nomePokemon, pokemonAdopted);
                int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

                if (menuPokemonSelect == 1)
                {
                    string nomePokemon = listaPokemons.name;
                    AdotarPokemon(nomePessoa, nomePokemon, numPokedex);
                }
                else if (menuPokemonSelect == 2) 
                {
                    PokemonView.InfosEStatusPokemon(nomePessoa, pokemonAdopted);
                }
                else
                    PokemonView.Sair();


            }
            else { Console.WriteLine("Erro ao obter informações do Pokémon."); };
        }
    }
}
