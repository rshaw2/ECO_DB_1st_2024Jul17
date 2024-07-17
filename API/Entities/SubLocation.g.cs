using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a sublocation entity with essential details
    /// </summary>
    public class SubLocation
    {
        /// <summary>
        /// Primary key for the SubLocation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the SubLocation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the SubLocation belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Required field Code of the SubLocation 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Name of the SubLocation 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field RoomNumber of the SubLocation 
        /// </summary>
        [Required]
        public string RoomNumber { get; set; }

        /// <summary>
        /// Foreign key referencing the RoomType to which the SubLocation belongs 
        /// </summary>
        [Required]
        public Guid RoomTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated RoomType
        /// </summary>
        [ForeignKey("RoomTypeId")]
        public RoomType? RoomTypeId_RoomType { get; set; }

        /// <summary>
        /// Required field CanBeBooked of the SubLocation 
        /// </summary>
        [Required]
        public bool CanBeBooked { get; set; }

        /// <summary>
        /// Required field CanHaveInventory of the SubLocation 
        /// </summary>
        [Required]
        public bool CanHaveInventory { get; set; }

        /// <summary>
        /// Required field Active of the SubLocation 
        /// </summary>
        [Required]
        public bool Active { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the SubLocation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the SubLocation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SubLocation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the SubLocation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// OpeningBalanceDone of the SubLocation 
        /// </summary>
        public bool? OpeningBalanceDone { get; set; }
        /// <summary>
        /// Floor of the SubLocation 
        /// </summary>
        public string? Floor { get; set; }
        /// <summary>
        /// Ward of the SubLocation 
        /// </summary>
        public string? Ward { get; set; }
    }
}