using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stockadjustmentfile entity with essential details
    /// </summary>
    public class StockAdjustmentFile
    {
        /// <summary>
        /// Initializes a new instance of the StockAdjustmentFile class.
        /// </summary>
        public StockAdjustmentFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the StockAdjustmentFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockAdjustmentFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the StockAdjustment to which the StockAdjustmentFile belongs 
        /// </summary>
        [Required]
        public Guid StockAdjustmentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockAdjustment
        /// </summary>
        [ForeignKey("StockAdjustmentId")]
        public StockAdjustment? StockAdjustmentId_StockAdjustment { get; set; }

        /// <summary>
        /// Required field StockAdjustmentCode of the StockAdjustmentFile 
        /// </summary>
        [Required]
        public string StockAdjustmentCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockAdjustmentFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockAdjustmentFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the StockAdjustmentFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the StockAdjustmentFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the StockAdjustmentFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the StockAdjustmentFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the StockAdjustmentFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the StockAdjustmentFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}