using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationorderworkflowactivityhistory entity with essential details
    /// </summary>
    public class InvestigationOrderWorkflowActivityHistory
    {
        /// <summary>
        /// Primary key for the InvestigationOrderWorkflowActivityHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InvestigationOrder to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid InvestigationOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationOrder
        /// </summary>
        [ForeignKey("InvestigationOrderId")]
        public InvestigationOrder? InvestigationOrderId_InvestigationOrder { get; set; }

        /// <summary>
        /// Foreign key referencing the InvestigationOrderLine to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid InvestigationOrderLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InvestigationOrderLine
        /// </summary>
        [ForeignKey("InvestigationOrderLineId")]
        public InvestigationOrderLine? InvestigationOrderLineId_InvestigationOrderLine { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid WorkflowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkflowStateId")]
        public WorkFlowStates? WorkflowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field StartTime of the InvestigationOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvestigationOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Active of the InvestigationOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// EndTime of the InvestigationOrderWorkflowActivityHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvestigationOrderWorkflowActivityHistory belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}