using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitexaminationtemplatesectiongroup entity with essential details
    /// </summary>
    public class VisitExaminationTemplateSectionGroup
    {
        /// <summary>
        /// Required field Sequence of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitExaminationTemplateSectionGroup belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field GroupType of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Required]
        public byte GroupType { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplateSection to which the VisitExaminationTemplateSectionGroup belongs 
        /// </summary>
        [Required]
        public Guid VisitExaminationTemplateSectionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplateSection
        /// </summary>
        [ForeignKey("VisitExaminationTemplateSectionId")]
        public VisitExaminationTemplateSection? VisitExaminationTemplateSectionId_VisitExaminationTemplateSection { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitExaminationTemplateSectionColumn to which the VisitExaminationTemplateSectionGroup belongs 
        /// </summary>
        public Guid? VisitExaminationTemplateSectionColumnId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitExaminationTemplateSectionColumn
        /// </summary>
        [ForeignKey("VisitExaminationTemplateSectionColumnId")]
        public VisitExaminationTemplateSectionColumn? VisitExaminationTemplateSectionColumnId_VisitExaminationTemplateSectionColumn { get; set; }
        /// <summary>
        /// Name of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// TextValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the VisitExaminationTemplateSectionGroup belongs 
        /// </summary>
        public Guid? UOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UOM")]
        public UOM? UOM_UOM { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// InputType of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public Guid? InputType { get; set; }
        /// <summary>
        /// DataType of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public Guid? DataType { get; set; }
        /// <summary>
        /// UnitType of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public Guid? UnitType { get; set; }
        /// <summary>
        /// Suggestion of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public bool? Suggestion { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// ClinicalParameterName of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? ClinicalParameterName { get; set; }
        /// <summary>
        /// ClinicalParameterId of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public Guid? ClinicalParameterId { get; set; }
        /// <summary>
        /// MultiChoiceValue of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? MultiChoiceValue { get; set; }
        /// <summary>
        /// Summary of the VisitExaminationTemplateSectionGroup 
        /// </summary>
        public string? Summary { get; set; }
    }
}