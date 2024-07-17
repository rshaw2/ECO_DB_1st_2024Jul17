using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a usercredentiallogin entity with essential details
    /// </summary>
    public class UserCredentialLogin
    {
        /// <summary>
        /// Primary key for the UserCredentialLogin 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UserCredentialLogin belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserCredentialLogin belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Foreign key referencing the Credential to which the UserCredentialLogin belongs 
        /// </summary>
        [Required]
        public Guid Credential { get; set; }

        /// <summary>
        /// Navigation property representing the associated Credential
        /// </summary>
        [ForeignKey("Credential")]
        public Credential? Credential_Credential { get; set; }
        /// <summary>
        /// EmailVerified of the UserCredentialLogin 
        /// </summary>
        public bool? EmailVerified { get; set; }
        /// <summary>
        /// MobileVerified of the UserCredentialLogin 
        /// </summary>
        public bool? MobileVerified { get; set; }
        /// <summary>
        /// Default of the UserCredentialLogin 
        /// </summary>
        public bool? Default { get; set; }

        /// <summary>
        /// LastLoginDate of the UserCredentialLogin 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LastLoginDate { get; set; }
        /// <summary>
        /// RefreshToken of the UserCredentialLogin 
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// RefreshTokenExpiryTime of the UserCredentialLogin 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}