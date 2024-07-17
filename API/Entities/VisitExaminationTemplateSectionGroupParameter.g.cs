using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitexaminationtemplatesectiongroupparameter entity with essential details
    /// </summary>
    public class VisitExaminationTemplateSectionGroupParameter
    {
        /// <summary>
        /// Required field Sequence of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitExaminationTemplateSectionGroupParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplateSectionGroup to which the VisitExaminationTemplateSectionGroupParameter belongs 
        /// </summary>
        [Required]
        public Guid VisitExaminationTemplateSectionGroupId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplateSectionGroup
        /// </summary>
        [ForeignKey("VisitExaminationTemplateSectionGroupId")]
        public VisitExaminationTemplateSectionGroup? VisitExaminationTemplateSectionGroupId_VisitExaminationTemplateSectionGroup { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplateSectionColumn to which the VisitExaminationTemplateSectionGroupParameter belongs 
        /// </summary>
        public Guid? VisitExaminationTemplateSectionColumnId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplateSectionColumn
        /// </summary>
        [ForeignKey("VisitExaminationTemplateSectionColumnId")]
        public VisitExaminationTemplateSectionColumn? VisitExaminationTemplateSectionColumnId_VisitExaminationTemplateSectionColumn { get; set; }
        /// <summary>
        /// Name of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// TextValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the VisitExaminationTemplateSectionGroupParameter belongs 
        /// </summary>
        public Guid? UOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UOM")]
        public UOM? UOM_UOM { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// InputType of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public Guid? InputType { get; set; }
        /// <summary>
        /// DataType of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public Guid? DataType { get; set; }
        /// <summary>
        /// UnitType of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public Guid? UnitType { get; set; }
        /// <summary>
        /// Suggestion of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public bool? Suggestion { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// ClinicalParameterName of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? ClinicalParameterName { get; set; }
        /// <summary>
        /// ClinicalParameterId of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public Guid? ClinicalParameterId { get; set; }
        /// <summary>
        /// MultiChoiceValue of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// Summary of the VisitExaminationTemplateSectionGroupParameter 
        /// </summary>
        public string? Summary { get; set; }
    }
}