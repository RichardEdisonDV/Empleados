namespace Application.Extensions.Values
{
    public static class FallbackValuesExtension
    {
        public static string? FallbackValue(this string? value, string? fallbackValue)
        {
            try
            {
                return string.IsNullOrEmpty(value) ? fallbackValue : value;
            }
            catch (NullReferenceException)
            {
                return fallbackValue;
            }
        }
    }
}
