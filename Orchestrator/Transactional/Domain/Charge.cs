namespace Application.Domain;

    public class Charge
    {
        public string ClientEmail { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

    }