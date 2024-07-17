using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a goodsreturncounter entity with essential details
    /// </summary>
    public class GoodsReturnCounter
    {
        /// <summary>
        /// Required field Prefix of the GoodsReturnCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the GoodsReturnCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the GoodsReturnCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the GoodsReturnCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the GoodsReturnCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the GoodsReturnCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the GoodsReturnCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}