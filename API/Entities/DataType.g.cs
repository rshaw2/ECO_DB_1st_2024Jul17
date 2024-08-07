using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a datatype entity with essential details
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// Initializes a new instance of the DataType class.
        /// </summary>
        public DataType()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DataType belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DataType 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the DataType 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Required field EntityCode of the DataType 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the DataType 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DataType belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DataType 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the DataType 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the DataType 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DataType belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DataType 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the DataType 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the DataType 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the DataType 
        /// </summary>
        public Guid? Active { get; set; }
    }
}