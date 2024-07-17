using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a currencyconversion entity with essential details
    /// </summary>
    public class CurrencyConversion
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the CurrencyConversion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the CurrencyConversion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the CurrencyConversion 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the CurrencyConversion 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the CurrencyConversion 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the Currency to which the CurrencyConversion belongs 
        /// </summary>
        [Required]
        public Guid FromCurrencyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Currency
        /// </summary>
        [ForeignKey("FromCurrencyId")]
        public Currency? FromCurrencyId_Currency { get; set; }

        /// <summary>
        /// Foreign key referencing the Currency to which the CurrencyConversion belongs 
        /// </summary>
        [Required]
        public Guid ToCurrencyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Currency
        /// </summary>
        [ForeignKey("ToCurrencyId")]
        public Currency? ToCurrencyId_Currency { get; set; }

        /// <summary>
        /// Required field ConversionStartDate of the CurrencyConversion 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ConversionStartDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CurrencyConversion belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CurrencyConversion 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the CurrencyConversion 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Foreign key referencing the CurrencyConversionType to which the CurrencyConversion belongs 
        /// </summary>
        public Guid? ConversionTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CurrencyConversionType
        /// </summary>
        [ForeignKey("ConversionTypeId")]
        public CurrencyConversionType? ConversionTypeId_CurrencyConversionType { get; set; }
        /// <summary>
        /// BuyingRate of the CurrencyConversion 
        /// </summary>
        public decimal? BuyingRate { get; set; }
        /// <summary>
        /// SellingRate of the CurrencyConversion 
        /// </summary>
        public decimal? SellingRate { get; set; }

        /// <summary>
        /// ConversionEndDate of the CurrencyConversion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ConversionEndDate { get; set; }
        /// <summary>
        /// Active of the CurrencyConversion 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CurrencyConversion belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CurrencyConversion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FromCurrencyValue of the CurrencyConversion 
        /// </summary>
        public decimal? FromCurrencyValue { get; set; }
        /// <summary>
        /// ToCurrencyValue of the CurrencyConversion 
        /// </summary>
        public decimal? ToCurrencyValue { get; set; }
        /// <summary>
        /// Code of the CurrencyConversion 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the CurrencyConversion 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// IsDefault of the CurrencyConversion 
        /// </summary>
        public bool? IsDefault { get; set; }
    }
}