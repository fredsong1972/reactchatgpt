namespace ChatGptAPI.Services
{
    public interface IAIService
    {
        Task<string> CompleteQuestion(string question);
    }
}
