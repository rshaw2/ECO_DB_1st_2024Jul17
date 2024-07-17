using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a batchtypecontext entity with essential details
    /// </summary>
    public class BatchTypeContext
    {
        /// <summary>
        /// Initializes a new instance of the BatchTypeContext class.
        /// </summary>
        public BatchTypeContext()
        {
            IsStandard = false;
            Flagged = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the BatchTypeContext belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the BatchTypeContext 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the BatchTypeContext 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the BatchTypeContext 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the BatchTypeContext belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the BatchTypeContext 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the BatchTypeContext 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the BatchTypeContext 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Flagged of the BatchTypeContext 
        /// </summary>
        public bool? Flagged { get; set; }
        /// <summary>
        /// EntityObjectSubTypeId of the BatchTypeContext 
        /// </summary>
        public Guid? EntityObjectSubTypeId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the BatchTypeContext belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the BatchTypeContext 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Active of the BatchTypeContext 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Code of the BatchTypeContext 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the BatchTypeContext 
        /// </summary>
        public string? Name { get; set; }
    }
}