using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a orderablecomponent entity with essential details
    /// </summary>
    public class OrderableComponent
    {
        /// <summary>
        /// Primary key for the OrderableComponent 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the OrderableComponent belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field ComponentType of the OrderableComponent 
        /// </summary>
        [Required]
        public byte ComponentType { get; set; }

        /// <summary>
        /// Required field Name of the OrderableComponent 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Active of the OrderableComponent 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Required field AutoAddInvoice of the OrderableComponent 
        /// </summary>
        [Required]
        public bool AutoAddInvoice { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the OrderableComponent belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the OrderableComponent 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the OrderableComponent belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the OrderableComponent 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// AutoAddOnWorkflowStep of the OrderableComponent 
        /// </summary>
        public bool? AutoAddOnWorkflowStep { get; set; }
        /// <summary>
        /// WorkFlowState of the OrderableComponent 
        /// </summary>
        public Guid? WorkFlowState { get; set; }
    }
}