namespace PUCBanking.Identity.API.Models {
    public class User {
        public static User CreateCustomer(string name, string email, string password) {
            return new User(Guid.NewGuid(), name, email, password, UserRole.Customer, UserStatus.Actived);
        }

        public static User CreateAdmin(string name, string email, string password) {
            return new User(Guid.NewGuid(), name, email, password, UserRole.Admin, UserStatus.Actived);
        }
        private User() { }
        private User(Guid id,
            string name,
            string email,
            string password,
            UserRole role,
            UserStatus status) {

            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Role = role;
            this.Status = status;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public UserRole Role { get; private set; }
        public UserStatus Status { get; private set; }
    }

    public enum UserRole {
        Admin,
        Customer
    }

    public enum UserStatus {
        Actived,
        Desactived
    }
}
