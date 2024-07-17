using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflowtransitions entity with essential details
    /// </summary>
    public class WorkFlowTransitions
    {
        /// <summary>
        /// Initializes a new instance of the WorkFlowTransitions class.
        /// </summary>
        public WorkFlowTransitions()
        {
            Sequence = 0;
        }

        /// <summary>
        /// Primary key for the WorkFlowTransitions 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlowTransitions belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field EntityName of the WorkFlowTransitions 
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Required field Transitions of the WorkFlowTransitions 
        /// </summary>
        [Required]
        public Guid Transitions { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the WorkFlowTransitions belongs 
        /// </summary>
        [Required]
        public Guid WorkFlowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkFlowStateId")]
        public WorkFlowStates? WorkFlowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field Sequence of the WorkFlowTransitions 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// TransitionName of the WorkFlowTransitions 
        /// </summary>
        public string? TransitionName { get; set; }
    }
}