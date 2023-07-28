namespace ConsumoPokemonApi.Model
{
    public class PokemonAdopted
    {
        public InfoPokemon PokemonInfo { get; set; }
        public int Satisfeito { get; set; }
        public int Humor { get; set; }
        public int Disposicao { get; set; }
        public int Limpeza { get; set; }
        public DateTime? DataAdocao { get; set; }
    }
}