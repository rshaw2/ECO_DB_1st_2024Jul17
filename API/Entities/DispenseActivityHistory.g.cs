using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dispenseactivityhistory entity with essential details
    /// </summary>
    public class DispenseActivityHistory
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the DispenseActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DispenseActivityHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Dispense to which the DispenseActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid DispenseId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Dispense
        /// </summary>
        [ForeignKey("DispenseId")]
        public Dispense? DispenseId_Dispense { get; set; }

        /// <summary>
        /// Required field Step of the DispenseActivityHistory 
        /// </summary>
        [Required]
        public byte Step { get; set; }

        /// <summary>
        /// Required field TransactionDate of the DispenseActivityHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DispenseActivityHistory belongs 
        /// </summary>
        [Required]
        public Guid TransactionBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("TransactionBy")]
        public User? TransactionBy_User { get; set; }

        /// <summary>
        /// Required field Description of the DispenseActivityHistory 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Required field Active of the DispenseActivityHistory 
        /// </summary>
        [Required]
        public bool Active { get; set; }
        /// <summary>
        /// Reason of the DispenseActivityHistory 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DispenseActivityHistory belongs 
        /// </summary>
        public Guid? AssignedUser { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("AssignedUser")]
        public User? AssignedUser_User { get; set; }
    }
}