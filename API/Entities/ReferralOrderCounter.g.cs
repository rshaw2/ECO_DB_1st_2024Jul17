using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a referralordercounter entity with essential details
    /// </summary>
    public class ReferralOrderCounter
    {
        /// <summary>
        /// Required field Prefix of the ReferralOrderCounter 
        /// </summary>
        [Required]
        public string Prefix { get; set; }

        /// <summary>
        /// Primary key for the ReferralOrderCounter 
        /// </summary>
        [Key]
        [Required]
        public Guid? TenantId { get; set; }
        /// <summary>
        /// Code of the ReferralOrderCounter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ReferralOrderCounter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Postfix of the ReferralOrderCounter 
        /// </summary>
        public string? Postfix { get; set; }
        /// <summary>
        /// CurrentNumber of the ReferralOrderCounter 
        /// </summary>
        public int? CurrentNumber { get; set; }
        /// <summary>
        /// IncrementStep of the ReferralOrderCounter 
        /// </summary>
        public int? IncrementStep { get; set; }
    }
}