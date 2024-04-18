namespace PaigoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Authentication request.
    /// </summary>
    public class AuthenticationRequest
    {
        #region Public-Members

        /// <summary>
        /// Audience URL.  By default use https://qnonyh1pc7.execute-api.us-east-1.amazonaws.com.
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience
        {
            get
            {
                return _Audience;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(Audience));
                Uri audience = new Uri(value);
                if (!value.EndsWith("/")) value += "/";
                _Audience = value;
            }
        }

        /// <summary>
        /// Grant type.  By default use client_credentials.
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType
        {
            get
            {
                return _GrantType;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(GrantType));
                _GrantType = value;
            }
        }

        /// <summary>
        /// Client ID.
        /// </summary>
        [JsonPropertyName("client_id")]
        public string ClientId
        {
            get
            {
                return _ClientId;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(ClientId));
                _ClientId = value;
            }
        }

        /// <summary>
        /// Client secret.
        /// </summary>
        [JsonPropertyName("client_secret")]
        public string ClientSecret
        {
            get
            {
                return _ClientSecret;
            }
            set
            {
                if (String.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(ClientSecret));
                _ClientSecret = value;
            }
        }
         
        #endregion

        #region Private-Members

        private string _Audience = Constants.AudienceUrl;
        private string _GrantType = Constants.GrantType;
        private string _ClientId = null;
        private string _ClientSecret = null;

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public AuthenticationRequest() 
        { 
        
        }

        #endregion

        #region Public-Methods
        
        #endregion

        #region Private-Methods

        #endregion
    }
}
