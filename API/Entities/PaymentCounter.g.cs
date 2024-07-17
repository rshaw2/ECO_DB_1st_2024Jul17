using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a paymentcounter entity with essential details
    /// </summary>
    public class PaymentCounter
    {
        /// <summary>
        /// Required field Prefix of the PaymentCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the PaymentCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the PaymentCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the PaymentCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the PaymentCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the PaymentCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the PaymentCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}