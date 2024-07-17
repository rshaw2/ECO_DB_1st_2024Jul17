using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktakeitem entity with essential details
    /// </summary>
    public class StockTakeItem
    {
        /// <summary>
        /// Initializes a new instance of the StockTakeItem class.
        /// </summary>
        public StockTakeItem()
        {
            LineRejected = false;
        }

        /// <summary>
        /// Primary key for the StockTakeItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTakeItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the StockTake to which the StockTakeItem belongs 
        /// </summary>
        [Required]
        public Guid StockTakeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockTake
        /// </summary>
        [ForeignKey("StockTakeId")]
        public StockTake? StockTakeId_StockTake { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the StockTakeItem belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field TakeCount of the StockTakeItem 
        /// </summary>
        [Required]
        public int TakeCount { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockTakeItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockTakeItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field LineRejected of the StockTakeItem 
        /// </summary>
        [Required]
        public bool LineRejected { get; set; }
        /// <summary>
        /// RejectReason of the StockTakeItem 
        /// </summary>
        public string? RejectReason { get; set; }
        /// <summary>
        /// Variance of the StockTakeItem 
        /// </summary>
        public int? Variance { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the StockTakeItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the StockTakeItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// LowestUnitQuantity of the StockTakeItem 
        /// </summary>
        public int? LowestUnitQuantity { get; set; }
    }
}