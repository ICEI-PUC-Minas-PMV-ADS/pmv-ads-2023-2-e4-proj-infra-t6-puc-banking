using System.Text.RegularExpressions;

namespace PUCBanking.Shared.Validations {
    public static class PasswordValidations {
        public static void Normalize(ref string password) {
            password = password.Trim();
        }
        public static bool IsBlank(string password) {
            return string.IsNullOrEmpty(password);
        }
        public static bool IsInvalid(string password) {

            string pattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$";
            var isMatch = Regex.IsMatch(password, pattern);

            return !isMatch;
        }
    }
}
