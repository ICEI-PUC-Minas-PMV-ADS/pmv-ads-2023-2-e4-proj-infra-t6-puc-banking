﻿using Microsoft.EntityFrameworkCore;

namespace PUCBanking.Identity.API.Repositories {
    public class UserRepository {
        private readonly IdentityContext _context;
        public UserRepository(IdentityContext context) {
            _context = context;
        }
        public async Task<User?> FindUser(string email) {

            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }
        public async Task AddUser(User user) {

            if (user is null) {
                throw new ArgumentNullException(nameof(user));
            }

            if (await _context.Users
                .AnyAsync(x => x.Email == user.Email)) {
                throw new InvalidOperationException("Usuário já cadastrado.");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
