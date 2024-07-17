using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a despencecounter entity with essential details
    /// </summary>
    public class DespenceCounter
    {
        /// <summary>
        /// Required field Prefix of the DespenceCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the DespenceCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the DespenceCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DespenceCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the DespenceCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the DespenceCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the DespenceCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}