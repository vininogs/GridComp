using Newtonsoft.Json;

namespace Reports
{
    public class Contadores
    {
        public string Empresa { get; set; }

        [JsonProperty("Total Comprovantes")]
        public int TotalComprovantes { get; set; }
    }
}
