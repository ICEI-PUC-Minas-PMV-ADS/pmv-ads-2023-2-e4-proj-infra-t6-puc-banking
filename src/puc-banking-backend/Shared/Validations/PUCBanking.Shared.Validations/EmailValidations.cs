using System.Text.RegularExpressions;

namespace PUCBanking.Shared.Validations {
    public static class EmailValidations {
        public static void Normalize(ref string email) {
            email = email.Trim();
        }
        public static bool IsBlank(string email) {
            return string.IsNullOrEmpty(email);
        }
        public static bool IsInvalidEmail(string email) {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            bool isMatch = Regex.IsMatch(email, pattern);

            return !isMatch;
        }
    }
}
