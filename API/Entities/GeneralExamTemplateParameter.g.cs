using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a generalexamtemplateparameter entity with essential details
    /// </summary>
    public class GeneralExamTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the GeneralExamTemplateParameter class.
        /// </summary>
        public GeneralExamTemplateParameter()
        {
            Flagged = false;
            IsStandard = false;
            ShowClinicalParameterName = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GeneralExamTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GeneralExamTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the GeneralExamTemplate to which the GeneralExamTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid GeneralExamTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated GeneralExamTemplate
        /// </summary>
        [ForeignKey("GeneralExamTemplate")]
        public GeneralExamTemplate? GeneralExamTemplate_GeneralExamTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the GeneralExamTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field Sequence of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GeneralExamTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the GeneralExamTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the GeneralExamTemplateParameter 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GeneralExamTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GeneralExamTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the GeneralExamTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the GeneralExamTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the GeneralExamTemplateParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// ShowClinicalParameterName of the GeneralExamTemplateParameter 
        /// </summary>
        public bool? ShowClinicalParameterName { get; set; }
    }
}