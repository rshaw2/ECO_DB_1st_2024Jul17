using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drugtopregnancyinteraction entity with essential details
    /// </summary>
    public class DrugToPregnancyInteraction
    {
        /// <summary>
        /// Primary key for the DrugToPregnancyInteraction 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugToPregnancyInteraction belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field FromDrug of the DrugToPregnancyInteraction 
        /// </summary>
        [Required]
        public Guid FromDrug { get; set; }

        /// <summary>
        /// Required field ToPregnancy of the DrugToPregnancyInteraction 
        /// </summary>
        [Required]
        public bool ToPregnancy { get; set; }

        /// <summary>
        /// Required field Severity of the DrugToPregnancyInteraction 
        /// </summary>
        [Required]
        public short Severity { get; set; }

        /// <summary>
        /// Required field Reason of the DrugToPregnancyInteraction 
        /// </summary>
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DrugToPregnancyInteraction belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DrugToPregnancyInteraction 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DrugToPregnancyInteraction belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DrugToPregnancyInteraction 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}