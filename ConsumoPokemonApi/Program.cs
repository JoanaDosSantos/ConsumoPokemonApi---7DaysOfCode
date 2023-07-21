using RestSharp;
using System.Text.Json;

namespace Program.cs // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            InvocarGet();
        }

        #region class ListaPokemons
        public class ListaPokemons
        {
            public List<AbilitiesItems> abilities { get; set; }
            public int height { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public List<TypesItems> types { get; set; }

        }
        public class AbilitiesItems
        {
            public AbilityClass ability { get; set; }
        }
        public class AbilityClass
        {
            public string name { get; set; }
        }
        public class TypesItems
        {
            public TypeClass type { get; set; }
        }
        public class TypeClass
        {
            public string name { get; set; }
        }
        #endregion

        public static void InvocarGet()
        {
            string idPokemon = "1";

            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{idPokemon}/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            ListaPokemons? listaPokemons = JsonSerializer.Deserialize<ListaPokemons>(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine($"NOME DO POKÉMON: {listaPokemons.name.ToUpper()}");
                Console.WriteLine($"NÚMERO DA POKÉDEX: {listaPokemons.id}");
                Console.WriteLine($"PESO DO POKÉMON: {listaPokemons.height}");
                Console.WriteLine($"TIPO(S) DO POKÉMON:");
                foreach (var typeItem in listaPokemons.types)
                {
                    Console.WriteLine($"{typeItem.type.name.ToUpper()}");
                }

                Console.WriteLine("HABILIDADES DO POKÉMON:");
                foreach (var abilityItem in listaPokemons.abilities)
                {
                    Console.WriteLine($"{abilityItem.ability.name.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }


    }
}