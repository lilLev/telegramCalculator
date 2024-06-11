namespace TelegramCalculator.UI.Constants
{
    internal class CalculatorError
    {
        public string Code { get; set; }

        public string ModalHeader { get; set; }

        public string Message { get; set; }

        public bool IsCritical { get; set; }

        public CalculatorError(string modalHeader, string message, bool isCritical, string code = null)
        {
            Code = code;
            ModalHeader = modalHeader;
            Message = message;
            IsCritical = isCritical;
        }

        public static CalculatorError FloodWait => new (
            modalHeader: "Too many requests",
            message: "Too many requests were send from you client, please try again in {0}s",
            isCritical: true,
            code: "FLOOD_WAIT_X");

        public static CalculatorError UnexpectedError => new (
            modalHeader: "Unexpected error",
            message: "Unexpected error ocurred.",
            isCritical: true);

        public static CalculatorError ChatNotFound => new(
            modalHeader: "No messages found",
            message: "Chat was not found, or has no messages for selected date.",
            isCritical: false);
    }


}
