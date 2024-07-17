using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a pricelist entity with essential details
    /// </summary>
    public class PriceList
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PriceList belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PriceList 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field PriceListBaseType of the PriceList 
        /// </summary>
        [Required]
        public byte PriceListBaseType { get; set; }

        /// <summary>
        /// Required field Name of the PriceList 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field PricelistStatus of the PriceList 
        /// </summary>
        [Required]
        public byte PricelistStatus { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PriceList belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PriceList 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PriceList belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PriceList 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Enable of the PriceList 
        /// </summary>
        public bool? Enable { get; set; }
        /// <summary>
        /// Notes of the PriceList 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// StartDate of the PriceList 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the PriceList 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// PricelistType of the PriceList 
        /// </summary>
        public byte? PricelistType { get; set; }
    }
}