using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PUCBanking.Identity.API.Services {
    public sealed class TokenService {

        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly JwtBearerOptions _options;
        private readonly byte[] _encodedSecretKey;
        public TokenService(IOptions<IdentityOptions> options) {
            _tokenHandler = new JwtSecurityTokenHandler();
            _options = options.Value.JwtBearer;
            _encodedSecretKey = Encoding.ASCII.GetBytes(_options.SecretKey);
        }
        public string GenerateToken(User user) {

            var tokenDescriptor = CreateTokenDescriptor(user);
            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
        public string GenerateToken(IEnumerable<Claim> claims) {

            var tokenDescriptor = CreateTokenDescriptor(claims);
            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
        public string GenerateRefreshToken() {

            var randomNumber = new byte[31];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public bool IsExpiredToken(string token) {

            var jwtToken = _tokenHandler.ReadJwtToken(token);

            if (jwtToken.ValidTo < DateTime.UtcNow) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool ValidateToken(string token, string username) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_encodedSecretKey),
                ValidIssuer = _options.Issuer,
                ValidateIssuer = _options.ValidateIssuer,
                ValidAudience = _options.Audience,
                ValidateAudience = _options.ValidateAudience,
                ClockSkew = TimeSpan.Zero
            };

            try {
                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                if (claimsPrincipal.Identity.Name == username) {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception) {
                return false;
            }
        }
        private SecurityTokenDescriptor CreateTokenDescriptor(User user) {
            return new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(_options.Expires),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_encodedSecretKey), SecurityAlgorithms.HmacSha256Signature)
            };
        }
        private SecurityTokenDescriptor CreateTokenDescriptor(IEnumerable<Claim> claims) {
            return new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_options.Expires),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(_encodedSecretKey), SecurityAlgorithms.HmacSha256Signature)
            };
        }
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token) {

            var tokenValidationParameters = new TokenValidationParameters {
                ValidAudience = _options.Audience,
                ValidateAudience = _options.ValidateAudience,
                ValidIssuer = _options.Issuer,
                ValidateIssuer = _options.ValidateIssuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(_encodedSecretKey),
                ValidateLifetime = false
            };

            var principal = _tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
               !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                throw new SecurityTokenException("Invalid token.");

            return principal;
        }
    }
}
