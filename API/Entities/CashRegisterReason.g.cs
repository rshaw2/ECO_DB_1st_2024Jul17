using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cashregisterreason entity with essential details
    /// </summary>
    public class CashRegisterReason
    {
        /// <summary>
        /// Primary key for the CashRegisterReason 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CashRegisterReason belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the CashRegisterReason 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field ReasonType of the CashRegisterReason 
        /// </summary>
        [Required]
        public byte ReasonType { get; set; }
    }
}