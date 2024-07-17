using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a integrationuserloginhistory entity with essential details
    /// </summary>
    public class IntegrationUserLoginHistory
    {
        /// <summary>
        /// Required field UserName of the IntegrationUserLoginHistory 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Required field IpAddress of the IntegrationUserLoginHistory 
        /// </summary>
        [Required]
        public string IpAddress { get; set; }

        /// <summary>
        /// Required field LoginDate of the IntegrationUserLoginHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// Primary key for the IntegrationUserLoginHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the IntegrationUserLoginHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field LoginSuccessful of the IntegrationUserLoginHistory 
        /// </summary>
        [Required]
        public bool LoginSuccessful { get; set; }
        /// <summary>
        /// Reason of the IntegrationUserLoginHistory 
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// Foreign key referencing the IntegrationUser to which the IntegrationUserLoginHistory belongs 
        /// </summary>
        public Guid? IntegrationUserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated IntegrationUser
        /// </summary>
        [ForeignKey("IntegrationUserId")]
        public IntegrationUser? IntegrationUserId_IntegrationUser { get; set; }
        /// <summary>
        /// Country of the IntegrationUserLoginHistory 
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// Region of the IntegrationUserLoginHistory 
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Isp of the IntegrationUserLoginHistory 
        /// </summary>
        public string? Isp { get; set; }
    }
}