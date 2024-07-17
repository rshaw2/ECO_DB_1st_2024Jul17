using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a smslog entity with essential details
    /// </summary>
    public class SmsLog
    {
        /// <summary>
        /// Initializes a new instance of the SmsLog class.
        /// </summary>
        public SmsLog()
        {
            Status = false;
        }

        /// <summary>
        /// Primary key for the SmsLog 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the SmsLog belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Mobile of the SmsLog 
        /// </summary>
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// Required field SendDate of the SmsLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Required field Status of the SmsLog 
        /// </summary>
        [Required]
        public bool Status { get; set; }
        /// <summary>
        /// StatusMessage of the SmsLog 
        /// </summary>
        public string? StatusMessage { get; set; }
        /// <summary>
        /// Message of the SmsLog 
        /// </summary>
        public string? Message { get; set; }
        /// <summary>
        /// MessageId of the SmsLog 
        /// </summary>
        public string? MessageId { get; set; }
    }
}