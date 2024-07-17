using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a vitaltemplateparameter entity with essential details
    /// </summary>
    public class VitalTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the VitalTemplateParameter class.
        /// </summary>
        public VitalTemplateParameter()
        {
            ShowClinicalParameterName = false;
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VitalTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VitalTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VitalTemplate to which the VitalTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid VitalTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated VitalTemplate
        /// </summary>
        [ForeignKey("VitalTemplate")]
        public VitalTemplate? VitalTemplate_VitalTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the VitalTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field ShowClinicalParameterName of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public bool ShowClinicalParameterName { get; set; }

        /// <summary>
        /// Required field Sequence of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VitalTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VitalTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the VitalTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the VitalTemplateParameter 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VitalTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VitalTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VitalTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VitalTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VitalTemplateParameter 
        /// </summary>
        public Guid? Active { get; set; }
    }
}