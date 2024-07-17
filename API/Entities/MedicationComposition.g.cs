using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationcomposition entity with essential details
    /// </summary>
    public class MedicationComposition
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationComposition belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the MedicationComposition 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field PrimaryComposition of the MedicationComposition 
        /// </summary>
        [Required]
        public bool PrimaryComposition { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicationComposition belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the MedicationComposition 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicationComposition belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicationComposition 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the MedicationComposition belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// MedicationId of the MedicationComposition 
        /// </summary>
        public Guid? MedicationId { get; set; }
        /// <summary>
        /// Foreign key referencing the Generic to which the MedicationComposition belongs 
        /// </summary>
        public Guid? GenericId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Generic
        /// </summary>
        [ForeignKey("GenericId")]
        public Generic? GenericId_Generic { get; set; }
        /// <summary>
        /// Strength of the MedicationComposition 
        /// </summary>
        public decimal? Strength { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the MedicationComposition belongs 
        /// </summary>
        public Guid? UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UomId")]
        public UOM? UomId_UOM { get; set; }
    }
}