using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientpregnancy entity with essential details
    /// </summary>
    public class PatientPregnancy
    {
        /// <summary>
        /// Initializes a new instance of the PatientPregnancy class.
        /// </summary>
        public PatientPregnancy()
        {
            IsPregnant = false;
        }

        /// <summary>
        /// Required field EntityCode of the PatientPregnancy 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientPregnancy 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientPregnancy belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientPregnancy 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PatientPregnancy belongs 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }

        /// <summary>
        /// Required field IsPregnant of the PatientPregnancy 
        /// </summary>
        [Required]
        public bool IsPregnant { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientPregnancy belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientPregnancy 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the PatientPregnancy belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// DurationValue of the PatientPregnancy 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the PatientPregnancy belongs 
        /// </summary>
        public Guid? Uom { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("Uom")]
        public UOM? Uom_UOM { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientPregnancy belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientPregnancy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Gravidity of the PatientPregnancy 
        /// </summary>
        public byte? Gravidity { get; set; }
        /// <summary>
        /// Parity of the PatientPregnancy 
        /// </summary>
        public byte? Parity { get; set; }
        /// <summary>
        /// Miscarriage of the PatientPregnancy 
        /// </summary>
        public byte? Miscarriage { get; set; }
        /// <summary>
        /// Termination of the PatientPregnancy 
        /// </summary>
        public byte? Termination { get; set; }

        /// <summary>
        /// EddDate of the PatientPregnancy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EddDate { get; set; }

        /// <summary>
        /// LmpDate of the PatientPregnancy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LmpDate { get; set; }
        /// <summary>
        /// Notes of the PatientPregnancy 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// PreferenceType of the PatientPregnancy 
        /// </summary>
        public byte? PreferenceType { get; set; }
    }
}