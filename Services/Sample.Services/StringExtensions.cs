namespace Sample.Services
{
    static class StringExtensions
    {
        public static string SanitizeSql(this string str)
        {
            return str.Replace("'", "''");
        }
    }
}
