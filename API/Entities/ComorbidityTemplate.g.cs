using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a comorbiditytemplate entity with essential details
    /// </summary>
    public class ComorbidityTemplate
    {
        /// <summary>
        /// Initializes a new instance of the ComorbidityTemplate class.
        /// </summary>
        public ComorbidityTemplate()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Required field EntityCode of the ComorbidityTemplate 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ComorbidityTemplate 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the ComorbidityTemplate 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ComorbidityTemplate belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ComorbidityTemplate 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ComorbidityTemplate belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ComorbidityTemplate 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// IsDefault of the ComorbidityTemplate 
        /// </summary>
        public bool? IsDefault { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ComorbidityTemplate belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ComorbidityTemplate 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// User of the ComorbidityTemplate 
        /// </summary>
        public Guid? User { get; set; }
        /// <summary>
        /// Code of the ComorbidityTemplate 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ComorbidityTemplate 
        /// </summary>
        public string? Name { get; set; }
    }
}