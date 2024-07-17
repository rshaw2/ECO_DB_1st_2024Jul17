using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktransfercounter entity with essential details
    /// </summary>
    public class StockTransferCounter
    {
        /// <summary>
        /// Required field Prefix of the StockTransferCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the StockTransferCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the StockTransferCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the StockTransferCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the StockTransferCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the StockTransferCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the StockTransferCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}