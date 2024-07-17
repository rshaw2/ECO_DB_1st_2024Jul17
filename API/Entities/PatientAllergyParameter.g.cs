using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientallergyparameter entity with essential details
    /// </summary>
    public class PatientAllergyParameter
    {
        /// <summary>
        /// Initializes a new instance of the PatientAllergyParameter class.
        /// </summary>
        public PatientAllergyParameter()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientAllergyParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientAllergyParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientAllergy to which the PatientAllergyParameter belongs 
        /// </summary>
        [Required]
        public Guid PatientAllergy { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientAllergy
        /// </summary>
        [ForeignKey("PatientAllergy")]
        public PatientAllergy? PatientAllergy_PatientAllergy { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the PatientAllergyParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsStandard of the PatientAllergyParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientAllergyParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientAllergyParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the PatientAllergyParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientAllergyParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the PatientAllergyParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientAllergyParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the PatientAllergyParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientAllergyParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientAllergyParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the PatientAllergyParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// IsSpecificValue of the PatientAllergyParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// MultiChoiceValue of the PatientAllergyParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the PatientAllergyParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the PatientAllergyParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PatientAllergyParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PatientAllergyParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PatientAllergyParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PatientAllergyParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PatientAllergyParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PatientAllergyParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PatientAllergyParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PatientAllergyParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PatientAllergyParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the PatientAllergyParameter 
        /// </summary>
        public Guid? UOM { get; set; }
        /// <summary>
        /// AssociatedNotes of the PatientAllergyParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
    }
}