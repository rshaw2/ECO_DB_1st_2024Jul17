using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitdiagnosisparameter entity with essential details
    /// </summary>
    public class VisitDiagnosisParameter
    {
        /// <summary>
        /// Initializes a new instance of the VisitDiagnosisParameter class.
        /// </summary>
        public VisitDiagnosisParameter()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitDiagnosisParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitDiagnosisParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitDiagnosis to which the VisitDiagnosisParameter belongs 
        /// </summary>
        [Required]
        public Guid VisitDiagnosis { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitDiagnosis
        /// </summary>
        [ForeignKey("VisitDiagnosis")]
        public VisitDiagnosis? VisitDiagnosis_VisitDiagnosis { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitDiagnosisParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitDiagnosisParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the VisitDiagnosisParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitDiagnosisParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitDiagnosisParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitDiagnosisParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitDiagnosisParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitDiagnosisParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitDiagnosisParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// MultiChoiceValue of the VisitDiagnosisParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitDiagnosisParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the VisitDiagnosisParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitDiagnosisParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitDiagnosisParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitDiagnosisParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitDiagnosisParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitDiagnosisParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the VisitDiagnosisParameter 
        /// </summary>
        public Guid? UOM { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitDiagnosisParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
    }
}