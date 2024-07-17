using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitcounter entity with essential details
    /// </summary>
    public class VisitCounter
    {
        /// <summary>
        /// Required field Prefix of the VisitCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the VisitCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the VisitCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the VisitCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the VisitCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the VisitCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}