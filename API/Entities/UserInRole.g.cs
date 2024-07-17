using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a userinrole entity with essential details
    /// </summary>
    public class UserInRole
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the UserInRole belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the UserInRole 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserInRole belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Foreign key referencing the Role to which the UserInRole belongs 
        /// </summary>
        [Required]
        public Guid Role { get; set; }

        /// <summary>
        /// Navigation property representing the associated Role
        /// </summary>
        [ForeignKey("Role")]
        public Role? Role_Role { get; set; }
    }
}