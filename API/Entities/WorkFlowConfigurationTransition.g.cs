using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflowconfigurationtransition entity with essential details
    /// </summary>
    public class WorkFlowConfigurationTransition
    {
        /// <summary>
        /// Primary key for the WorkFlowConfigurationTransition 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlowConfigurationTransition belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowConfiguration to which the WorkFlowConfigurationTransition belongs 
        /// </summary>
        [Required]
        public Guid WorkflowConfigurationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowConfiguration
        /// </summary>
        [ForeignKey("WorkflowConfigurationId")]
        public WorkFlowConfiguration? WorkflowConfigurationId_WorkFlowConfiguration { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowTransitions to which the WorkFlowConfigurationTransition belongs 
        /// </summary>
        [Required]
        public Guid WorkflowTransitionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowTransitions
        /// </summary>
        [ForeignKey("WorkflowTransitionId")]
        public WorkFlowTransitions? WorkflowTransitionId_WorkFlowTransitions { get; set; }

        /// <summary>
        /// Required field Sequence of the WorkFlowConfigurationTransition 
        /// </summary>
        [Required]
        public short Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the WorkFlowConfigurationTransition belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the WorkFlowConfigurationTransition 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the WorkFlowConfigurationTransition belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdateOn of the WorkFlowConfigurationTransition 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        /// AssignmentMandatory of the WorkFlowConfigurationTransition 
        /// </summary>
        public bool? AssignmentMandatory { get; set; }
        /// <summary>
        /// AllotTime of the WorkFlowConfigurationTransition 
        /// </summary>
        public short? AllotTime { get; set; }
        /// <summary>
        /// CriticalTime of the WorkFlowConfigurationTransition 
        /// </summary>
        public short? CriticalTime { get; set; }
    }
}