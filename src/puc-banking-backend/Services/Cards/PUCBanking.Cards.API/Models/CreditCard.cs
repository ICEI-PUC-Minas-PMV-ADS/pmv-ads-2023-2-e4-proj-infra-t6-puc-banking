﻿namespace PUCBanking.Cards.API.Models {
    public class CreditCard {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = null!;
        public string HolderName { get; set; } = null!;
        public long Number { get; set; }
        public int CVV { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public double CreditLimit { get; set; }
        public double AvailableCreditLimit { get; set; }
    }
}
