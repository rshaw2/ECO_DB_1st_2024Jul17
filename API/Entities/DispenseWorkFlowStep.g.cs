using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dispenseworkflowstep entity with essential details
    /// </summary>
    public class DispenseWorkFlowStep
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the DispenseWorkFlowStep belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DispenseWorkFlowStep 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field FromStep of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public byte FromStep { get; set; }

        /// <summary>
        /// Required field ToStep of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public byte ToStep { get; set; }

        /// <summary>
        /// Required field ToStepText of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public string ToStepText { get; set; }

        /// <summary>
        /// Required field StepType of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public byte StepType { get; set; }

        /// <summary>
        /// Required field Sequence of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field ConfigureAssignment of the DispenseWorkFlowStep 
        /// </summary>
        [Required]
        public bool ConfigureAssignment { get; set; }
    }
}