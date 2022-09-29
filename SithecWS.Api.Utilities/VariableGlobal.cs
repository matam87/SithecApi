
namespace SithecWS.Api.Utilities
{
    public static class VariableGlobal
    {
        public static string PathHumanData => Directory.GetCurrentDirectory() + "\\HumanData.json";

        #region Math
        public static string Sum => "+";

        public static string Rest => "-";

        public static string Mult => "*";

        public static string Div => "/";
        #endregion

        #region HumanData
        public static string StatusOk => "Ok";

        public static string Message => "Request processed successfully.";

        public static string StatusFail => "Error";
        #endregion

    }
}