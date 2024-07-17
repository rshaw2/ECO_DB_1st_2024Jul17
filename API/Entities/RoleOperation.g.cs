using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a roleoperation entity with essential details
    /// </summary>
    public class RoleOperation
    {
        /// <summary>
        /// Required field IsStandard of the RoleOperation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the RoleOperation 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the RoleOperation 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the RoleOperation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the RoleOperation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the RoleOperation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the RoleOperation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Role to which the RoleOperation belongs 
        /// </summary>
        [Required]
        public Guid Role { get; set; }

        /// <summary>
        /// Navigation property representing the associated Role
        /// </summary>
        [ForeignKey("Role")]
        public Role? Role_Role { get; set; }
        /// <summary>
        /// Foreign key referencing the EntityOperation to which the RoleOperation belongs 
        /// </summary>
        public Guid? EntityOperation { get; set; }

        /// <summary>
        /// Navigation property representing the associated EntityOperation
        /// </summary>
        [ForeignKey("EntityOperation")]
        public EntityOperation? EntityOperation_EntityOperation { get; set; }
        /// <summary>
        /// Code of the RoleOperation 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the RoleOperation 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the RoleOperation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the RoleOperation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the RoleEntity to which the RoleOperation belongs 
        /// </summary>
        public Guid? RoleEntityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated RoleEntity
        /// </summary>
        [ForeignKey("RoleEntityId")]
        public RoleEntity? RoleEntityId_RoleEntity { get; set; }
    }
}