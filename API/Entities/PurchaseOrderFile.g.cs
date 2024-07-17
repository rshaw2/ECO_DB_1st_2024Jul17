using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchaseorderfile entity with essential details
    /// </summary>
    public class PurchaseOrderFile
    {
        /// <summary>
        /// Initializes a new instance of the PurchaseOrderFile class.
        /// </summary>
        public PurchaseOrderFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the PurchaseOrderFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the PurchaseOrderFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the PurchaseOrder to which the PurchaseOrderFile belongs 
        /// </summary>
        [Required]
        public Guid PurchaseOrderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PurchaseOrder
        /// </summary>
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder? PurchaseOrderId_PurchaseOrder { get; set; }

        /// <summary>
        /// Required field PurchaseOrderCode of the PurchaseOrderFile 
        /// </summary>
        [Required]
        public string PurchaseOrderCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the PurchaseOrderFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the PurchaseOrderFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the PurchaseOrderFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the PurchaseOrderFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the PurchaseOrderFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the PurchaseOrderFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the PurchaseOrderFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the PurchaseOrderFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}