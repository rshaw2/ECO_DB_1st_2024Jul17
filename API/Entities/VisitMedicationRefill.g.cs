using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitmedicationrefill entity with essential details
    /// </summary>
    public class VisitMedicationRefill
    {
        /// <summary>
        /// Initializes a new instance of the VisitMedicationRefill class.
        /// </summary>
        public VisitMedicationRefill()
        {
            Dispensed = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitMedicationRefill belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitMedicationRefill 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitMedication to which the VisitMedicationRefill belongs 
        /// </summary>
        [Required]
        public Guid VisitMedicationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedication
        /// </summary>
        [ForeignKey("VisitMedicationId")]
        public VisitMedication? VisitMedicationId_VisitMedication { get; set; }

        /// <summary>
        /// Required field RefillCount of the VisitMedicationRefill 
        /// </summary>
        [Required]
        public short RefillCount { get; set; }

        /// <summary>
        /// Required field TotalRefill of the VisitMedicationRefill 
        /// </summary>
        [Required]
        public short TotalRefill { get; set; }

        /// <summary>
        /// Required field RefillDueDate of the VisitMedicationRefill 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime RefillDueDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicationRefill belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitMedicationRefill 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Dispensed of the VisitMedicationRefill 
        /// </summary>
        [Required]
        public bool Dispensed { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicationRefill belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitMedicationRefill 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}