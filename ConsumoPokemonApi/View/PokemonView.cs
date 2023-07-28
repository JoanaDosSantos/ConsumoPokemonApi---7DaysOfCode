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

        public static void AdotarPokemon(string nomePessoa, string nomePokemon, PokemonAdopted pokemonAdopted) {
            Console.WriteLine($"Parabéns {nomePessoa}! Seu {nomePokemon} foi escolhido!\r\nVamos dar uma olhada nos atributos do seu {nomePokemon}?");
            Console.WriteLine($"NOME DO POKÉMON: {pokemonAdopted.PokemonInfo.name}\r\n" +
                $"NÚMERO ID NA POKÉDEX DO POKÉMON: {pokemonAdopted.PokemonInfo.id}\r\n" +
                $"PESO DO POKÉMON: {pokemonAdopted.PokemonInfo.height}\r\n" +
                $"DATA DE ADOÇÃO DO POKÉMON: {pokemonAdopted.DataAdocao}\r\n");
            Console.WriteLine($"E agora você vai conhecer o sistema de habilidades e sentimentos do seu pokémon.\r\n" +
                $"Cada um desses status tem seu valor aumentado ou diminuido\r\n" +
                $"de acordo com as atividades que seu pokémon irá praticar!\r\n\r\n" +
                $"O status de Satisfeito representa o nível de fome que seu Pokémon está sentindo.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE SATISFEITO: {pokemonAdopted.Satisfeito}\r\n" +
                $"O status de Humor representa o nível de alegria e entusiasmo para brincar.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE HUMOR: {pokemonAdopted.Humor}\r\n" +
                $"O status de Disposição representa o nível de cansaço e necessidade de sono do Pokémon.\r\n" +
                $"Atualmente, seu {nomePokemon} está com NIVEL DE DISPOSIÇÂO: {pokemonAdopted.Disposicao}\r\n" +
                $"E o ultimo status é o de Limpeza, que indica o quão limpo está seu Pokémon.\r\n" +
                $"E atualmente, seu {nomePokemon} está com NIVEL DE LIMPEZA: {pokemonAdopted.Limpeza}\r\n");
        }

        public static void ExibirInformacoesPokemon(InfoPokemon listaPokemons)
        {
            string tituloMenu = "---------------------- INFORMAÇÕES DESTE POKÉMON ----------------------";
            Console.WriteLine(tituloMenu);

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

            Console.WriteLine("\r\nE agora, o que deseja?");
            Console.WriteLine($"1 - Adotar o {listaPokemons.name}\r\n2 - Voltar");
        }
    }
}
