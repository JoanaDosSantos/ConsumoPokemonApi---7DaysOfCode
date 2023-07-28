using ConsumoPokemonApi.Model;
using System.Net;
using System.Runtime.Intrinsics.X86;

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
            string tituloMenu = "\r\n\r\n-------------------------------- MENU --------------------------------\r\n\r\n";
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
            Console.WriteLine("\r\nAté logo!\r\nAperte qualquer tecla para fechar...");
        }

        public static void EscolherMascote(string nomePessoa)
        {
            string tituloMenu = "\r\n\r\n-------------------------- ADOTAR UM MASCOTE -------------------------\r\n\r\n";
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
            string tituloMenu = "\r\n\r\n--------------------------- SOBRE ESTE MASCOTE ---------------------------\r\n\r\n";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"Beleza, sobre o {nomePokemon}, o que deseja?");
            Console.WriteLine($"1 - Saber mais sobre o {nomePokemon}\r\n2 - Adotar o {nomePokemon}\r\n3 - Voltar");
        }

        public static void ExibirInformacoesPokemon(InfoPokemon listaPokemons)
        {
            string tituloMenu = "\r\n\r\n---------------------- INFORMAÇÕES DESTE POKÉMON ----------------------\r\n\r\n";
            Console.WriteLine(tituloMenu);

            Console.WriteLine($"NOME DO POKÉMON: {listaPokemons.name.ToUpper()}\r\nNÚMERO DA POKÉDEX: {listaPokemons.id}\r\nPESO DO POKÉMON: {listaPokemons.height}\r\nTIPO(S) DO POKÉMON:");

            if (listaPokemons.types != null)
            {
                foreach (var typeItem in listaPokemons.types)
                {
                    Console.WriteLine($"{typeItem.type.name.ToUpper()}");
                }
            }
            else
                Console.WriteLine("Este pokémon não possui um tipo definido.");

            Console.WriteLine("HABILIDADES DO POKÉMON:");

            if (listaPokemons.abilities != null)
            {
                foreach (var abilityItem in listaPokemons.abilities)
                {
                    Console.WriteLine($"{abilityItem.ability.name.ToUpper()}");
                }
            }
            else
                Console.WriteLine("Este pokémon não possui um ataque definido.");

            Console.WriteLine("\r\nE agora, o que deseja?");
            Console.WriteLine($"1 - Adotar o {listaPokemons.name}\r\n2 - Voltar");
        }

        public static void AdotarPokemon(string nomePessoa, string nomePokemon, PokemonAdopted pokemonAdopted)
        {
            string tituloMenu = "\r\n\r\n----------------------------- POKÉMON ADOTADO! ----------------------------\r\n\r\n";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"Parabéns {nomePessoa}! Seu {nomePokemon} foi escolhido!\r\nVamos dar uma olhada nos atributos do seu {nomePokemon}?");
            Console.WriteLine($"NOME DO POKÉMON: {pokemonAdopted.PokemonInfo.name}\r\n" +
                $"NÚMERO ID NA POKÉDEX DO POKÉMON: {pokemonAdopted.PokemonInfo.id}\r\n" +
                $"PESO DO POKÉMON: {pokemonAdopted.PokemonInfo.height}\r\n" +
                $"DATA DE ADOÇÃO DO POKÉMON: {pokemonAdopted.DataAdocao}\r\n\r\n");
            string tituloMenu2 = "\r\n\r\n---------------------------- NOVAS HABILIDADES! ---------------------------\r\n\r\n";
            Console.WriteLine(tituloMenu2);
            Console.WriteLine($"E agora você vai conhecer o sistema de habilidades e sentimentos do seu pokémon.\r\n" +
                $"Cada um desses status tem seu valor aumentado ou diminuido\r\n" +
                $"de acordo com as atividades que seu pokémon irá praticar!\r\n\r\n" +
                $"O status de Satisfeito representa o nível de fome que seu Pokémon está sentindo.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE SATISFEITO: {pokemonAdopted.Satisfeito}\r\n\r\n" +
                $"O status de Humor representa o nível de alegria e entusiasmo para brincar.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE HUMOR: {pokemonAdopted.Humor}\r\n\r\n" +
                $"O status de Disposição representa o nível de cansaço e necessidade de sono do Pokémon.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE DISPOSIÇÂO: {pokemonAdopted.Disposicao}\r\n\r\n" +
                $"E o ultimo status é o de Limpeza, que indica o quão limpo está seu Pokémon.\r\n" +
                $"E atualmente, seu {nomePokemon} está com NIVEL DE LIMPEZA: {pokemonAdopted.Limpeza}\r\n\r\n");
            Console.WriteLine($"Agora você já tem o seu Pokémon! Seu {nomePokemon} está muito feliz\r\n" +
                $"de ser seu novo mascote! E agora, você já pode dar carinho, atenção e amor a ele!\r\n\r\n" +
                $"Vamos conhecer quais atividades você pode fazer com seu novo bichinho?\r\n" +
                $"1 - Conhecer atividades\r\n2 - Ver informações completas do {nomePokemon}\r\n3 - Sair");
        }

        public static void InfosEStatusPokemon(string nomePessoa, PokemonAdopted pokemonAdopted)
        {
            string tituloMenu = "\r\n\r\n--------------------- INFORMAÇÕES E STATUS DO POKÉMON ---------------------\r\n\r\n";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"SEU NOME: {nomePessoa}\r\n" +
                $"NOME DO POKÉMON: {pokemonAdopted.PokemonInfo.name}\r\n" +
                $"NÚMERO ID NA POKÉDEX DO POKÉMON: {pokemonAdopted.PokemonInfo.id}\r\n" +
                $"PESO DO POKÉMON: {pokemonAdopted.PokemonInfo.height}\r\n" +
                $"DATA DE ADOÇÃO DO POKÉMON: {pokemonAdopted.DataAdocao}\r\n" +
                $"NÍVEL DE SATISFEITO: {pokemonAdopted.Satisfeito}\r\n" +
                $"NÍVEL DE HUMOR: {pokemonAdopted.Humor}\r\n" +
                $"NÍVEL DE DISPOSIÇÂO: {pokemonAdopted.Disposicao}\r\n" +
                $"NIVEL DE LIMPEZA: {pokemonAdopted.Limpeza}\r\n");
        }


        public static void ConhecerAtividades(string nomePessoa, string nomePokemon)
        {
            string tituloMenu = "\r\n\r\n----------------------------- ATIVIDADES ----------------------------\r\n\r\n";
            Console.WriteLine(tituloMenu);
            Console.WriteLine($"Há diversas atividades que você pode fazer com seu {nomePokemon}!\r\n" +
                $"Vamos dar uma olhada?\r\n" +
                $"Para isso, é necessário que você entenda que cada atividade afeta diretamente os status\r\n" +
                $"gerais do seu pokemon. Vou te mostrar cada atividade e seu impacto no seu mascote:\r\n");
            Console.WriteLine($"STATUS SATISFEITO:\r\nCOMER:\r\n\r\n " +
                $" - Cookies de starfruit\r\n   (+1 SATISFEITO)\r\n   (-1 LIMPEZA)\r\n\r\n" +
                $" - Combo de frutas azuis\r\n   (+2 SATISFEITO)\r\n   (+1 DISPOSIÇÃO)\r\n   (-2 LIMPEZA)\r\n\r\n" +
                $" - Lanche mexicano completo\r\n   (+3 SATISFEITO)\r\n   (+1 HUMOR)\r\n   (+2 DISPOSIÇÃO)\r\n   (-3 LIMPEZA)\r\n\r\n\r\n" +
                $" - Banquete de pães\r\n   (+6 SATISFEITO)\r\n   (+2 HUMOR)\r\n   (+3 DISPOSIÇÃO)\r\n   (-4 LIMPEZA)\r\n\r\n\r\n" +
                $"STATUS HUMOR:\r\nBRINCAR:\r\n\r\n" +
                $" - Jogar rei das cartas\r\n   (+3 HUMOR)\r\n   (-1 LIMPEZA)\r\n\r\n\r\n" +
                $" - Brincar de ping-pong-peng\r\n   (-3 SATISFEITO)\r\n   (+5 HUMOR)\r\n   (-2 DISPOSIÇÃO)\r\n   (-4 LIMPEZA)\r\n\r\n\r\n" +
                $" - Brincar no parque dos ladrilhos\r\n   (-5 SATISFEITO)\r\n   (+8 HUMOR)\r\n   (-5 DISPOSIÇÃO)\r\n   (-7 LIMPEZA)\r\n\r\n\r\n" +
                $"STATUS DISPOSIÇÃO:\r\nDORMIR:\r\n\r\n" +
                $" - Tirar cochilo rápido\r\n   (+2 HUMOR)\r\n   (+2 DISPOSIÇÃO)\r\n\r\n\r\n" +
                $" - Dormir na rede\r\n   (-3 SATISFEITO)\r\n   (+4 HUMOR)\r\n   (+6 DISPOSIÇÃO)\r\n   (-5 LIMPEZA)\r\n\r\n\r\n" +
                $" - Sonhar uma noite inteira\r\n   (-8 SATISFEITO)\r\n   (+8 HUMOR)\r\n   (+10 DISPOSIÇÃO)\r\n   (-8 LIMPEZA)\r\n\r\n\r\n" +
                $"STATUS LIMPEZA:\r\nTOMAR:\r\n\r\n" +
                $" - Ducha rápida\r\n   (+1 HUMOR)\r\n   (+1 DISPOSIÇÃO)\r\n   (+3 LIMPEZA)\r\n\r\n\r\n" +
                $" - Banho cantante\r\n   (-3 SATISFEITO)\r\n   (+3 HUMOR)\r\n   (+3 DISPOSIÇÃO)\r\n   (+5 LIMPEZA)\r\n\r\n\r\n" +
                $" - Super banho pesado\r\n   (-4 SATISFEITO)\r\n   (+6 HUMOR)\r\n   (+5 DISPOSIÇÃO)\r\n   (+8 LIMPEZA)\r\n\r\n\r\n" +
                $"");
        }
    }
}