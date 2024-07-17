using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantculture entity with essential details
    /// </summary>
    public class TenantCulture
    {
        /// <summary>
        /// Initializes a new instance of the TenantCulture class.
        /// </summary>
        public TenantCulture()
        {
            ThousandSeperator = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the TenantCulture 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }

        /// <summary>
        /// Foreign key referencing the Currency to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid DefaultCurrencyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Currency
        /// </summary>
        [ForeignKey("DefaultCurrencyId")]
        public Currency? DefaultCurrencyId_Currency { get; set; }

        /// <summary>
        /// Foreign key referencing the Language to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid DefaultLanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("DefaultLanguageId")]
        public Language? DefaultLanguageId_Language { get; set; }

        /// <summary>
        /// Foreign key referencing the DefaultFormatForLongDate to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid LongDateFormatId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DefaultFormatForLongDate
        /// </summary>
        [ForeignKey("LongDateFormatId")]
        public DefaultFormatForLongDate? LongDateFormatId_DefaultFormatForLongDate { get; set; }

        /// <summary>
        /// Foreign key referencing the DefaultFormatForShortDate to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid ShortDateFormatId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DefaultFormatForShortDate
        /// </summary>
        [ForeignKey("ShortDateFormatId")]
        public DefaultFormatForShortDate? ShortDateFormatId_DefaultFormatForShortDate { get; set; }

        /// <summary>
        /// Foreign key referencing the Timezone to which the TenantCulture belongs 
        /// </summary>
        [Required]
        public Guid Timezone { get; set; }

        /// <summary>
        /// Navigation property representing the associated Timezone
        /// </summary>
        [ForeignKey("Timezone")]
        public Timezone? Timezone_Timezone { get; set; }

        /// <summary>
        /// Required field DecimalPrecision of the TenantCulture 
        /// </summary>
        [Required]
        public short DecimalPrecision { get; set; }

        /// <summary>
        /// Required field DisplayDecimalPrecision of the TenantCulture 
        /// </summary>
        [Required]
        public short DisplayDecimalPrecision { get; set; }

        /// <summary>
        /// Required field CalculationDecimalPrecision of the TenantCulture 
        /// </summary>
        [Required]
        public short CalculationDecimalPrecision { get; set; }
        /// <summary>
        /// ThousandSeperator of the TenantCulture 
        /// </summary>
        public bool? ThousandSeperator { get; set; }
    }
}