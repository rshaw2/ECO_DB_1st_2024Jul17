using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a usercounter entity with essential details
    /// </summary>
    public class UserCounter
    {
        /// <summary>
        /// Required field Prefix of the UserCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the UserCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the UserCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the UserCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the UserCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the UserCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the UserCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}