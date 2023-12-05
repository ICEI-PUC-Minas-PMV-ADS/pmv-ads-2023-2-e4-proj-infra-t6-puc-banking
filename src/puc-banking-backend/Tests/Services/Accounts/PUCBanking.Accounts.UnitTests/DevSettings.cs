using System.Text;

namespace PUCBanking.Accounts.UnitTests {
    public static class AsyncHelper {
        public static TResult RunSync<TResult>(this Task<TResult> task) {
            return task.GetAwaiter().GetResult();
        }
    }

    public static class StringUtils {
        public static string CreateLongString(string pattern, int times) {
            
            var stringBuilder = new StringBuilder();

            for(int i = 0; i < times; i++) {
                stringBuilder.Append(pattern);
            }

            return stringBuilder.ToString();
        }
    }
}
