using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantdeleteotp entity with essential details
    /// </summary>
    public class TenantDeleteOtp
    {
        /// <summary>
        /// Initializes a new instance of the TenantDeleteOtp class.
        /// </summary>
        public TenantDeleteOtp()
        {
            Status = false;
        }

        /// <summary>
        /// Required field Status of the TenantDeleteOtp 
        /// </summary>
        [Required]
        public bool Status { get; set; }

        /// <summary>
        /// Required field GenerateOn of the TenantDeleteOtp 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime GenerateOn { get; set; }

        /// <summary>
        /// Required field ExpiresOn of the TenantDeleteOtp 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// Required field UserId of the TenantDeleteOtp 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Primary key for the TenantDeleteOtp 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantDeleteOtp belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }
        /// <summary>
        /// OTP of the TenantDeleteOtp 
        /// </summary>
        public string? OTP { get; set; }
    }
}