using ConsumoPokemonApi.Model;
using RestSharp;
using System.Text.Json;

namespace ConsumoPokemonApi.Service
{
    public class PokemonService
    {
        public static InfoPokemon? ObterInfoPokemon(int numPokedex)
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{numPokedex}/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                InfoPokemon? listaPokemons = JsonSerializer.Deserialize<InfoPokemon>(response.Content);
                return listaPokemons;
            }
            else
            {
                Console.WriteLine("Erro ao obter informações do Pokémon: " + response.ErrorMessage);
                return null;
            }
        }
    }
}
