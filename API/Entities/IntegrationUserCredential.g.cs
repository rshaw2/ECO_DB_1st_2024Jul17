using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a integrationusercredential entity with essential details
    /// </summary>
    public class IntegrationUserCredential
    {
        /// <summary>
        /// Primary key for the IntegrationUserCredential 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the IntegrationUserCredential belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the IntegrationUser to which the IntegrationUserCredential belongs 
        /// </summary>
        [Required]
        public Guid IntegrationUserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated IntegrationUser
        /// </summary>
        [ForeignKey("IntegrationUserId")]
        public IntegrationUser? IntegrationUserId_IntegrationUser { get; set; }

        /// <summary>
        /// Required field UserName of the IntegrationUserCredential 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Required field PasswordHash of the IntegrationUserCredential 
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Required field PasswordSalt of the IntegrationUserCredential 
        /// </summary>
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Required field RoleId of the IntegrationUserCredential 
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the IntegrationUserCredential belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the IntegrationUserCredential 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the IntegrationUserCredential belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the IntegrationUserCredential 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}