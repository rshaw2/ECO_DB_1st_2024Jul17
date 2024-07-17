using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationtemplateparameter entity with essential details
    /// </summary>
    public class InvestigationTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the InvestigationTemplateParameter class.
        /// </summary>
        public InvestigationTemplateParameter()
        {
            IsStandard = false;
            Flagged = false;
            ShowClinicalParameterName = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the InvestigationTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the InvestigationTemplate to which the InvestigationTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid InvestigationTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationTemplate
        /// </summary>
        [ForeignKey("InvestigationTemplate")]
        public InvestigationTemplate? InvestigationTemplate_InvestigationTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the InvestigationTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Sequence of the InvestigationTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the InvestigationTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the InvestigationTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the InvestigationTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Flagged of the InvestigationTemplateParameter 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvestigationTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the InvestigationTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvestigationTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// ShowClinicalParameterName of the InvestigationTemplateParameter 
        /// </summary>
        public bool? ShowClinicalParameterName { get; set; }
    }
}