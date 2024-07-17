using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entityoperation entity with essential details
    /// </summary>
    public class EntityOperation
    {
        /// <summary>
        /// Initializes a new instance of the EntityOperation class.
        /// </summary>
        public EntityOperation()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Entity to which the EntityOperation belongs 
        /// </summary>
        [Required]
        public Guid Entity { get; set; }

        /// <summary>
        /// Navigation property representing the associated Entity
        /// </summary>
        [ForeignKey("Entity")]
        public Entity? Entity_Entity { get; set; }

        /// <summary>
        /// Required field EntityCode of the EntityOperation 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the EntityOperation 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the EntityOperation 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the EntityOperation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the EntityOperation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the EntityOperation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EntityOperation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }
        /// <summary>
        /// Code of the EntityOperation 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the EntityOperation 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the EntityOperation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the EntityOperation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}