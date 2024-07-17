using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drugtoallergyinteraction entity with essential details
    /// </summary>
    public class DrugToAllergyInteraction
    {
        /// <summary>
        /// Primary key for the DrugToAllergyInteraction 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugToAllergyInteraction belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field FromDrug of the DrugToAllergyInteraction 
        /// </summary>
        [Required]
        public Guid FromDrug { get; set; }

        /// <summary>
        /// Foreign key referencing the Allergy to which the DrugToAllergyInteraction belongs 
        /// </summary>
        [Required]
        public Guid ToAllergy { get; set; }

        /// <summary>
        /// Navigation property representing the associated Allergy
        /// </summary>
        [ForeignKey("ToAllergy")]
        public Allergy? ToAllergy_Allergy { get; set; }

        /// <summary>
        /// Required field Severity of the DrugToAllergyInteraction 
        /// </summary>
        [Required]
        public short Severity { get; set; }

        /// <summary>
        /// Required field Reason of the DrugToAllergyInteraction 
        /// </summary>
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DrugToAllergyInteraction belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DrugToAllergyInteraction 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DrugToAllergyInteraction belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DrugToAllergyInteraction 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}