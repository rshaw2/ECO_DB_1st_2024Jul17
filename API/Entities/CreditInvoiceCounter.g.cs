using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a creditinvoicecounter entity with essential details
    /// </summary>
    public class CreditInvoiceCounter
    {
        /// <summary>
        /// Required field Prefix of the CreditInvoiceCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the CreditInvoiceCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the CreditInvoiceCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the CreditInvoiceCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the CreditInvoiceCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the CreditInvoiceCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the CreditInvoiceCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}