using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cashregister entity with essential details
    /// </summary>
    public class CashRegister
    {
        /// <summary>
        /// Primary key for the CashRegister 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CashRegister belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Code of the CashRegister 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the CashRegister belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CashRegister belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CashRegister 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Enabled of the CashRegister 
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Required field FloatAmount of the CashRegister 
        /// </summary>
        [Required]
        public decimal FloatAmount { get; set; }
        /// <summary>
        /// TotalAmount of the CashRegister 
        /// </summary>
        public decimal? TotalAmount { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CashRegister belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdateOn of the CashRegister 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateOn { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the CashRegister belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
    }
}