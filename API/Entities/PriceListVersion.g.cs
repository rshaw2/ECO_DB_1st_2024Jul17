using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a pricelistversion entity with essential details
    /// </summary>
    public class PriceListVersion
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PriceListVersion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PriceListVersion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field PriceListBaseType of the PriceListVersion 
        /// </summary>
        [Required]
        public byte PriceListBaseType { get; set; }

        /// <summary>
        /// Required field Name of the PriceListVersion 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Foreign key referencing the PriceList to which the PriceListVersion belongs 
        /// </summary>
        [Required]
        public Guid PriceListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PriceList
        /// </summary>
        [ForeignKey("PriceListId")]
        public PriceList? PriceListId_PriceList { get; set; }

        /// <summary>
        /// Required field Version of the PriceListVersion 
        /// </summary>
        [Required]
        public short Version { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PriceListVersion belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PriceListVersion 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// PreviousVersionId of the PriceListVersion 
        /// </summary>
        public Guid? PreviousVersionId { get; set; }
        /// <summary>
        /// Notes of the PriceListVersion 
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// StartDate of the PriceListVersion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the PriceListVersion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// PricelistType of the PriceListVersion 
        /// </summary>
        public byte? PricelistType { get; set; }
    }
}