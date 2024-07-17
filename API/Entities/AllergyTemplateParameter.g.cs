using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a allergytemplateparameter entity with essential details
    /// </summary>
    public class AllergyTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the AllergyTemplateParameter class.
        /// </summary>
        public AllergyTemplateParameter()
        {
            ShowClinicalParameterName = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AllergyTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the AllergyTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the AllergyTemplate to which the AllergyTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid AllergyTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated AllergyTemplate
        /// </summary>
        [ForeignKey("AllergyTemplate")]
        public AllergyTemplate? AllergyTemplate_AllergyTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the AllergyTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field ShowClinicalParameterName of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        public bool ShowClinicalParameterName { get; set; }

        /// <summary>
        /// Required field Sequence of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AllergyTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AllergyTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the AllergyTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the AllergyTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the AllergyTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the AllergyTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the AllergyTemplateParameter 
        /// </summary>
        public Guid? Active { get; set; }
    }
}