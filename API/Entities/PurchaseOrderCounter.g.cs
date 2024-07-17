using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchaseordercounter entity with essential details
    /// </summary>
    public class PurchaseOrderCounter
    {
        /// <summary>
        /// Required field Prefix of the PurchaseOrderCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the PurchaseOrderCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the PurchaseOrderCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PurchaseOrderCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the PurchaseOrderCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the PurchaseOrderCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the PurchaseOrderCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}