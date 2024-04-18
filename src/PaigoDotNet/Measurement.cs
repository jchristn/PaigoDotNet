using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaigoDotNet
{
    /// <summary>
    /// Measurement.
    /// </summary>
    public class Measurement
    {
        #region Public-Members

        /// <summary>
        /// Measurement mode.
        /// </summary>
        [JsonPropertyName("measurementMode")]
        public string Mode { get; set; } = null;

        /// <summary>
        /// Measurement configuration.
        /// </summary>
        [JsonPropertyName("measurementConfiguration")]
        public object Configuration { get; set; } = null;

        /// <summary>
        /// Measurement name.
        /// </summary>
        [JsonPropertyName("measurementName")]
        public string Name { get; set; } = null;

        /// <summary>
        /// Measurement ID.
        /// </summary>
        [JsonPropertyName("measurementId")]
        public string Id { get; set; } = null;
        
        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public Measurement()
        {

        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
