using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a diagnosisdeviation entity with essential details
    /// </summary>
    public class DiagnosisDeviation
    {
        /// <summary>
        /// Primary key for the DiagnosisDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DiagnosisDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Diagnosis to which the DiagnosisDeviation belongs 
        /// </summary>
        [Required]
        public Guid Diagnosis { get; set; }

        /// <summary>
        /// Navigation property representing the associated Diagnosis
        /// </summary>
        [ForeignKey("Diagnosis")]
        public Diagnosis? Diagnosis_Diagnosis { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DiagnosisDeviation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DiagnosisDeviation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field DevationType of the DiagnosisDeviation 
        /// </summary>
        [Required]
        public byte DevationType { get; set; }
        /// <summary>
        /// ReplacedDiagnosis of the DiagnosisDeviation 
        /// </summary>
        public Guid? ReplacedDiagnosis { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DiagnosisDeviation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DiagnosisDeviation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DiagnosisDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}