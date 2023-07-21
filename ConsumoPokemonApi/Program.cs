using RestSharp;
using System;

namespace Program.cs // Note: actual namespace depends on the project name.
{
    class Program
    {
        static void Main(string[] args)
        {
            InvocarGet();
        }

        public static void InvocarGet()
        {
            string idPokemon = "1";

            //var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-form/{idPokemon}/");
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon-form/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                Console.WriteLine(response.Content);
            } else {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}