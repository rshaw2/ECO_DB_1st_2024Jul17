using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a procedureordercounter entity with essential details
    /// </summary>
    public class ProcedureOrderCounter
    {
        /// <summary>
        /// Required field Prefix of the ProcedureOrderCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the ProcedureOrderCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the ProcedureOrderCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ProcedureOrderCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the ProcedureOrderCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the ProcedureOrderCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the ProcedureOrderCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}