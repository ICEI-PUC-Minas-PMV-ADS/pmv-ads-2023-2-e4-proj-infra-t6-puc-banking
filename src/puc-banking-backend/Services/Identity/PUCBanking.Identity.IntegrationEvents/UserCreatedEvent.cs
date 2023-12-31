﻿using PUCBanking.Shared.EventBus;

namespace PUCBanking.Identity.IntegrationEvents {
    public class UserCreatedEvent : IIntegrationEvent {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
