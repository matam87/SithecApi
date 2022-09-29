
namespace SithecWS.Api.Utilities
{
    public static class Extensions
    {
        public static float Truncate(this float value, int digits = 2)
        {
            double mult = Math.Pow(10.0, digits);
            double result = Math.Truncate(mult * value) / mult;
            return (float)result;
        }

        public static bool Validate(this string value)
        {
            var result = false;
            if (int.TryParse(value, out _))
                result = true;
            return result;
        }
    }
}