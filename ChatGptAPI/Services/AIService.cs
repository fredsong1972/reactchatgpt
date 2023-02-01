using ChatGptAPI.Models;
using ChatGptAPI.Settings;
using Newtonsoft.Json;
using System.Text;

namespace ChatGptAPI.Services
{
    public class AIService : IAIService
    {
        OpenAISettings _settings;
        public AIService(OpenAISettings settings)
        {
            _settings = settings;
        }

        public async Task<string> CompleteQuestion(string question)
        {
            try
            {
                var completionRequest = new CompletionRequest
                {
                    Model = "text-davinci-003",
                    Prompt = question,
                    Temperature = 0.7,
                    TopP = 1.0,
                    MaxTokens = 256,
                    PresencePenalty = 0,
                    FrequencyPenalty = 0
                };
                var content = new StringContent(JsonConvert.SerializeObject(completionRequest), Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), $"{_settings.BaseURL}/v1/completions"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_settings.APIKey}");
                        request.Content = content;

                        var response = await httpClient.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var json = await response.Content.ReadAsStringAsync();
                        var completionResponse = JsonConvert.DeserializeObject<CompletionResponse>(json);
                        if (completionResponse != null)
                        {
                            return completionResponse.Choices[0].Text;
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return "Sorry, I don't understand your question.";
        }
    }
}
