using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a credentialhistory entity with essential details
    /// </summary>
    public class CredentialHistory
    {
        /// <summary>
        /// Initializes a new instance of the CredentialHistory class.
        /// </summary>
        public CredentialHistory()
        {
            IsStandard = false;
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the CredentialHistory belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the CredentialHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field RefId of the CredentialHistory 
        /// </summary>
        [Required]
        public Guid RefId { get; set; }

        /// <summary>
        /// Required field UserName of the CredentialHistory 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Required field PasswordHash of the CredentialHistory 
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Required field PasswordSalt of the CredentialHistory 
        /// </summary>
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Required field CreatedDate of the CredentialHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the CredentialHistory belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the CredentialHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the CredentialHistory 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the CredentialHistory 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the CredentialHistory belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the CredentialHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Active of the CredentialHistory 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// EntityCode of the CredentialHistory 
        /// </summary>
        public string? EntityCode { get; set; }
        /// <summary>
        /// EntitySubTypeCode of the CredentialHistory 
        /// </summary>
        public string? EntitySubTypeCode { get; set; }
        /// <summary>
        /// Code of the CredentialHistory 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the CredentialHistory 
        /// </summary>
        public string? Name { get; set; }
    }
}