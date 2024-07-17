using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreceiptfile entity with essential details
    /// </summary>
    public class GoodsReceiptFile
    {
        /// <summary>
        /// Initializes a new instance of the GoodsReceiptFile class.
        /// </summary>
        public GoodsReceiptFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the GoodsReceiptFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GoodsReceiptFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the GoodsReceipt to which the GoodsReceiptFile belongs 
        /// </summary>
        [Required]
        public Guid GoodsReceiptId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GoodsReceipt
        /// </summary>
        [ForeignKey("GoodsReceiptId")]
        public GoodsReceipt? GoodsReceiptId_GoodsReceipt { get; set; }

        /// <summary>
        /// Required field GoodsReceiptCode of the GoodsReceiptFile 
        /// </summary>
        [Required]
        public string GoodsReceiptCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GoodsReceiptFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GoodsReceiptFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the GoodsReceiptFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the GoodsReceiptFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the GoodsReceiptFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the GoodsReceiptFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the GoodsReceiptFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the GoodsReceiptFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}