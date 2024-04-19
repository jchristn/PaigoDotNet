namespace PaigoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Security.Authentication;
    using System.Threading;
    using System.Threading.Tasks;
    using RestWrapper;
    using SerializationHelper;

    /// <summary>
    /// Paigo client.  Paigo's API documentation can be found at: http://www.api.docs.paigo.tech/
    /// </summary>
    public class PaigoClient
    {
        #region Public-Members

        /// <summary>
        /// Method to invoke to send log messages.
        /// </summary>
        public Action<string> Logger { get; set; } = null;

        /// <summary>
        /// API endpoint URL.  
        /// </summary>
        public string ApiEndpoint
        {
            get
            {
                return _ApiEndpoint.ToString();
            }
        }

        /// <summary>
        /// Authentication endpoint URL.
        /// </summary>
        public string AuthEndpoint
        {
            get
            {
                return _AuthEndpoint.ToString();
            }
        }

        /// <summary>
        /// Authentication details, if authenticated.
        /// </summary>
        public AuthenticationResponse AuthenticationDetails
        {
            get
            {
                return _Authentication;
            }
        }

        /// <summary>
        /// Boolean to indicate if the client is authenticated.
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                if (_Authentication == null) return false;
                if (String.IsNullOrEmpty(_Authentication.AccessToken)) return false;
                DateTime now = DateTime.UtcNow;
                DateTime exp = _Authentication.TimestampUtc.AddMilliseconds(_Authentication.ExpirationMilliseconds);
                return (exp > now);
            }
        }

        #endregion

        #region Private-Members

        private string _Header = "[PaigoClient] ";
        private string _ClientId = null;
        private string _ClientSecret = null;
        private string _ApiEndpoint = "https://api.prod.paigo.tech/";
        private string _AuthEndpoint = "https://auth.paigo.tech/oauth/token/";
        private AuthenticationResponse _Authentication = null;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate the Paigo client.  
        /// For the endpoint URL, use https://api.prod.paigo.tech/ for production.
        /// 
        /// </summary>
        /// <param name="clientId">Client ID, provided by Paigo.</param>
        /// <param name="clientSecret">Client secret, provided by Paigo.</param>
        /// <param name="apiEndpoint">API endpoint URL.</param>
        /// <param name="authEndpoint">Authentication endpoint URL.</param>
        public PaigoClient(
            string clientId, 
            string clientSecret, 
            string apiEndpoint = "https://api.prod.paigo.tech/",
            string authEndpoint = "https://auth.paigo.tech/oauth/token")
        {
            if (String.IsNullOrEmpty(clientId)) throw new ArgumentNullException(nameof(clientId));
            if (String.IsNullOrEmpty(clientSecret)) throw new ArgumentNullException(nameof(clientSecret));
            if (String.IsNullOrEmpty(apiEndpoint)) throw new ArgumentNullException(nameof(apiEndpoint));
            if (String.IsNullOrEmpty(authEndpoint)) throw new ArgumentNullException(nameof(authEndpoint));

            Uri api = new Uri(apiEndpoint);
            Uri auth = new Uri(authEndpoint);

            if (!apiEndpoint.EndsWith("/")) apiEndpoint += "/";
            if (!authEndpoint.EndsWith("/")) authEndpoint += "/";

            _ClientId = clientId;
            _ClientSecret = clientSecret;
            _ApiEndpoint = apiEndpoint;
            _AuthEndpoint = authEndpoint;
        }

        #endregion

        #region Public-Methods

        /// <summary>
        /// Authenticate.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task Authenticate(CancellationToken token = default)
        {
            using (RestRequest req = new RestRequest(AuthEndpoint, HttpMethod.Post))
            { 
                req.ContentType = Constants.JsonContentType;

                AuthenticationRequest authReq = new AuthenticationRequest
                {
                    ClientId = _ClientId,
                    ClientSecret = _ClientSecret
                };

                string json = Serializer.SerializeJson(authReq, true);

                using (RestResponse resp = await req.SendAsync(json, token).ConfigureAwait(false))
                {
                    if (resp != null && IsSuccess(resp.StatusCode))
                    {
                        Log("success response from " + AuthEndpoint + ": " + resp.StatusCode);
                        _Authentication = Serializer.DeserializeJson<AuthenticationResponse>(resp.DataAsString);
                    }
                    else if (resp != null)
                    {
                        Log("failure response from " + AuthEndpoint + ": " + resp.StatusCode + Environment.NewLine + resp.DataAsString);
                        throw new AuthenticationException();
                    }
                    else
                    {
                        Log("unable to connect to server at " + AuthEndpoint);
                        throw new WebException();
                    }
                }
            }
        }

        /// <summary>
        /// Get dimensions.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<List<Dimension>> GetDimensions(CancellationToken token = default)
        {
            if (!IsAuthenticated) throw new AuthenticationException("Please authenticate prior to invoking this API.");

            string url = ApiEndpoint + "dimensions";

            using (RestRequest req = new RestRequest(url, HttpMethod.Get))
            {
                req.Authorization.BearerToken = _Authentication.AccessToken;

                using (RestResponse resp = await req.SendAsync(token).ConfigureAwait(false))
                {
                    if (resp != null && IsSuccess(resp.StatusCode))
                    {
                        Log("success response from " + url + ": " + resp.StatusCode);
                        PaigoDataResponse<List<Dimension>> dimensions = Serializer.DeserializeJson<PaigoDataResponse<List<Dimension>>>(resp.DataAsString);
                        return dimensions.Data;
                    }
                    else if (resp != null)
                    {
                        Log("failure response from " + url + ": " + resp.StatusCode + Environment.NewLine + resp.DataAsString);
                        throw new WebException("Non-success response reported from server.");
                    }
                    else
                    {
                        Log("unable to connect to server at " + url);
                        throw new WebException();
                    }
                }
            }
        }

        /// <summary>
        /// Get offerings.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task<List<Offering>> GetOfferings(CancellationToken token = default)
        {
            if (!IsAuthenticated) throw new AuthenticationException("Please authenticate prior to invoking this API.");

            string url = ApiEndpoint + "offerings";

            using (RestRequest req = new RestRequest(url, HttpMethod.Get))
            {
                req.Authorization.BearerToken = _Authentication.AccessToken;

                using (RestResponse resp = await req.SendAsync(token).ConfigureAwait(false))
                {
                    if (resp != null && IsSuccess(resp.StatusCode))
                    {
                        Log("success response from " + url + ": " + resp.StatusCode);
                        PaigoDataResponse<List<Offering>> offerings = Serializer.DeserializeJson<PaigoDataResponse<List<Offering>>>(resp.DataAsString);
                        return offerings.Data;
                    }
                    else if (resp != null)
                    {
                        Log("failure response from " + url + ": " + resp.StatusCode + Environment.NewLine + resp.DataAsString);
                        throw new WebException("Non-success response reported from server.");
                    }
                    else
                    {
                        Log("unable to connect to server at " + url);
                        throw new WebException();
                    }
                }
            }
        }

        /// <summary>
        /// Collect usage.
        /// </summary>
        /// <param name="usageRequest">Usage request.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>Task.</returns>
        public async Task CollectUsage(CollectUsageRequest usageRequest, CancellationToken token = default)
        {
            if (!IsAuthenticated) throw new AuthenticationException("Please authenticate prior to invoking this API.");
            if (usageRequest == null) throw new ArgumentNullException(nameof(usageRequest));

            string url = ApiEndpoint + "usage";

            using (RestRequest req = new RestRequest(url, HttpMethod.Post))
            {
                req.Authorization.BearerToken = _Authentication.AccessToken;
                req.ContentType = Constants.JsonContentType;

                string json = Serializer.SerializeJson(usageRequest, true);

                using (RestResponse resp = await req.SendAsync(json, token).ConfigureAwait(false))
                {
                    if (resp != null && IsSuccess(resp.StatusCode))
                    {
                        Log("success response from " + url + ": " + resp.StatusCode);
                    }
                    else if (resp != null)
                    {
                        Log("failure response from " + url + ": " + resp.StatusCode + Environment.NewLine + resp.DataAsString);
                        throw new WebException("Non-success response reported from server.");
                    }
                    else
                    {
                        Log("unable to connect to server at " + url);
                        throw new WebException();
                    }
                }
            }
        }

        #endregion

        #region Private-Methods

        private void Log(string msg)
        {
            if (!String.IsNullOrEmpty(msg))
                Logger?.Invoke(_Header + msg);
        }

        private bool IsSuccess(int status)
        {
            return (status >= 200 && status <= 299);
        }
         
        #endregion
    }
}
