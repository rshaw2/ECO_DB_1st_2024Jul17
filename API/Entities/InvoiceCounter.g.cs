using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoicecounter entity with essential details
    /// </summary>
    public class InvoiceCounter
    {
        /// <summary>
        /// Required field Prefix of the InvoiceCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the InvoiceCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the InvoiceCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvoiceCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the InvoiceCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the InvoiceCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the InvoiceCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}