using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitworkflowactivityhistory entity with essential details
    /// </summary>
    public class VisitWorkflowActivityHistory
    {
        /// <summary>
        /// Initializes a new instance of the VisitWorkflowActivityHistory class.
        /// </summary>
        public VisitWorkflowActivityHistory()
        {
            Active = false;
        }

        /// <summary>
        /// Primary key for the VisitWorkflowActivityHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Foreign key referencing the WorkFlowStates to which the VisitWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid WorkflowStateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated WorkFlowStates
        /// </summary>
        [ForeignKey("WorkflowStateId")]
        public WorkFlowStates? WorkflowStateId_WorkFlowStates { get; set; }

        /// <summary>
        /// Required field StartTime of the VisitWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitWorkflowActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitWorkflowActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Active of the VisitWorkflowActivityHistory 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// EndTime of the VisitWorkflowActivityHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitWorkflowActivityHistory belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}