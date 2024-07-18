namespace Application.Domain;

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string HolderName { get; set; }
        public string SecurityCode { get; set; }
    }