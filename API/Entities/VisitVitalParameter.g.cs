using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitvitalparameter entity with essential details
    /// </summary>
    public class VisitVitalParameter
    {
        /// <summary>
        /// Initializes a new instance of the VisitVitalParameter class.
        /// </summary>
        public VisitVitalParameter()
        {
            IsStandard = false;
            Sequence = 0;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitVitalParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitVitalParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitVitalParameter belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the VisitVitalParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitVitalParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitVitalParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitVitalParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitVitalParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitVitalParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the VisitVitalParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitVitalParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitVitalParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitVitalParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitVitalParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Sequence of the VisitVitalParameter 
        /// </summary>
        public int? Sequence { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitVitalParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitVitalParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitVitalParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitVitalParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// TextValue of the VisitVitalParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitVitalParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitVitalParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitVitalParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitVitalParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitVitalParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitVitalParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitVitalParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitVitalParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitVitalParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the VisitVitalParameter 
        /// </summary>
        public Guid? UOM { get; set; }
    }
}