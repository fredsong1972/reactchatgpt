using ChatGptAPI.Models;
using ChatGptAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : ControllerBase
    {
        private readonly IAIService _aiService;
        public OpenAIController(IAIService service) 
        {
            _aiService= service;
        }
        // POST api/<OpenAIController>
        [HttpPost]
        public async Task<string> Post([FromBody] ChatMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                return string.Empty;
            }
            var answer = await _aiService.CompleteQuestion(message.Content);
            return answer.TrimStart('\n');
        }
    }
}
