using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a investigationordercounter entity with essential details
    /// </summary>
    public class InvestigationOrderCounter
    {
        /// <summary>
        /// Required field Prefix of the InvestigationOrderCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the InvestigationOrderCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the InvestigationOrderCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the InvestigationOrderCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the InvestigationOrderCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the InvestigationOrderCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the InvestigationOrderCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}