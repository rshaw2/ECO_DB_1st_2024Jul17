using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreceiptcounter entity with essential details
    /// </summary>
    public class GoodsReceiptCounter
    {
        /// <summary>
        /// Required field Prefix of the GoodsReceiptCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the GoodsReceiptCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the GoodsReceiptCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the GoodsReceiptCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the GoodsReceiptCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the GoodsReceiptCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the GoodsReceiptCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}