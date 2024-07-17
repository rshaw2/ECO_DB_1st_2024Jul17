using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktakecounter entity with essential details
    /// </summary>
    public class StockTakeCounter
    {
        /// <summary>
        /// Required field Prefix of the StockTakeCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the StockTakeCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the StockTakeCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the StockTakeCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the StockTakeCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the StockTakeCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the StockTakeCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}