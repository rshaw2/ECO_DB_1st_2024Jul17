using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientlifestyleparameter entity with essential details
    /// </summary>
    public class PatientLifeStyleParameter
    {
        /// <summary>
        /// Initializes a new instance of the PatientLifeStyleParameter class.
        /// </summary>
        public PatientLifeStyleParameter()
        {
            IsStandard = false;
            IsSpecificValue = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientLifeStyleParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientLifeStyleParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the PatientLifeStyle to which the PatientLifeStyleParameter belongs 
        /// </summary>
        [Required]
        public Guid PatientLifeStyle { get; set; }

        /// <summary>
        /// Navigation property representing the associated PatientLifeStyle
        /// </summary>
        [ForeignKey("PatientLifeStyle")]
        public PatientLifeStyle? PatientLifeStyle_PatientLifeStyle { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the PatientLifeStyleParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsStandard of the PatientLifeStyleParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PatientLifeStyleParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PatientLifeStyleParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the PatientLifeStyleParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the PatientLifeStyleParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the PatientLifeStyleParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PatientLifeStyleParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the PatientLifeStyleParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PatientLifeStyleParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PatientLifeStyleParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the PatientLifeStyleParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// AssociatedNotes of the PatientLifeStyleParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// MultiChoiceValue of the PatientLifeStyleParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the PatientLifeStyleParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// IsSpecificValue of the PatientLifeStyleParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// TextValue of the PatientLifeStyleParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PatientLifeStyleParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PatientLifeStyleParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PatientLifeStyleParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PatientLifeStyleParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PatientLifeStyleParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PatientLifeStyleParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PatientLifeStyleParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PatientLifeStyleParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PatientLifeStyleParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the PatientLifeStyleParameter 
        /// </summary>
        public Guid? UOM { get; set; }
    }
}