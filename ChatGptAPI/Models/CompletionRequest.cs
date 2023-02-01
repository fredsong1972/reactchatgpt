using Newtonsoft.Json;

namespace ChatGptAPI.Models
{
    public class CompletionRequest
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("frequency_penalty")]
        public double FrequencyPenalty { get; set; }

        [JsonProperty("presence_penalty")]
        public double PresencePenalty { get; set; }

        [JsonProperty("top_p")]
        public double TopP { get; set; }

        [JsonProperty("max_tokens")]
        public int MaxTokens { get; set; }
    }
}
