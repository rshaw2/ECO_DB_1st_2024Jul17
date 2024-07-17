using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a subscriptionprice entity with essential details
    /// </summary>
    public class SubscriptionPrice
    {
        /// <summary>
        /// Primary key for the SubscriptionPrice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the SubscriptionProduct to which the SubscriptionPrice belongs 
        /// </summary>
        [Required]
        public Guid SubscriptionProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubscriptionProduct
        /// </summary>
        [ForeignKey("SubscriptionProductId")]
        public SubscriptionProduct? SubscriptionProductId_SubscriptionProduct { get; set; }

        /// <summary>
        /// Foreign key referencing the Package to which the SubscriptionPrice belongs 
        /// </summary>
        [Required]
        public Guid PackageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Package
        /// </summary>
        [ForeignKey("PackageId")]
        public Package? PackageId_Package { get; set; }

        /// <summary>
        /// Required field PaymentTerm of the SubscriptionPrice 
        /// </summary>
        [Required]
        public byte PaymentTerm { get; set; }

        /// <summary>
        /// Required field Price of the SubscriptionPrice 
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Required field SubscriptionUnit of the SubscriptionPrice 
        /// </summary>
        [Required]
        public byte SubscriptionUnit { get; set; }
    }
}