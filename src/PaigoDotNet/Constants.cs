using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaigoDotNet
{
    internal static class Constants
    {
        #region General

        internal static string TimestampFormat = "yyyy-MM-ddTHH:mm:ssZ";

        #endregion

        #region Authentication

        internal static string AudienceUrl = "https://qnonyh1pc7.execute-api.us-east-1.amazonaws.com";
        internal static string GrantType = "client_credentials";

        #endregion

        #region REST

        internal static string JsonContentType = "application/json";

        #endregion
    }
}
