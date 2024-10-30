using System.ComponentModel.DataAnnotations;

namespace FluentExample.Helpers
{
    public class TelegramSettings
    {
        public const string Key = "TelegramBotSettings";

        [Required(ErrorMessage = "Token required")]
        public required string Token { get; set; }

        [Required(ErrorMessage = "Chat ID required")]
        public required string ChatID { get; set; }
    }
}
