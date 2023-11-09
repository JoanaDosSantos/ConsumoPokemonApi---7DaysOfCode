using ConsumoPokemonApi.Model;

namespace ConsumoPokemonApi.View
{
    public class PokemonView
    {
        public static void BoasVindas()
        {
            string titulo = ".______     ______    __  ___  _______ .___  ___.   ______   .__   __. " +
                        "\r\n|   _  \\   /  __  \\  |  |/  / |   ____||   \\/   |  /  __  \\  |  \\ |  | " +
                        "\r\n|  |_)  | |  |  |  | |  '  /  |  |__   |  \\  /  | |  |  |  | |   \\|  | " +
                        "\r\n|   ___/  |  |  |  | |    <   |   __|  |  |\\/|  | |  |  |  | |  . `  | " +
                        "\r\n|  |      |  `--'  | |  .  \\  |  |____ |  |  |  | |  `--'  | |  |\\   | " +
                        "\r\n| _|       \\______/  |__|\\__\\ |_______||__|  |__|  \\______/  |__| \\__| " +
                        "\r\n                                                                       ";
            Console.WriteLine(titulo);
            Console.Write("Olá! Bem vindo ao Centro Pokémon!\r\nAqui, você poderá escolher seu próximo bichinho virtual!\r\nPara iniciarmos, me diga seu nome: ");
        }

        public static void MenuInicial(string nomePessoa)
        {
            string tituloMenu = "-------------------------------- MENU --------------------------------";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"\r\n{nomePessoa}, vamos começar!\r\nDiga, o que deseja fazer?");
            Console.WriteLine("1 - Adotar um mascote virtual\r\n2 - Ver seus mascotes\r\n3 - Sair");
        }

        public static void NaoTemMascote()
        {
            Console.WriteLine("\r\nVocê ainda não possui um mascote, mas adote agora o seu pokémon!");
        }

        public static void Sair()
        {
            Console.WriteLine("\r\nAté logo!");
        }

        public static void EscolherMascote(string nomePessoa)
        {
            string tituloMenu = "-------------------------- ADOTAR UM MASCOTE -------------------------";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"\r\n{nomePessoa}, atualmente existem 1.008 espécies de pokémon!\r\n" +
                              $"Porém, vamos deixar sua escolha mais simples!\r\nTemos os 3 pokémons iniciais da região de Kanto\r\npara você decidir qual será seu mascote!\r\n" +
                              $"Qual espécie gostaria de ver informações e/ou adotar?");
            Console.WriteLine("1 - Bulbasaur\r\n2 - Charmander\r\n3 - Squirtle\r\n4 - Consultar um pokémon específico\r\n5 - Voltar\r\n");
        }

        public static void PokemonEspecifico()
        {
            Console.WriteLine($"\r\nPara pesquisar um pokémon específico, você precisa me informar o\r\nID dele na pokédex. Sobre qual pokémon gostaria de mais informações?");
        }

        public static void InfoMascote(string nomePokemon)
        {
            string tituloMenu = "--------------------------- SOBRE ESTE MASCOTE ---------------------------";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"Beleza, sobre o {nomePokemon}, o que deseja?");
            Console.WriteLine($"1 - Saber mais sobre o {nomePokemon}\r\n2 - Adotar o {nomePokemon}\r\n3 - Voltar");
        }

        public static void ExibirFome(string nomePokemon, int estado)
        {
            if(estado == 0)
            {
                Console.WriteLine($"Você não informou o nível de fome do seu {nomePokemon}.");
            }
            else if (estado <= 2)
            {
                Console.WriteLine($"Seu {nomePokemon} está com fome.");
            }
            else if (estado == 4)
            {
                Console.WriteLine($"Seu {nomePokemon} está com pouca fome.");
            }
            else
            {
                Console.WriteLine($"Seu {nomePokemon} está com bem alimentado.");
            }
        }

        public static void ExibirSono(string nomePokemon, int estado)
        {
            if (estado == 0)
            {
                Console.WriteLine($"Você não informou o nível de sono do seu {nomePokemon}.");
            }
            else if (estado <= 2)
            {
                Console.WriteLine($"Seu {nomePokemon} está sonolento.");
            }
            else if (estado == 4)
            {
                Console.WriteLine($"Seu {nomePokemon} está um pouco disposto.");
            }
            else
            {
                Console.WriteLine($"Seu {nomePokemon} está muito disposto.");
            }
        }

        public static void ExibirInformacoesPokemon(PokemonAdopted pokemonAdopted, InfoPokemon pokemonInfo)
        {
            string tituloMenu = "---------------------- INFORMAÇÕES DESTE POKÉMON ----------------------";
            Console.WriteLine(tituloMenu);

            Console.WriteLine($"NOME DO POKÉMON: {pokemonInfo.name.ToUpper()}");
            Console.WriteLine($"NÚMERO DA POKÉDEX: {pokemonInfo.id}");
            Console.WriteLine($"PESO DO POKÉMON: {pokemonInfo.height}");
            Console.WriteLine($"DATA DE ADOÇÃO DO POKÉMON: {pokemonAdopted.DataAdocao}");
            Console.WriteLine($"TIPO(S) DO POKÉMON:");
            foreach (var typeItem in pokemonInfo.types)
            {
                Console.WriteLine($"{typeItem.type.name.ToUpper()}");
            }

            Console.WriteLine("HABILIDADES DO POKÉMON:");
            foreach (var abilityItem in pokemonInfo.abilities)
            {
                Console.WriteLine($"{abilityItem.ability.name.ToUpper()}");
            }

            if (pokemonAdopted.Fome.Equals(false) || pokemonAdopted.Sono.Equals(false))
            {
                Console.WriteLine($"POKEMON AINDA NÃO ADOTADO.");
            }
            else
            {
                ExibirFome(pokemonInfo.name, pokemonAdopted.Fome);
                ExibirSono(pokemonInfo.name, pokemonAdopted.Sono);
            }
        }

        public static void InfoMascoteAdotado(string nomePokemon)
        {
            string tituloMenu = "---------------------- INTERAÇÕES DO SEU POKÉMON ----------------------";
            Console.WriteLine(tituloMenu);

            Console.WriteLine($"Você está com o seu {nomePokemon}! E agora, o que deseja fazer?");
            Console.WriteLine($"1 - Saber como {nomePokemon} está\r\n" +
                $"2 - Alimentar com o {nomePokemon}\r\n" +
                $"3 - Brincar o {nomePokemon}\r\n" +
                $"4 - Voltar\r\n");
        }
    }
}
