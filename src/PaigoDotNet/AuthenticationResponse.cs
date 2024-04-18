namespace PaigoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Authentication response.
    /// </summary>
    public class AuthenticationResponse
    {
        #region Public-Members

        /// <summary>
        /// Access token.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = null;

        /// <summary>
        /// Number of seconds in which the token expires.
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpirationMilliseconds { get; set; } = 0;

        /// <summary>
        /// Timestamp at which the response was received.
        /// </summary>
        [JsonIgnore]
        public DateTime TimestampUtc { get; } = DateTime.UtcNow;

        /// <summary>
        /// Token type.
        /// </summary>
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = "Bearer";

        #endregion

        #region Private-Members
         
        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public AuthenticationResponse() 
        { 
        
        }

        #endregion

        #region Public-Methods
        
        #endregion

        #region Private-Methods

        #endregion
    }
}
