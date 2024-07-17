using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a userroster entity with essential details
    /// </summary>
    public class UserRoster
    {
        /// <summary>
        /// Primary key for the UserRoster 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UserRoster belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserRoster belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Required field FromTime of the UserRoster 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime FromTime { get; set; }

        /// <summary>
        /// Required field ToTime of the UserRoster 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ToTime { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserRoster belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the UserRoster 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the UserRoster belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the UserRoster 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// LocationId of the UserRoster 
        /// </summary>
        public Guid? LocationId { get; set; }
        /// <summary>
        /// Sunday of the UserRoster 
        /// </summary>
        public bool? Sunday { get; set; }
        /// <summary>
        /// Monday of the UserRoster 
        /// </summary>
        public bool? Monday { get; set; }
        /// <summary>
        /// Tuesday of the UserRoster 
        /// </summary>
        public bool? Tuesday { get; set; }
        /// <summary>
        /// Wednesday of the UserRoster 
        /// </summary>
        public bool? Wednesday { get; set; }
        /// <summary>
        /// Thursday of the UserRoster 
        /// </summary>
        public bool? Thursday { get; set; }
        /// <summary>
        /// Friday of the UserRoster 
        /// </summary>
        public bool? Friday { get; set; }
        /// <summary>
        /// Saturday of the UserRoster 
        /// </summary>
        public bool? Saturday { get; set; }
    }
}