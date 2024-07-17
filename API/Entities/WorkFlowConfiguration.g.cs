using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflowconfiguration entity with essential details
    /// </summary>
    public class WorkFlowConfiguration
    {
        /// <summary>
        /// Primary key for the WorkFlowConfiguration 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlowConfiguration belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlow to which the WorkFlowConfiguration belongs 
        /// </summary>
        [Required]
        public Guid WorkFlowId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlow
        /// </summary>
        [ForeignKey("WorkFlowId")]
        public WorkFlow? WorkFlowId_WorkFlow { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the WorkFlowConfiguration belongs 
        /// </summary>
        [Required]
        public Guid WorkflowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkflowStateId")]
        public WorkFlowStates? WorkflowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field Enabled of the WorkFlowConfiguration 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Required field Sequence of the WorkFlowConfiguration 
        /// </summary>
        [Required]
        public short Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the WorkFlowConfiguration belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the WorkFlowConfiguration 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the WorkFlowConfiguration belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdateOn of the WorkFlowConfiguration 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
    }
}