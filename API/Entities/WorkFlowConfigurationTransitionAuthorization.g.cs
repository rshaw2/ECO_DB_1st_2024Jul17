using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflowconfigurationtransitionauthorization entity with essential details
    /// </summary>
    public class WorkFlowConfigurationTransitionAuthorization
    {
        /// <summary>
        /// Primary key for the WorkFlowConfigurationTransitionAuthorization 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlowConfigurationTransitionAuthorization belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowConfigurationTransition to which the WorkFlowConfigurationTransitionAuthorization belongs 
        /// </summary>
        [Required]
        public Guid WorkflowConfigurationTransitionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowConfigurationTransition
        /// </summary>
        [ForeignKey("WorkflowConfigurationTransitionId")]
        public WorkFlowConfigurationTransition? WorkflowConfigurationTransitionId_WorkFlowConfigurationTransition { get; set; }

        /// <summary>
        /// Foreign key referencing the Role to which the WorkFlowConfigurationTransitionAuthorization belongs 
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Role
        /// </summary>
        [ForeignKey("RoleId")]
        public Role? RoleId_Role { get; set; }
    }
}