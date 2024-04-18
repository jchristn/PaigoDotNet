using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaigoDotNet
{
    /// <summary>
    /// Collect usage request.
    /// </summary>
    public class CollectUsageRequest
    {
        #region Public-Members

        /// <summary>
        /// Dimension ID.
        /// </summary>
        [JsonPropertyName("dimensionId")]
        public string DimensionId { get; set; } = null;

        /// <summary>
        /// Timestamp in UTC time.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; } = null;

        /// <summary>
        /// Customer ID.
        /// </summary>
        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } = null;

        /// <summary>
        /// Record value.
        /// </summary>
        [JsonPropertyName("recordValue")]
        public string Value { get; set; } = null;

        /// <summary>
        /// Metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; } = null;
         
        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public CollectUsageRequest()
        {
            Timestamp = DateTime.UtcNow.ToString(Constants.TimestampFormat);
        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
