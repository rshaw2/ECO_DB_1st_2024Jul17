using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cashregistervariance entity with essential details
    /// </summary>
    public class CashRegisterVariance
    {
        /// <summary>
        /// Primary key for the CashRegisterVariance 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CashRegisterVariance belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the CashRegister to which the CashRegisterVariance belongs 
        /// </summary>
        [Required]
        public Guid CashRegisterId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CashRegister
        /// </summary>
        [ForeignKey("CashRegisterId")]
        public CashRegister? CashRegisterId_CashRegister { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the CashRegisterVariance belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Required field ActualBalance of the CashRegisterVariance 
        /// </summary>
        [Required]
        public decimal ActualBalance { get; set; }

        /// <summary>
        /// Required field ExpectedBalance of the CashRegisterVariance 
        /// </summary>
        [Required]
        public decimal ExpectedBalance { get; set; }

        /// <summary>
        /// Required field Variance of the CashRegisterVariance 
        /// </summary>
        [Required]
        public decimal Variance { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CashRegisterVariance belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CashRegisterVariance 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Reason of the CashRegisterVariance 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the CashRegisterVariance belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
    }
}