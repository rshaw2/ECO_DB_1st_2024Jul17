using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stockadjustmentcounter entity with essential details
    /// </summary>
    public class StockAdjustmentCounter
    {
        /// <summary>
        /// Required field Prefix of the StockAdjustmentCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the StockAdjustmentCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the StockAdjustmentCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the StockAdjustmentCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the StockAdjustmentCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the StockAdjustmentCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the StockAdjustmentCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}