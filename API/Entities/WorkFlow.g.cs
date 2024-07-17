using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflow entity with essential details
    /// </summary>
    public class WorkFlow
    {
        /// <summary>
        /// Initializes a new instance of the WorkFlow class.
        /// </summary>
        public WorkFlow()
        {
            Enabled = false;
        }

        /// <summary>
        /// Primary key for the WorkFlow 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlow belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the WorkFlow 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field EntityName of the WorkFlow 
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Required field Enabled of the WorkFlow 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the WorkFlow belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the WorkFlow 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the WorkFlow belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the WorkFlow 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitType to which the WorkFlow belongs 
        /// </summary>
        public Guid? VisitTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitType
        /// </summary>
        [ForeignKey("VisitTypeId")]
        public VisitType? VisitTypeId_VisitType { get; set; }
    }
}