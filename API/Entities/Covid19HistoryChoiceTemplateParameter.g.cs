using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a covid19historychoicetemplateparameter entity with essential details
    /// </summary>
    public class Covid19HistoryChoiceTemplateParameter
    {
        /// <summary>
        /// Initializes a new instance of the Covid19HistoryChoiceTemplateParameter class.
        /// </summary>
        public Covid19HistoryChoiceTemplateParameter()
        {
            ShowClinicalParameterName = false;
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Covid19HistoryChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Covid19HistoryChoiceTemplate to which the Covid19HistoryChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid Covid19HistoryChoiceTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated Covid19HistoryChoiceTemplate
        /// </summary>
        [ForeignKey("Covid19HistoryChoiceTemplate")]
        public Covid19HistoryChoiceTemplate? Covid19HistoryChoiceTemplate_Covid19HistoryChoiceTemplate { get; set; }

        /// <summary>
        /// Foreign key referencing the ClinicalParameter to which the Covid19HistoryChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Navigation property representing the associated ClinicalParameter
        /// </summary>
        [ForeignKey("ClinicalParameter")]
        public ClinicalParameter? ClinicalParameter_ClinicalParameter { get; set; }

        /// <summary>
        /// Required field ShowClinicalParameterName of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool ShowClinicalParameterName { get; set; }

        /// <summary>
        /// Required field Sequence of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Flagged of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Covid19HistoryChoiceTemplateParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Covid19HistoryChoiceTemplateParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Covid19HistoryChoiceTemplateParameter 
        /// </summary>
        public Guid? Active { get; set; }
    }
}