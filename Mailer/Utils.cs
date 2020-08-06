namespace Mailer
{
    internal static class Utils
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string str)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                return true;
            return false;
        }
    }
}
