using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a financesettings entity with essential details
    /// </summary>
    public class FinanceSettings
    {
        /// <summary>
        /// Foreign key referencing the User to which the FinanceSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the FinanceSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the FinanceSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the FinanceSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field FinancialYearType of the FinanceSettings 
        /// </summary>
        [Required]
        public byte FinancialYearType { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the FinanceSettings belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the FinanceSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the FinanceSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// VoidInvoiceRequired of the FinanceSettings 
        /// </summary>
        public bool? VoidInvoiceRequired { get; set; }
        /// <summary>
        /// VoidInvoiceExpiry of the FinanceSettings 
        /// </summary>
        public short? VoidInvoiceExpiry { get; set; }
        /// <summary>
        /// AllowMultiplelinesWithSameProduct of the FinanceSettings 
        /// </summary>
        public bool? AllowMultiplelinesWithSameProduct { get; set; }
        /// <summary>
        /// AllowZeroAmountInvoiceline of the FinanceSettings 
        /// </summary>
        public bool? AllowZeroAmountInvoiceline { get; set; }
    }
}