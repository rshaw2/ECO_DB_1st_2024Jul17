using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a roleoperationscope entity with essential details
    /// </summary>
    public class RoleOperationScope
    {
        /// <summary>
        /// Primary key for the RoleOperationScope 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the RoleOperationScope belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the RoleOperation to which the RoleOperationScope belongs 
        /// </summary>
        [Required]
        public Guid RoleOperationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated RoleOperation
        /// </summary>
        [ForeignKey("RoleOperationId")]
        public RoleOperation? RoleOperationId_RoleOperation { get; set; }

        /// <summary>
        /// Required field Scope of the RoleOperationScope 
        /// </summary>
        [Required]
        public byte Scope { get; set; }

        /// <summary>
        /// Required field Code of the RoleOperationScope 
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}