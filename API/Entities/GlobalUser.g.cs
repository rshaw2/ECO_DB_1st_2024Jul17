using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a globaluser entity with essential details
    /// </summary>
    public class GlobalUser
    {
        /// <summary>
        /// Initializes a new instance of the GlobalUser class.
        /// </summary>
        public GlobalUser()
        {
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the GlobalUser belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the GlobalUser 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field UserId of the GlobalUser 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Required field Email of the GlobalUser 
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Required field Phone of the GlobalUser 
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// Required field PasswordHash of the GlobalUser 
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Required field PasswordSalt of the GlobalUser 
        /// </summary>
        [Required]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Required field EntityCode of the GlobalUser 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the GlobalUser 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the GlobalUser 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the GlobalUser belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the GlobalUser 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the GlobalUser 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the GlobalUser 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the GlobalUser belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the GlobalUser 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the GlobalUser 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the GlobalUser 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the GlobalUser 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Default of the GlobalUser 
        /// </summary>
        public bool? Default { get; set; }
        /// <summary>
        /// PasswordResetReasonId of the GlobalUser 
        /// </summary>
        public Guid? PasswordResetReasonId { get; set; }

        /// <summary>
        /// Dob of the GlobalUser 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? Dob { get; set; }
    }
}