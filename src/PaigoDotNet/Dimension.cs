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
    public class Dimension
    {
        #region Public-Members

        /// <summary>
        /// Dimension name.
        /// </summary>
        [JsonPropertyName("dimensionName")]
        public string DimensionName { get; set; } = null;

        /// <summary>
        /// Consumption unit.
        /// </summary>
        [JsonPropertyName("consumptionUnit")]
        public ConsumptionUnit ConsumptionUnit { get; set; } = null;

        /// <summary>
        /// Usage increment.
        /// </summary>
        [JsonPropertyName("usageIncrement")]
        public string UsageIncrement { get; set; } = null;

        /// <summary>
        /// Usage entitlement.
        /// </summary>
        [JsonPropertyName("usageEntitlement")]
        public string UsageEntitlement { get; set; } = null;

        /// <summary>
        /// Aggregation interval.
        /// </summary>
        [JsonPropertyName("aggregationInterval")]
        public string AggregationInterval { get; set; } = null;

        /// <summary>
        /// Aggregation method.
        /// </summary>
        [JsonPropertyName("aggregationMethod")]
        public string AggregationMethod { get; set; } = null;

        /// <summary>
        /// Dimension ID.
        /// </summary>
        [JsonPropertyName("dimensionId")]
        public string Id { get; set; } = null;

        /// <summary>
        /// Measurement.
        /// </summary>
        [JsonPropertyName("measurement")]
        public Measurement Measurement { get; set; } = null;

        /// <summary>
        /// Rounding.
        /// </summary>
        [JsonPropertyName("rounding")]
        public string Rounding { get; set; } = null;

        /// <summary>
        /// Overage allowed.
        /// </summary>
        [JsonPropertyName("overageAllowed")]
        public string OverageAllowed { get; set; } = null;

        /// <summary>
        /// Consumption price.
        /// </summary>
        [JsonPropertyName("consumptionPrice")]
        public string ConsumptionPrice { get; set; } = null;

        /// <summary>
        /// Sample type.
        /// </summary>
        [JsonPropertyName("sampleType")]
        public string SampleType { get; set; } = null;

        /// <summary>
        /// Schedule.
        /// </summary>
        [JsonPropertyName("paymentSchedule")]
        public string Schedule { get; set; } = null;

        /// <summary>
        /// Metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; } = null;

        /// <summary>
        /// Tiers.
        /// </summary>
        [JsonPropertyName("tiers")]
        public object Tiers { get; set; } = null;

        /// <summary>
        /// Tiers group by metadata.
        /// </summary>
        [JsonPropertyName("tiersGroupByMetadata")]
        public object TiersGroupByMetadata { get; set; } = null;

        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate.
        /// </summary>
        public Dimension() 
        {
            
        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}
