﻿namespace PUCBanking.Identity.API.Queries {
    public class GetUserQueryResult : IQueryResult {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
