using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patientallergyparametervalue entity with essential details
    /// </summary>
    public class PatientAllergyParameterValue
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PatientAllergyParameterValue belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PatientAllergyParameterValue 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameterValue to which the PatientAllergyParameterValue belongs 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameterValue
        /// </summary>
        [ForeignKey("ClinicalParameterValue")]
        public ClinicalParameterValue? ClinicalParameterValue_ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the PatientAllergyParameterValue 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the PatientAllergyParameterValue 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the PatientAllergyParameterValue 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the PatientAllergyParameterValue 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the PatientAllergyParameterValue 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the PatientAllergyParameterValue 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the PatientAllergyParameterValue 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the PatientAllergyParameterValue 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the PatientAllergyParameterValue 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the PatientAllergyParameterValue 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the PatientAllergyParameterValue 
        /// </summary>
        public Guid? UOM { get; set; }
    }
}