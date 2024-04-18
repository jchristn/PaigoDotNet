namespace PaigoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    /// <summary>
    /// Offering.
    /// </summary>
    public class Offering
    {
        #region Public-Members

        /// <summary>
        /// Offering visibility.
        /// </summary>
        [JsonPropertyName("offeringVisibility")]
        public string OfferingVisibility { get; set; } = null;

        /// <summary>
        /// Offering type.
        /// </summary>
        [JsonPropertyName("offeringType")]
        public string OfferingType { get; set; } = null;

        /// <summary>
        /// Billing cycle.
        /// </summary>
        [JsonPropertyName("billingCycle")]
        public string BillingCycle { get; set; } = null;

        /// <summary>
        /// Currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = null;

        /// <summary>
        /// Dimension overrides.
        /// </summary>
        [JsonPropertyName("dimensionOverrides")]
        public object DimensionOverrides { get; set; } = null;

        /// <summary>
        /// ID.
        /// </summary>
        [JsonPropertyName("offeringId")]
        public string Id { get; set; } = null;

        /// <summary>
        /// Dimensions.
        /// </summary>
        [JsonPropertyName("dimensions")]
        public List<Dimension> Dimensions { get; set; } = null;

        /// <summary>
        /// Prepaid credit.
        /// </summary>
        [JsonPropertyName("prepaidCredit")]
        public string PrepaidCredit { get; set; } = null;

        /// <summary>
        /// Minimum charge.
        /// </summary>
        [JsonPropertyName("minimumCharge")]
        public string MinimumCharge { get; set; } = null;

        /// <summary>
        /// Top up amount.
        /// </summary>
        [JsonPropertyName("topUpAmount")]
        public string TopUpAmount { get; set; } = null;

        /// <summary>
        /// Top up threshold.
        /// </summary>
        [JsonPropertyName("topUpThreshold")]
        public string TopUpThreshold { get; set; } = null;

        /// <summary>
        /// Subscription price.
        /// </summary>
        [JsonPropertyName("subscriptionPrice")]
        public string SubscriptionPrice { get; set; } = null;

        /// <summary>
        /// Free trial length.
        /// </summary>
        [JsonPropertyName("freeTrialLength")]
        public string FreeTrialLength { get; set; } = null;

        /// <summary>
        /// Name.
        /// </summary>
        [JsonPropertyName("offeringName")]
        public string Name { get; set; } = null;

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
        public Offering()
        {

        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion 
    }
}
