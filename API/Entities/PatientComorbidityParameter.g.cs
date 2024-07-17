using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientcomorbidityparameter entity with essential details
    /// </summary>
    public class PatientComorbidityParameter
    {
        /// <summary>
        /// Initializes a new instance of the PatientComorbidityParameter class.
        /// </summary>
        public PatientComorbidityParameter()
        {
            IsSpecificValue = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientComorbidityParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientComorbidityParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientComorbidity to which the PatientComorbidityParameter belongs 
        /// </summary>
        [Required]
        public Guid PatientComorbidity { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientComorbidity
        /// </summary>
        [ForeignKey("PatientComorbidity")]
        public PatientComorbidity? PatientComorbidity_PatientComorbidity { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsSpecificValue of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        public bool IsSpecificValue { get; set; }

        /// <summary>
        /// Required field IsStandard of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientComorbidityParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientComorbidityParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the PatientComorbidityParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientComorbidityParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the PatientComorbidityParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientComorbidityParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientComorbidityParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DrugSystemOrganTypeName of the PatientComorbidityParameter 
        /// </summary>
        public string? DrugSystemOrganTypeName { get; set; }
        /// <summary>
        /// DrugSystemTherapeuticClassName of the PatientComorbidityParameter 
        /// </summary>
        public string? DrugSystemTherapeuticClassName { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the PatientComorbidityParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// AssociatedNotes of the PatientComorbidityParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// MultiChoiceValue of the PatientComorbidityParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the PatientComorbidityParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the PatientComorbidityParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PatientComorbidityParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PatientComorbidityParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PatientComorbidityParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PatientComorbidityParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PatientComorbidityParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PatientComorbidityParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PatientComorbidityParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PatientComorbidityParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PatientComorbidityParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the PatientComorbidityParameter 
        /// </summary>
        public Guid? UOM { get; set; }
        /// <summary>
        /// DrugSystemOrganType of the PatientComorbidityParameter 
        /// </summary>
        public Guid? DrugSystemOrganType { get; set; }
        /// <summary>
        /// DrugSystemTherapeuticClass of the PatientComorbidityParameter 
        /// </summary>
        public Guid? DrugSystemTherapeuticClass { get; set; }
    }
}