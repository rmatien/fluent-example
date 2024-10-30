using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace FluentExample.Helpers
{
    public class TelegramBotService: ITelegramBotService
    {        
        private readonly TelegramSettings _settings;
        private readonly TelegramBotClient _client;
        
        public TelegramBotService(IOptions<TelegramSettings> telegramSettings)
        {
            _settings = telegramSettings.Value;
            _client = new TelegramBotClient(_settings.Token);
        }

        public string GetChatID() { return _settings.ChatID; }

        public async Task SendMessage(string chatID, string message)
        {
            await _client.SendTextMessageAsync(chatID, message,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
                );
        }
    }
}
