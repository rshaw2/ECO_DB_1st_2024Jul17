using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitexaminationtemplate entity with essential details
    /// </summary>
    public class VisitExaminationTemplate
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitExaminationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitExaminationTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitExaminationTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitExaminationTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitExaminationTemplate belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitExaminationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitExaminationTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field TemplateView of the VisitExaminationTemplate 
        /// </summary>
        [Required]
        public byte TemplateView { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitExaminationTemplate 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// Code of the VisitExaminationTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitExaminationTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitExaminationTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// GlassPrescription of the VisitExaminationTemplate 
        /// </summary>
        public bool? GlassPrescription { get; set; }
        /// <summary>
        /// ParameterSaved of the VisitExaminationTemplate 
        /// </summary>
        public bool? ParameterSaved { get; set; }
        /// <summary>
        /// Name of the VisitExaminationTemplate 
        /// </summary>
        public string? Name { get; set; }
    }
}