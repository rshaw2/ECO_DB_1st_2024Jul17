using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a subscriptionproduct entity with essential details
    /// </summary>
    public class SubscriptionProduct
    {
        /// <summary>
        /// Primary key for the SubscriptionProduct 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Name of the SubscriptionProduct 
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}