using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaigoDotNet
{
    /// <summary>
    /// Paigo data response.
    /// </summary>
    public class PaigoDataResponse<T> where T : class, new()
    {
        #region Public-Members

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; } = null;

        /// <summary>
        /// Data.
        /// </summary>
        [JsonPropertyName("data")]
        public T Data { get; set; } = null;

        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public PaigoDataResponse()
        {

        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
