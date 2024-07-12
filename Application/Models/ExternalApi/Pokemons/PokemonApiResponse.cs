using Newtonsoft.Json;

namespace Application.Models.ExternalApi.Pokemons
{
    public partial class PokemonApiResponse
    {
        [JsonProperty("base_experience")]
        public long BaseExperience { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public Uri? LocationAreaEncounters { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("order")]
        public long Order { get; set; }


        [JsonProperty("sprites")]
        public Sprites? Sprites { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }

    public partial class Sprites
    {
        [JsonProperty("back_default")]
        public Uri? BackDefault { get; set; }

        [JsonProperty("back_female")]
        public Uri? BackFemale { get; set; }

        [JsonProperty("back_shiny")]
        public Uri? BackShiny { get; set; }

        [JsonProperty("back_shiny_female")]
        public Uri? BackShinyFemale { get; set; }

        [JsonProperty("front_default")]
        public Uri? FrontDefault { get; set; }

        [JsonProperty("front_female")]
        public Uri? FrontFemale { get; set; }

        [JsonProperty("front_shiny")]
        public Uri? FrontShiny { get; set; }

        [JsonProperty("front_shiny_female")]
        public Uri? FrontShinyFemale { get; set; }
    }
}
