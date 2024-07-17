using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitinvestigationresultparameter entity with essential details
    /// </summary>
    public class VisitInvestigationResultParameter
    {
        /// <summary>
        /// Initializes a new instance of the VisitInvestigationResultParameter class.
        /// </summary>
        public VisitInvestigationResultParameter()
        {
            IsStandard = false;
            Sequence = 0;
            IsSpecificValue = false;
            HasSingleParameter = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitInvestigationResultParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigationResultParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitInvestigationResult to which the VisitInvestigationResultParameter belongs 
        /// </summary>
        [Required]
        public Guid VisitInvestigationResult { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitInvestigationResult
        /// </summary>
        [ForeignKey("VisitInvestigationResult")]
        public VisitInvestigationResult? VisitInvestigationResult_VisitInvestigationResult { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the VisitInvestigationResultParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitInvestigationResultParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationResultParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitInvestigationResultParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitInvestigationResultParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitInvestigationResultParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the VisitInvestigationResultParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitInvestigationResultParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitInvestigationResultParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationResultParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitInvestigationResultParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitInvestigationResultParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// Sequence of the VisitInvestigationResultParameter 
        /// </summary>
        public int? Sequence { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitInvestigationResultParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitInvestigationResultParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the VisitInvestigationResultParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitInvestigationResultParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitInvestigationResultParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitInvestigationResultParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitInvestigationResultParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitInvestigationResultParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitInvestigationResultParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitInvestigationResultParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitInvestigationResultParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitInvestigationResultParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the VisitInvestigationResultParameter 
        /// </summary>
        public Guid? UOM { get; set; }
        /// <summary>
        /// HasSingleParameter of the VisitInvestigationResultParameter 
        /// </summary>
        public bool? HasSingleParameter { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the VisitInvestigationResultParameter belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
    }
}