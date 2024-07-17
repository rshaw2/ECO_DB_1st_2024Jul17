using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a clinicalparameter entity with essential details
    /// </summary>
    public class ClinicalParameter
    {
        /// <summary>
        /// Initializes a new instance of the ClinicalParameter class.
        /// </summary>
        public ClinicalParameter()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ClinicalParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ClinicalParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the ClinicalParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ClinicalParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ClinicalParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ClinicalParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the ClinicalParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// Notes of the ClinicalParameter 
        /// </summary>
        public bool? Notes { get; set; }
        /// <summary>
        /// Suggestion of the ClinicalParameter 
        /// </summary>
        public bool? Suggestion { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ClinicalParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ClinicalParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// FeatureParameter of the ClinicalParameter 
        /// </summary>
        public bool? FeatureParameter { get; set; }
        /// <summary>
        /// Code of the ClinicalParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ClinicalParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// DataType of the ClinicalParameter 
        /// </summary>
        public Guid? DataType { get; set; }
        /// <summary>
        /// InputType of the ClinicalParameter 
        /// </summary>
        public Guid? InputType { get; set; }
        /// <summary>
        /// UnitOfMeasure of the ClinicalParameter 
        /// </summary>
        public Guid? UnitOfMeasure { get; set; }
        /// <summary>
        /// UnitType of the ClinicalParameter 
        /// </summary>
        public Guid? UnitType { get; set; }
    }
}