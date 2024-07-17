using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientprocedureparameter entity with essential details
    /// </summary>
    public class PatientProcedureParameter
    {
        /// <summary>
        /// Initializes a new instance of the PatientProcedureParameter class.
        /// </summary>
        public PatientProcedureParameter()
        {
            IsSpecificValue = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientProcedureParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientProcedureParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientProcedure to which the PatientProcedureParameter belongs 
        /// </summary>
        [Required]
        public Guid PatientProcedure { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientProcedure
        /// </summary>
        [ForeignKey("PatientProcedure")]
        public PatientProcedure? PatientProcedure_PatientProcedure { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the PatientProcedureParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsSpecificValue of the PatientProcedureParameter 
        /// </summary>
        [Required]
        public bool IsSpecificValue { get; set; }

        /// <summary>
        /// Required field EntityCode of the PatientProcedureParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientProcedureParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the PatientProcedureParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientProcedureParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientProcedureParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientProcedureParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientProcedureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the PatientProcedureParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// MultiChoiceValue of the PatientProcedureParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// Code of the PatientProcedureParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientProcedureParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the PatientProcedureParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the PatientProcedureParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the PatientProcedureParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PatientProcedureParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PatientProcedureParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PatientProcedureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PatientProcedureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PatientProcedureParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PatientProcedureParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PatientProcedureParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PatientProcedureParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PatientProcedureParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the PatientProcedureParameter 
        /// </summary>
        public Guid? UOM { get; set; }
        /// <summary>
        /// AssociatedNotes of the PatientProcedureParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
    }
}