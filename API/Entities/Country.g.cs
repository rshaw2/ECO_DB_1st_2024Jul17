using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a country entity with essential details
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Initializes a new instance of the Country class.
        /// </summary>
        public Country()
        {
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Country belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Country 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Country 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Country 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the Country 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Country belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Country 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Country 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Country 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Country belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Country 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// IsDefault of the Country 
        /// </summary>
        public bool? IsDefault { get; set; }
        /// <summary>
        /// DecimalPrecision of the Country 
        /// </summary>
        public short? DecimalPrecision { get; set; }
        /// <summary>
        /// LongDateFormat of the Country 
        /// </summary>
        public Guid? LongDateFormat { get; set; }
        /// <summary>
        /// ShortDateFormat of the Country 
        /// </summary>
        public Guid? ShortDateFormat { get; set; }
        /// <summary>
        /// Status of the Country 
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// CalculationPrecision of the Country 
        /// </summary>
        public short? CalculationPrecision { get; set; }
        /// <summary>
        /// DisplayPrecision of the Country 
        /// </summary>
        public short? DisplayPrecision { get; set; }
        /// <summary>
        /// ThousandSeparator of the Country 
        /// </summary>
        public bool? ThousandSeparator { get; set; }
        /// <summary>
        /// Code of the Country 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Country 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Currency of the Country 
        /// </summary>
        public Guid? Currency { get; set; }
        /// <summary>
        /// Language of the Country 
        /// </summary>
        public Guid? Language { get; set; }
        /// <summary>
        /// Timezone of the Country 
        /// </summary>
        public Guid? Timezone { get; set; }
        /// <summary>
        /// IsoCode of the Country 
        /// </summary>
        public string? IsoCode { get; set; }
        /// <summary>
        /// Nationality of the Country 
        /// </summary>
        public string? Nationality { get; set; }
        /// <summary>
        /// CountryImage of the Country 
        /// </summary>
        public string? CountryImage { get; set; }
        /// <summary>
        /// Active of the Country 
        /// </summary>
        public Guid? Active { get; set; }
    }
}