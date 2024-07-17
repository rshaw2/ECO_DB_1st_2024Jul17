using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a requisitioncounter entity with essential details
    /// </summary>
    public class RequisitionCounter
    {
        /// <summary>
        /// Required field Prefix of the RequisitionCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the RequisitionCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the RequisitionCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the RequisitionCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the RequisitionCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the RequisitionCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the RequisitionCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}