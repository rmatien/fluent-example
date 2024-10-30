namespace FluentExample.Helpers
{
    public interface ITelegramBotService
    {
        string GetChatID();

        Task SendMessage(string chatID, string message);
    }
}
