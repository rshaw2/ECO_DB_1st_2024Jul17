using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a diagnosistemplate entity with essential details
    /// </summary>
    public class DiagnosisTemplate
    {
        /// <summary>
        /// Initializes a new instance of the DiagnosisTemplate class.
        /// </summary>
        public DiagnosisTemplate()
        {
            IsStandard = false;
            Followup = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DiagnosisTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DiagnosisTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the DiagnosisTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DiagnosisTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the DiagnosisTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DiagnosisTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DiagnosisTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DiagnosisTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DiagnosisTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// User of the DiagnosisTemplate 
        /// </summary>
        public Guid? User { get; set; }
        /// <summary>
        /// Code of the DiagnosisTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DiagnosisTemplate 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// IsDefaultTemplate of the DiagnosisTemplate 
        /// </summary>
        public bool? IsDefaultTemplate { get; set; }
        /// <summary>
        /// Followup of the DiagnosisTemplate 
        /// </summary>
        public bool? Followup { get; set; }
    }
}