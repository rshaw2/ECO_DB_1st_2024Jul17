using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a workflowstates entity with essential details
    /// </summary>
    public class WorkFlowStates
    {
        /// <summary>
        /// Initializes a new instance of the WorkFlowStates class.
        /// </summary>
        public WorkFlowStates()
        {
            Sequence = 0;
        }

        /// <summary>
        /// Primary key for the WorkFlowStates 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the WorkFlowStates belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field EntityName of the WorkFlowStates 
        /// </summary>
        [Required]
        public string EntityName { get; set; }

        /// <summary>
        /// Required field States of the WorkFlowStates 
        /// </summary>
        [Required]
        public Guid States { get; set; }

        /// <summary>
        /// Required field Sequence of the WorkFlowStates 
        /// </summary>
        [Required]
        public int Sequence { get; set; }
        /// <summary>
        /// StateName of the WorkFlowStates 
        /// </summary>
        public string? StateName { get; set; }
    }
}