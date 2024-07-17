using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dispenseitem entity with essential details
    /// </summary>
    public class DispenseItem
    {
        /// <summary>
        /// Initializes a new instance of the DispenseItem class.
        /// </summary>
        public DispenseItem()
        {
            FromOpenPrescription = false;
        }

        /// <summary>
        /// Required field Quantity of the DispenseItem 
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Primary key for the DispenseItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DispenseItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Dispense to which the DispenseItem belongs 
        /// </summary>
        [Required]
        public Guid DispenseId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Dispense
        /// </summary>
        [ForeignKey("DispenseId")]
        public Dispense? DispenseId_Dispense { get; set; }

        /// <summary>
        /// Required field Sequence of the DispenseItem 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field TotalAmount of the DispenseItem 
        /// </summary>
        [Required]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DispenseItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DispenseItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field FromOpenPrescription of the DispenseItem 
        /// </summary>
        [Required]
        public bool FromOpenPrescription { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DispenseItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DispenseItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Summary of the DispenseItem 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// HSNCode of the DispenseItem 
        /// </summary>
        public string? HSNCode { get; set; }
        /// <summary>
        /// Delete of the DispenseItem 
        /// </summary>
        public bool? Delete { get; set; }
        /// <summary>
        /// DeleteReason of the DispenseItem 
        /// </summary>
        public string? DeleteReason { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitMedication to which the DispenseItem belongs 
        /// </summary>
        public Guid? VisitMedicationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedication
        /// </summary>
        [ForeignKey("VisitMedicationId")]
        public VisitMedication? VisitMedicationId_VisitMedication { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the DispenseItem belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductBatch to which the DispenseItem belongs 
        /// </summary>
        public Guid? ProductBatchId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductBatch
        /// </summary>
        [ForeignKey("ProductBatchId")]
        public ProductBatch? ProductBatchId_ProductBatch { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductUom to which the DispenseItem belongs 
        /// </summary>
        public Guid? ProductUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductUom
        /// </summary>
        [ForeignKey("ProductUomId")]
        public ProductUom? ProductUomId_ProductUom { get; set; }
        /// <summary>
        /// LowestUnitQuantity of the DispenseItem 
        /// </summary>
        public int? LowestUnitQuantity { get; set; }
        /// <summary>
        /// UnitSellingPrice of the DispenseItem 
        /// </summary>
        public decimal? UnitSellingPrice { get; set; }
        /// <summary>
        /// TaxPercent of the DispenseItem 
        /// </summary>
        public int? TaxPercent { get; set; }
        /// <summary>
        /// TaxAmount of the DispenseItem 
        /// </summary>
        public decimal? TaxAmount { get; set; }
        /// <summary>
        /// DiscountPercent of the DispenseItem 
        /// </summary>
        public decimal? DiscountPercent { get; set; }
        /// <summary>
        /// DiscountAmount of the DispenseItem 
        /// </summary>
        public decimal? DiscountAmount { get; set; }
        /// <summary>
        /// DiscountType of the DispenseItem 
        /// </summary>
        public byte? DiscountType { get; set; }
    }
}