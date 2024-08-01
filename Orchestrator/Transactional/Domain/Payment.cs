namespace Application.Domain;

    public class Payment
    {
        public Guid Id { get; set; }
        public Guid CorrelationId { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string HolderName { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }

    }