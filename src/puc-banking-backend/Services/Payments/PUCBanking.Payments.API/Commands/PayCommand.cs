namespace PUCBanking.Payments.API.Commands {
    public class PayCommand : ICommand {
        public double Value { get; set; }
        public string Name { get; set; } = null!;
        public long CardNumber { get; set; }
        public string CardHolderName { get; set; } = null!;
        public int CardCVV { get; set; }
        public string CardExpires { get; set; }
    }
}
