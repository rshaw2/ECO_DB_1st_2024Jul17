using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a vitaltemplate entity with essential details
    /// </summary>
    public class VitalTemplate
    {
        /// <summary>
        /// Initializes a new instance of the VitalTemplate class.
        /// </summary>
        public VitalTemplate()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Required field EntityCode of the VitalTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VitalTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VitalTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VitalTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field IsStandard of the VitalTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Flagged of the VitalTemplate 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VitalTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VitalTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VitalTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VitalTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ParentId of the VitalTemplate 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// IsDefaultTemplate of the VitalTemplate 
        /// </summary>
        public bool? IsDefaultTemplate { get; set; }
        /// <summary>
        /// Code of the VitalTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VitalTemplate 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VitalTemplate 
        /// </summary>
        public Guid? Active { get; set; }
    }
}