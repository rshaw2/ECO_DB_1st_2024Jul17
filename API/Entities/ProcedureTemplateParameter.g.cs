using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a proceduretemplateparameter entity with essential details
    /// </summary>
    public class ProcedureTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the ProcedureTemplateParameter class.
        /// </summary>
        public ProcedureTemplateParameter()
        {
            Flagged = false;
            ShowClinicalParameterName = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ProcedureTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field ShowClinicalParameterName of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public bool ShowClinicalParameterName { get; set; }

        /// <summary>
        /// Required field Sequence of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field IsStandard of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProcedureTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProcedureTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ProcedureTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the ProcedureTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ProcedureTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the ProcedureTemplate to which the ProcedureTemplateParameter belongs 
        /// </summary>
        public Guid? ProcedureTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProcedureTemplate
        /// </summary>
        [ForeignKey("ProcedureTemplate")]
        public ProcedureTemplate? ProcedureTemplate_ProcedureTemplate { get; set; }
        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the ProcedureTemplateParameter belongs 
        /// </summary>
        public Guid? ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }
    }
}