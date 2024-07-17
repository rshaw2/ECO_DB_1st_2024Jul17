using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a uom entity with essential details
    /// </summary>
    public class UOM
    {
        /// <summary>
        /// Required field EntityCode of the UOM 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the UOM 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the UOM 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UOM belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the UOM 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field IsStandard of the UOM 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UOM belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the UOM 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the UOM belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the UOM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ParentId of the UOM 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Abbreviation of the UOM 
        /// </summary>
        public string? Abbreviation { get; set; }
        /// <summary>
        /// IsDefault of the UOM 
        /// </summary>
        public bool? IsDefault { get; set; }
        /// <summary>
        /// UnitCategory of the UOM 
        /// </summary>
        public Guid? UnitCategory { get; set; }
        /// <summary>
        /// UnitTypeId of the UOM 
        /// </summary>
        public Guid? UnitTypeId { get; set; }
        /// <summary>
        /// SupportDecimal of the UOM 
        /// </summary>
        public bool? SupportDecimal { get; set; }
        /// <summary>
        /// Active of the UOM 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Code of the UOM 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the UOM 
        /// </summary>
        public string? Name { get; set; }
    }
}