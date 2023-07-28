namespace ConsumoPokemonApi.Model
{
    public class InfoPokemon
    {
        public List<PokemonAbilities>? abilities { get; set; }
        public int height { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public List<PokemonTypes>? types { get; set; }

    }
}
