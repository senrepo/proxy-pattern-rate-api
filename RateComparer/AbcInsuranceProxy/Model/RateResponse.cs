using Newtonsoft.Json;

namespace AbcInsurance.Model
{
    public class RateResponse
    {
        [JsonProperty("Premium")]
        public double Premium { get; set; }
        [JsonProperty("TermInMonths")]
        public int TermInMonths { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }

    }
}
