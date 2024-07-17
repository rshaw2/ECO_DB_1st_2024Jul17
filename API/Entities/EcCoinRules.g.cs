using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a eccoinrules entity with essential details
    /// </summary>
    public class EcCoinRules
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the EcCoinRules belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EcCoinRules 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EcCoins of the EcCoinRules 
        /// </summary>
        [Required]
        public decimal EcCoins { get; set; }

        /// <summary>
        /// Foreign key referencing the Currency to which the EcCoinRules belongs 
        /// </summary>
        [Required]
        public Guid CurrencyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Currency
        /// </summary>
        [ForeignKey("CurrencyId")]
        public Currency? CurrencyId_Currency { get; set; }

        /// <summary>
        /// Required field ConversionValue of the EcCoinRules 
        /// </summary>
        [Required]
        public decimal ConversionValue { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the EcCoinRules belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }
    }
}