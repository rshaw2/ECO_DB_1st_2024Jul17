using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a roleentity entity with essential details
    /// </summary>
    public class RoleEntity
    {
        /// <summary>
        /// Initializes a new instance of the RoleEntity class.
        /// </summary>
        public RoleEntity()
        {
            Allowed = false;
            Visible = false;
        }

        /// <summary>
        /// Primary key for the RoleEntity 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the RoleEntity belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Entity to which the RoleEntity belongs 
        /// </summary>
        [Required]
        public Guid EntityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Entity
        /// </summary>
        [ForeignKey("EntityId")]
        public Entity? EntityId_Entity { get; set; }

        /// <summary>
        /// Required field Allowed of the RoleEntity 
        /// </summary>
        [Required]
        public bool Allowed { get; set; }

        /// <summary>
        /// Foreign key referencing the Role to which the RoleEntity belongs 
        /// </summary>
        [Required]
        public Guid RoleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Role
        /// </summary>
        [ForeignKey("RoleId")]
        public Role? RoleId_Role { get; set; }

        /// <summary>
        /// Required field Visible of the RoleEntity 
        /// </summary>
        [Required]
        public bool Visible { get; set; }
        /// <summary>
        /// Foreign key referencing the PackageLine to which the RoleEntity belongs 
        /// </summary>
        public Guid? PackageLineId { get; set; }

        /// <summary>
        /// Navigation property representing the associated PackageLine
        /// </summary>
        [ForeignKey("PackageLineId")]
        public PackageLine? PackageLineId_PackageLine { get; set; }
        /// <summary>
        /// Name of the RoleEntity 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Code of the RoleEntity 
        /// </summary>
        public string? Code { get; set; }
    }
}