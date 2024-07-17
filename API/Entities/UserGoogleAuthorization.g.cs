using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a usergoogleauthorization entity with essential details
    /// </summary>
    public class UserGoogleAuthorization
    {
        /// <summary>
        /// Primary key for the UserGoogleAuthorization 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UserGoogleAuthorization belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserGoogleAuthorization belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Required field AccesssToken of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        public string AccesssToken { get; set; }

        /// <summary>
        /// Required field ExpiresInSeconds of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        public int ExpiresInSeconds { get; set; }

        /// <summary>
        /// Required field RefreshToken of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Required field GoogleEmail of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        public string GoogleEmail { get; set; }

        /// <summary>
        /// Required field CreatedOn of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IssuedUtc of the UserGoogleAuthorization 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime IssuedUtc { get; set; }
    }
}