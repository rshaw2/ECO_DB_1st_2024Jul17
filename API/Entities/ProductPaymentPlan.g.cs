using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productpaymentplan entity with essential details
    /// </summary>
    public class ProductPaymentPlan
    {
        /// <summary>
        /// Primary key for the ProductPaymentPlan 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ProductPaymentPlan belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Product to which the ProductPaymentPlan belongs 
        /// </summary>
        [Required]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }

        /// <summary>
        /// Required field PaymentPlanType of the ProductPaymentPlan 
        /// </summary>
        [Required]
        public byte PaymentPlanType { get; set; }

        /// <summary>
        /// Required field InstallmentPercentage of the ProductPaymentPlan 
        /// </summary>
        [Required]
        public decimal InstallmentPercentage { get; set; }

        /// <summary>
        /// Required field Sequence of the ProductPaymentPlan 
        /// </summary>
        [Required]
        public byte Sequence { get; set; }

        /// <summary>
        /// Required field After of the ProductPaymentPlan 
        /// </summary>
        [Required]
        public byte After { get; set; }

        /// <summary>
        /// Required field DueDurationInDays of the ProductPaymentPlan 
        /// </summary>
        [Required]
        public int DueDurationInDays { get; set; }
        /// <summary>
        /// Duration of the ProductPaymentPlan 
        /// </summary>
        public byte? Duration { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the ProductPaymentPlan belongs 
        /// </summary>
        public Guid? DurationUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("DurationUomId")]
        public UOM? DurationUomId_UOM { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductPaymentPlan to which the ProductPaymentPlan belongs 
        /// </summary>
        public Guid? ReferenceProductPaymentId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductPaymentPlan
        /// </summary>
        [ForeignKey("ReferenceProductPaymentId")]
        public ProductPaymentPlan? ReferenceProductPaymentId_ProductPaymentPlan { get; set; }
        /// <summary>
        /// Foreign key referencing the ProductSchedule to which the ProductPaymentPlan belongs 
        /// </summary>
        public Guid? ProductScheduleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ProductSchedule
        /// </summary>
        [ForeignKey("ProductScheduleId")]
        public ProductSchedule? ProductScheduleId_ProductSchedule { get; set; }
    }
}