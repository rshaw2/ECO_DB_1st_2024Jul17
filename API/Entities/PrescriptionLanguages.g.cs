using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a prescriptionlanguages entity with essential details
    /// </summary>
    public class PrescriptionLanguages
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the PrescriptionLanguages belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the PrescriptionLanguages 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Language to which the PrescriptionLanguages belongs 
        /// </summary>
        [Required]
        public Guid LanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("LanguageId")]
        public Language? LanguageId_Language { get; set; }

        /// <summary>
        /// Required field Language of the PrescriptionLanguages 
        /// </summary>
        [Required]
        public string Language { get; set; }

        /// <summary>
        /// Required field Code of the PrescriptionLanguages 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Default of the PrescriptionLanguages 
        /// </summary>
        [Required]
        public bool Default { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PrescriptionLanguages belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PrescriptionLanguages 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the PrescriptionLanguages belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the PrescriptionLanguages 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}