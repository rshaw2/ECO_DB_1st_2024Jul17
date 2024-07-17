using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitworkflowstep entity with essential details
    /// </summary>
    public class VisitWorkFlowStep
    {
        /// <summary>
        /// Primary key for the VisitWorkFlowStep 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitWorkFlowStep belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field FromStep of the VisitWorkFlowStep 
        /// </summary>
        [Required]
        public byte FromStep { get; set; }

        /// <summary>
        /// Required field ToStep of the VisitWorkFlowStep 
        /// </summary>
        [Required]
        public byte ToStep { get; set; }

        /// <summary>
        /// Required field ToStepText of the VisitWorkFlowStep 
        /// </summary>
        [Required]
        public string ToStepText { get; set; }

        /// <summary>
        /// Required field StepType of the VisitWorkFlowStep 
        /// </summary>
        [Required]
        public byte StepType { get; set; }
        /// <summary>
        /// Sequence of the VisitWorkFlowStep 
        /// </summary>
        public byte? Sequence { get; set; }
        /// <summary>
        /// ConfigureAssignment of the VisitWorkFlowStep 
        /// </summary>
        public bool? ConfigureAssignment { get; set; }
    }
}