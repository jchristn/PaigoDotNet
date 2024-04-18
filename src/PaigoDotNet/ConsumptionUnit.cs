using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaigoDotNet
{
    /// <summary>
    /// Dimension.
    /// </summary>
    public class ConsumptionUnit
    {
        #region Public-Members

        /// <summary>
        /// Unit.
        /// </summary>
        [JsonPropertyName("unit")]
        public string Unit { get; set; } = null;

        /// <summary>
        /// Type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null;


        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public ConsumptionUnit()
        {

        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
