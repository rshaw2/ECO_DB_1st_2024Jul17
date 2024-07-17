using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a uomconversion entity with essential details
    /// </summary>
    public class UOMConversion
    {
        /// <summary>
        /// Initializes a new instance of the UOMConversion class.
        /// </summary>
        public UOMConversion()
        {
            Active = new Guid("00000000-0000-0000-0000-000000000000");
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UOMConversion belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the UOMConversion 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the UOMConversion 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the UOMConversion 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the UOM to which the UOMConversion belongs 
        /// </summary>
        [Required]
        public Guid FromUnitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("FromUnitId")]
        public UOM? FromUnitId_UOM { get; set; }

        /// <summary>
        /// Foreign key referencing the UOM to which the UOMConversion belongs 
        /// </summary>
        [Required]
        public Guid ToUnitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("ToUnitId")]
        public UOM? ToUnitId_UOM { get; set; }

        /// <summary>
        /// Required field Factor1 of the UOMConversion 
        /// </summary>
        [Required]
        public decimal Factor1 { get; set; }

        /// <summary>
        /// Required field Factor2 of the UOMConversion 
        /// </summary>
        [Required]
        public decimal Factor2 { get; set; }

        /// <summary>
        /// Required field Active of the UOMConversion 
        /// </summary>
        [Required]
        public Guid Active { get; set; }

        /// <summary>
        /// Required field IsStandard of the UOMConversion 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UOMConversion belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the UOMConversion 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the UOMConversion belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the UOMConversion 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ParentId of the UOMConversion 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the UOMConversion 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the UOMConversion 
        /// </summary>
        public string? Name { get; set; }
    }
}