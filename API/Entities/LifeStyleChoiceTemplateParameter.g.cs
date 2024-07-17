using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a lifestylechoicetemplateparameter entity with essential details
    /// </summary>
    public class LifeStyleChoiceTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the LifeStyleChoiceTemplateParameter class.
        /// </summary>
        public LifeStyleChoiceTemplateParameter()
        {
            ShowClinicalParameterName = false;
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the LifeStyleChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the LifeStyleChoiceTemplate to which the LifeStyleChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid LifeStyleChoiceTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated LifeStyleChoiceTemplate
        /// </summary>
        [ForeignKey("LifeStyleChoiceTemplate")]
        public LifeStyleChoiceTemplate? LifeStyleChoiceTemplate_LifeStyleChoiceTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the LifeStyleChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field ShowClinicalParameterName of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool ShowClinicalParameterName { get; set; }

        /// <summary>
        /// Required field Sequence of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Flagged of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the LifeStyleChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the LifeStyleChoiceTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the LifeStyleChoiceTemplateParameter 
        /// </summary>
        public Guid? Active { get; set; }
    }
}