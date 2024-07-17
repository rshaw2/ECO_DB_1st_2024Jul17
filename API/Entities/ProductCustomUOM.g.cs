using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productcustomuom entity with essential details
    /// </summary>
    public class ProductCustomUOM
    {
        /// <summary>
        /// Primary key for the ProductCustomUOM 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductCustomUOM belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field ProductUomType of the ProductCustomUOM 
        /// </summary>
        [Required]
        public byte ProductUomType { get; set; }

        /// <summary>
        /// Required field Name of the ProductCustomUOM 
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}