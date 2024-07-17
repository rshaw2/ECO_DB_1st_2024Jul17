using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a credential entity with essential details
    /// </summary>
    public class Credential
    {
        /// <summary>
        /// Initializes a new instance of the Credential class.
        /// </summary>
        public Credential()
        {
            SystemGeneratedPassword = false;
        }

        /// <summary>
        /// Required field UserName of the Credential 
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Primary key for the Credential 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// User of the Credential 
        /// </summary>
        public Guid? User { get; set; }
        /// <summary>
        /// PasswordHash of the Credential 
        /// </summary>
        public string? PasswordHash { get; set; }
        /// <summary>
        /// PasswordSalt of the Credential 
        /// </summary>
        public string? PasswordSalt { get; set; }

        /// <summary>
        /// PasswordChangedOn of the Credential 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PasswordChangedOn { get; set; }
        /// <summary>
        /// UsernameMobile of the Credential 
        /// </summary>
        public string? UsernameMobile { get; set; }
        /// <summary>
        /// UsernameEmail of the Credential 
        /// </summary>
        public string? UsernameEmail { get; set; }
        /// <summary>
        /// AdminUser of the Credential 
        /// </summary>
        public bool? AdminUser { get; set; }
        /// <summary>
        /// SystemGeneratedPassword of the Credential 
        /// </summary>
        public bool? SystemGeneratedPassword { get; set; }
        /// <summary>
        /// GoogleAuthenticatedUser of the Credential 
        /// </summary>
        public bool? GoogleAuthenticatedUser { get; set; }
        /// <summary>
        /// OtherHashedPassword of the Credential 
        /// </summary>
        public string? OtherHashedPassword { get; set; }
    }
}