namespace ConsumoPokemonApi.Model
{
    public class PokemonAdopted
    {
        public InfoPokemon PokemonInfo { get; set; }
        public int Fome { get; set; }
        public int Sono { get; set; }
        public DateTime? DataAdocao { get; set; }
    }
}