using SithecWS.Api.Utilities;

namespace SithecWS.Api.Data
{
    public class MathData
    {
        private static MathData? _instance;

        public static MathData GetMathData()
        {
            if (_instance == null)
                _instance = new MathData();
            return _instance;
        }

        public async Task<double> GetMathSum(float val1, float val2)
        {
            await Task.Delay(500);
            try
            {
                var result = val1 + val2;
                if (result.ToString().Validate())
                    return Math.Round(result, 0);
                return Math.Round(result, 2);
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }            
        }

        public async Task<double> GetMathSubtract(float val1, float val2)
        {
            await Task.Delay(500);
            try
            {
                var result = val1 - val2;
                if (result.ToString().Validate())
                    return Math.Round(result, 0);
                return Math.Round(result, 2);
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }

        public async Task<double> GetMathMultiply(float val1, float val2)
        {
            await Task.Delay(500);
            try
            {
                var result = val1 * val2;
                if (result.ToString().Validate())
                    return Math.Round(result, 0);
                return Math.Round(result, 2);
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }

        public async Task<double> GetMathDivide(float val1, float val2)
        {
            await Task.Delay(500);
            try
            {
                float result = val1 / val2;
                if (result.ToString().Validate())
                    return Math.Round(result, 0);
                return Math.Round(result, 2);
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }
    }
}