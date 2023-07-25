using RestSharp;
using System.Text.Json;

namespace Program.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomePessoa = Apresentacao();
            Menu(nomePessoa);
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


        public static string Apresentacao()
        {
            #region Titulo grande - string titulo
            string titulo = ".______     ______    __  ___  _______ .___  ___.   ______   .__   __. \r\n|   _  \\   /  __  \\  |  |/  / |   ____||   \\/   |  /  __  \\  |  \\ |  | \r\n|  |_)  | |  |  |  | |  '  /  |  |__   |  \\  /  | |  |  |  | |   \\|  | \r\n|   ___/  |  |  |  | |    <   |   __|  |  |\\/|  | |  |  |  | |  . `  | \r\n|  |      |  `--'  | |  .  \\  |  |____ |  |  |  | |  `--'  | |  |\\   | \r\n| _|       \\______/  |__|\\__\\ |_______||__|  |__|  \\______/  |__| \\__| \r\n                                                                       ";
            Console.WriteLine(titulo);
            #endregion

            Console.Write("Olá! Bem vindo ao Centro Pokémon!\r\nAqui, você poderá escolher seu próximo bichinho virtual!\r\nPara iniciarmos, me diga seu nome: ");
            string nomePessoa = Console.ReadLine();
            return nomePessoa;

        }

        public static void Menu(string nomePessoa)
        {
            #region Titulo grande - string tituloMenu
            string tituloMenu = "-------------------------------- MENU --------------------------------";
            Console.WriteLine(tituloMenu);
            #endregion

            Console.WriteLine($"\r\n{nomePessoa}, vamos começar!\r\nDiga, o que deseja fazer?");
            Console.WriteLine("1 - Adotar um mascote virtual\r\n2 - Ver seus mascotes\r\n3 - Sair");
            int.TryParse(Console.ReadLine(), out int menuGeral);

            switch (menuGeral)
            {
                case 1:
                    EscolherMascote(nomePessoa);
                    break;
                case 2:
                    {
                        Console.WriteLine("\r\nVocê ainda não possui um mascote, mas adote agora o seu pokémon!");
                        Menu(nomePessoa);
                    }
                    break;
                case 3:
                    Console.WriteLine("\r\nAté logo!");
                    break;
            }

        }

        public static void EscolherMascote(string nomePessoa)
        {

            #region Titulo grande - string tituloMenu
            string tituloMenu = "-------------------------- ADOTAR UM MASCOTE -------------------------";
            Console.WriteLine(tituloMenu);
            #endregion

            Console.WriteLine($"\r\n{nomePessoa}, atualmente existem 1.008 espécies de pokémon!\r\n" +
                              $"Porém, vamos deixar sua escolha mais simples!\r\nTemos os 3 pokémons iniciais da região de Kanto\r\npara você decidir qual será seu mascote!\r\n" +
                              $"Qual espécie gostaria de ver informações e/ou adotar?");
            Console.WriteLine("1 - Bulbasaur\r\n2 - Charmander\r\n3 - Squirtle\r\n4 - Consultar um pokémon específico\r\n5 - Voltar\r\n");
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
                        Console.WriteLine($"\r\nPara pesquisar um pokémon específico, você precisa me informar o\r\nID dele na pokédex. Sobre qual pokémon gostaria de mais informações?");
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

            #region Titulo grande - string tituloMenu
            string tituloMenu = "--------------------------- SOBRE ESTE MASCOTE ---------------------------";
            Console.WriteLine(tituloMenu);
            #endregion

            Console.WriteLine($"Beleza, sobre o {nomePokemon}, o que deseja?");
            Console.WriteLine($"1 - Saber mais sobre o {nomePokemon}\r\n2 - Adotar o {nomePokemon}\r\n3 - Voltar");
            int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

            if (menuPokemonSelect == 1)
            {
                InvocarGet(numPokedex, nomePessoa);
            }
            else if (menuPokemonSelect == 2)
            {
                AdotarPokemon(nomePessoa, nomePokemon);
            }
            else
            {
                EscolherMascote(nomePessoa);
            }
        }

        public static void InvocarGet(int numPokedex, string nomePessoa)
        {
            #region Chamada API Pokemon
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{numPokedex}/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);
            ListaPokemons? listaPokemons = JsonSerializer.Deserialize<ListaPokemons>(response.Content);
            #endregion

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                #region Titulo grande - string tituloMenu
                string tituloMenu = "---------------------- INFORMAÇÕES DESTE POKÉMON ----------------------";
                Console.WriteLine(tituloMenu);
                #endregion

                #region monta infos do pokemon
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

                Console.WriteLine("E agora, o que deseja?");
                Console.WriteLine($"1 - Adotar o {listaPokemons.name}\r\n2 - Voltar");
                int.TryParse(Console.ReadLine(), out int menuPokemonSelect);

                if (menuPokemonSelect == 1)
                {
                    string nomePokemon = listaPokemons.name;
                    AdotarPokemon(nomePessoa, nomePokemon);
                }
                else
                {
                    EscolherMascote(nomePessoa);
                }
                #endregion
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
            Console.ReadKey();

        }

        public static void AdotarPokemon(string nomePessoa, string nomePokemon)
        {
            Console.WriteLine($"Parabéns {nomePessoa}! Seu {nomePokemon} foi escolhido!\r\nVamos ficar de olho pois logo ele irá se chocar!");
            Console.WriteLine("  ___  \r\n /   \\ \r\n|     |\r\n|     |\r\n \\___/ \r\n       ");
        }


    }
}

