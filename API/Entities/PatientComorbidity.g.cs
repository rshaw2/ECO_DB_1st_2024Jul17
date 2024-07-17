using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientcomorbidity entity with essential details
    /// </summary>
    public class PatientComorbidity
    {
        /// <summary>
        /// Initializes a new instance of the PatientComorbidity class.
        /// </summary>
        public PatientComorbidity()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientComorbidity belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientComorbidity 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Comorbidity of the PatientComorbidity 
        /// </summary>
        [Required]
        public Guid Comorbidity { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the PatientComorbidity belongs 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }

        /// <summary>
        /// Required field Sequence of the PatientComorbidity 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the PatientComorbidity 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientComorbidity 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientComorbidity belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientComorbidity 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientComorbidity belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientComorbidity 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the PatientComorbidity 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientComorbidity 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the PatientComorbidity 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// IsStandard of the PatientComorbidity 
        /// </summary>
        public bool? IsStandard { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the PatientComorbidity belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// Summary of the PatientComorbidity 
        /// </summary>
        public string? Summary { get; set; }
    }
}