using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoiceline entity with essential details
    /// </summary>
    public class InvoiceLine
    {
        /// <summary>
        /// Initializes a new instance of the InvoiceLine class.
        /// </summary>
        public InvoiceLine()
        {
            IsStandard = false;
            DiscountPercentage = false;
            Dispensed = false;
        }

        /// <summary>
        /// Required field IsStandard of the InvoiceLine 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the InvoiceLine 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the InvoiceLine 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InvoiceLine 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the InvoiceLine 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Invoice to which the InvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid Invoice { get; set; }

        /// <summary>
        /// Navigation property representing the associated Invoice
        /// </summary>
        [ForeignKey("Invoice")]
        public Invoice? Invoice_Invoice { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the InvoiceLine belongs 
        /// </summary>
        [Required]
        public Guid Product { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("Product")]
        public Product? Product_Product { get; set; }

        /// <summary>
        /// Required field Description of the InvoiceLine 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Required field Quantity of the InvoiceLine 
        /// </summary>
        [Required]
        public short Quantity { get; set; }

        /// <summary>
        /// Required field UnitPrice of the InvoiceLine 
        /// </summary>
        [Required]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Required field Amount of the InvoiceLine 
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// CoPayAmount of the InvoiceLine 
        /// </summary>
        public decimal? CoPayAmount { get; set; }
        /// <summary>
        /// PayorAmount of the InvoiceLine 
        /// </summary>
        public decimal? PayorAmount { get; set; }
        /// <summary>
        /// DiscountTotal of the InvoiceLine 
        /// </summary>
        public decimal? DiscountTotal { get; set; }
        /// <summary>
        /// DiscountPercentage of the InvoiceLine 
        /// </summary>
        public bool? DiscountPercentage { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvoiceLine belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InvoiceLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Name of the InvoiceLine 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the InvoiceLine 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Code of the InvoiceLine 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductBatch to which the InvoiceLine belongs 
        /// </summary>
        public Guid? ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
        /// <summary>
        /// BatchNumber of the InvoiceLine 
        /// </summary>
        public string? BatchNumber { get; set; }

        /// <summary>
        /// BatchExapiryDate of the InvoiceLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? BatchExapiryDate { get; set; }
        /// <summary>
        /// CostPrice of the InvoiceLine 
        /// </summary>
        public decimal? CostPrice { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the InvoiceLine belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
        /// <summary>
        /// Foreign key referencing the GstSettings to which the InvoiceLine belongs 
        /// </summary>
        public Guid? GSTSettingsId { get; set; }

        /// <summary>
        /// Navigation property representing the associated GstSettings
        /// </summary>
        [ForeignKey("GSTSettingsId")]
        public GstSettings? GSTSettingsId_GstSettings { get; set; }
        /// <summary>
        /// GSTPercentage of the InvoiceLine 
        /// </summary>
        public int? GSTPercentage { get; set; }
        /// <summary>
        /// HSNCode of the InvoiceLine 
        /// </summary>
        public string? HSNCode { get; set; }
        /// <summary>
        /// TaxAmount of the InvoiceLine 
        /// </summary>
        public decimal? TaxAmount { get; set; }
        /// <summary>
        /// DiscountValue of the InvoiceLine 
        /// </summary>
        public decimal? DiscountValue { get; set; }
        /// <summary>
        /// Dispensed of the InvoiceLine 
        /// </summary>
        public bool? Dispensed { get; set; }
        /// <summary>
        /// WriteOff of the InvoiceLine 
        /// </summary>
        public bool? WriteOff { get; set; }
        /// <summary>
        /// WriteOffReason of the InvoiceLine 
        /// </summary>
        public string? WriteOffReason { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvoiceLine belongs 
        /// </summary>
        public Guid? WriteOffBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("WriteOffBy")]
        public User? WriteOffBy_User { get; set; }
        /// <summary>
        /// ActualPrice of the InvoiceLine 
        /// </summary>
        public decimal? ActualPrice { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InvoiceLine belongs 
        /// </summary>
        public Guid? OverrideBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("OverrideBy")]
        public User? OverrideBy_User { get; set; }

        /// <summary>
        /// OverrideDate of the InvoiceLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? OverrideDate { get; set; }

        /// <summary>
        /// WriteOffDate of the InvoiceLine 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? WriteOffDate { get; set; }
        /// <summary>
        /// OrderLineId of the InvoiceLine 
        /// </summary>
        public Guid? OrderLineId { get; set; }
        /// <summary>
        /// OrderType of the InvoiceLine 
        /// </summary>
        public byte? OrderType { get; set; }
    }
}