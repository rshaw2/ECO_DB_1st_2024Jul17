using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktake entity with essential details
    /// </summary>
    public class StockTake
    {
        /// <summary>
        /// Primary key for the StockTake 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTake belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Code of the StockTake 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field StockTakeType of the StockTake 
        /// </summary>
        [Required]
        public byte StockTakeType { get; set; }

        /// <summary>
        /// Required field EstimatedTakeCount of the StockTake 
        /// </summary>
        [Required]
        public byte EstimatedTakeCount { get; set; }

        /// <summary>
        /// Required field OngoingCount of the StockTake 
        /// </summary>
        [Required]
        public byte OngoingCount { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the StockTake belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockTake belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockTake 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the StockTake belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the StockTake 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the StockTake belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
        /// <summary>
        /// ReferenceNo of the StockTake 
        /// </summary>
        public string? ReferenceNo { get; set; }
        /// <summary>
        /// AdjustmentQuantity of the StockTake 
        /// </summary>
        public int? AdjustmentQuantity { get; set; }
        /// <summary>
        /// AdjustmentAmount of the StockTake 
        /// </summary>
        public decimal? AdjustmentAmount { get; set; }
    }
}