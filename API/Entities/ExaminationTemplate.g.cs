using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a examinationtemplate entity with essential details
    /// </summary>
    public class ExaminationTemplate
    {
        /// <summary>
        /// Primary key for the ExaminationTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ExaminationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field IsStandard of the ExaminationTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the ExaminationTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ExaminationTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ExaminationTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ExaminationTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field TemplateView of the ExaminationTemplate 
        /// </summary>
        [Required]
        public byte TemplateView { get; set; }

        /// <summary>
        /// Required field Name of the ExaminationTemplate 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Favourite of the ExaminationTemplate 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ExaminationTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ExaminationTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// GlassPrescription of the ExaminationTemplate 
        /// </summary>
        public bool? GlassPrescription { get; set; }
        /// <summary>
        /// UserId of the ExaminationTemplate 
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Default of the ExaminationTemplate 
        /// </summary>
        public bool? Default { get; set; }
        /// <summary>
        /// ParentId of the ExaminationTemplate 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the ExaminationTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Speciality to which the ExaminationTemplate belongs 
        /// </summary>
        public Guid? SpecialityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Speciality
        /// </summary>
        [ForeignKey("SpecialityId")]
        public Speciality? SpecialityId_Speciality { get; set; }
        /// <summary>
        /// Description of the ExaminationTemplate 
        /// </summary>
        public string? Description { get; set; }
    }
}