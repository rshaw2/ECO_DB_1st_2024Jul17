using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedureorderworkflowactivityhistory entity with essential details
    /// </summary>
    public class ProcedureOrderWorkflowActivityHistory
    {
        /// <summary>
        /// Primary key for the ProcedureOrderWorkflowActivityHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the ProcedureOrder to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid ProcedureOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProcedureOrder
        /// </summary>
        [ForeignKey("ProcedureOrderId")]
        public ProcedureOrder? ProcedureOrderId_ProcedureOrder { get; set; }

        /// <summary>
        /// Foreign key referencing the ProcedureOrderLine to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid ProcedureOrderLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProcedureOrderLine
        /// </summary>
        [ForeignKey("ProcedureOrderLineId")]
        public ProcedureOrderLine? ProcedureOrderLineId_ProcedureOrderLine { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid WorkflowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkflowStateId")]
        public WorkFlowStates? WorkflowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field StartTime of the ProcedureOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ProcedureOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Active of the ProcedureOrderWorkflowActivityHistory 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// EndTime of the ProcedureOrderWorkflowActivityHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ProcedureOrderWorkflowActivityHistory belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}