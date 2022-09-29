using Microsoft.AspNetCore.Mvc;
using SithecWS.Api.Data;
using SithecWS.Api.Models;
using SithecWS.Api.Utilities;
using SithecWS.Api.Models.Response;

namespace SithecWS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private static readonly MathData mathData = MathData.GetMathData();

        [HttpPost(Name = "GetMath")]
        public async Task<MathResponse> GetMath(MathModel request)
        {
            var result = new MathResponse();
            var _typeOperation = request.TypeOperation;
            try
            {
                if (_typeOperation == TypeOperation.sum.ToString() || _typeOperation == VariableGlobal.Sum)
                {
                    var data = await mathData.GetMathSum(request.FirstValue, request.SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.rest.ToString() || _typeOperation == VariableGlobal.Rest)
                {
                    var data = await mathData.GetMathSubtract(request.FirstValue, request.SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.mult.ToString() || _typeOperation == VariableGlobal.Mult)
                {
                    var data = await mathData.GetMathMultiply(request.FirstValue, request.SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.div.ToString() || _typeOperation == VariableGlobal.Div)
                {
                    var data = await mathData.GetMathDivide(request.FirstValue, request.SecondValue);
                    result.Result = data.ToString();
                }
            }
            catch (ArithmeticException ex)
            {
                result.Result = GetExceptionMessage(ex);
            }
            return result;
        }

        [HttpGet(Name = "GetMath")]
        public async Task<MathResponse> GetMath(string typeOperation, float FirstValue, float SecondValue)
        {
            var result = new MathResponse();
            var _typeOperation = typeOperation;
            try
            {
                if (_typeOperation == TypeOperation.sum.ToString() || _typeOperation == VariableGlobal.Sum)
                {
                    var data = await mathData.GetMathSum(FirstValue, SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.rest.ToString() || _typeOperation == VariableGlobal.Rest)
                {
                    var data = await mathData.GetMathSubtract(FirstValue, SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.mult.ToString() || _typeOperation == VariableGlobal.Mult)
                {
                    var data = await mathData.GetMathMultiply(FirstValue, SecondValue);
                    result.Result = data.ToString();
                }

                if (_typeOperation == TypeOperation.div.ToString() || _typeOperation == VariableGlobal.Div)
                {
                    var data = await mathData.GetMathDivide(FirstValue, SecondValue);
                    result.Result = data.ToString();
                }
            }
            catch (ArithmeticException ex)
            {
                result.Result = GetExceptionMessage(ex);
            }
            return result;
        }

        private string GetExceptionMessage(ArithmeticException ex)
        {
            return ex.Message == "One or more errors occurred." ? ex.InnerException.InnerException.Message : ex.Message;
        }
    }
}