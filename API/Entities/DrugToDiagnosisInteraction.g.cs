using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drugtodiagnosisinteraction entity with essential details
    /// </summary>
    public class DrugToDiagnosisInteraction
    {
        /// <summary>
        /// Primary key for the DrugToDiagnosisInteraction 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugToDiagnosisInteraction belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field FromDrug of the DrugToDiagnosisInteraction 
        /// </summary>
        [Required]
        public Guid FromDrug { get; set; }

        /// <summary>
        /// Foreign key referencing the Diagnosis to which the DrugToDiagnosisInteraction belongs 
        /// </summary>
        [Required]
        public Guid ToDiagnosis { get; set; }

        /// <summary>
        /// Navigation property representing the associated Diagnosis
        /// </summary>
        [ForeignKey("ToDiagnosis")]
        public Diagnosis? ToDiagnosis_Diagnosis { get; set; }

        /// <summary>
        /// Required field Severity of the DrugToDiagnosisInteraction 
        /// </summary>
        [Required]
        public short Severity { get; set; }

        /// <summary>
        /// Required field Reason of the DrugToDiagnosisInteraction 
        /// </summary>
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DrugToDiagnosisInteraction belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DrugToDiagnosisInteraction 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DrugToDiagnosisInteraction belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DrugToDiagnosisInteraction 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}