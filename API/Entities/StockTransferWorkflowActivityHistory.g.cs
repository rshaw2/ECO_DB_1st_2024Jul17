using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktransferworkflowactivityhistory entity with essential details
    /// </summary>
    public class StockTransferWorkflowActivityHistory
    {
        /// <summary>
        /// Primary key for the StockTransferWorkflowActivityHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTransferWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the StockTransfer to which the StockTransferWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid StockTransferId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockTransfer
        /// </summary>
        [ForeignKey("StockTransferId")]
        public StockTransfer? StockTransferId_StockTransfer { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the StockTransferWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid WorkflowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkflowStateId")]
        public WorkFlowStates? WorkflowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field StartTime of the StockTransferWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockTransferWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockTransferWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Active of the StockTransferWorkflowActivityHistory 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// EndTime of the StockTransferWorkflowActivityHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the StockTransferWorkflowActivityHistory belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}