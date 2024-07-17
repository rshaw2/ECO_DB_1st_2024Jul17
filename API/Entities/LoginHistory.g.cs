using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a loginhistory entity with essential details
    /// </summary>
    public class LoginHistory
    {
        /// <summary>
        /// Initializes a new instance of the LoginHistory class.
        /// </summary>
        public LoginHistory()
        {
            LoginSuccessful = false;
        }

        /// <summary>
        /// Primary key for the LoginHistory 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field UserLoginId of the LoginHistory 
        /// </summary>
        [Required]
        public string UserLoginId { get; set; }

        /// <summary>
        /// Required field LoginDate of the LoginHistory 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// Required field LoginSuccessful of the LoginHistory 
        /// </summary>
        [Required]
        public bool LoginSuccessful { get; set; }

        /// <summary>
        /// LogoutTime of the LoginHistory 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LogoutTime { get; set; }
        /// <summary>
        /// Country of the LoginHistory 
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// Region of the LoginHistory 
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Isp of the LoginHistory 
        /// </summary>
        public string? Isp { get; set; }
        /// <summary>
        /// SecretKey of the LoginHistory 
        /// </summary>
        public string? SecretKey { get; set; }
        /// <summary>
        /// IpAddress of the LoginHistory 
        /// </summary>
        public string? IpAddress { get; set; }
        /// <summary>
        /// Foreign key referencing the Tenant to which the LoginHistory belongs 
        /// </summary>
        public Guid? Tenantid { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("Tenantid")]
        public Tenant? Tenantid_Tenant { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the LoginHistory belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}