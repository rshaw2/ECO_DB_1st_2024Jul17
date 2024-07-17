using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjects entity with essential details
    /// </summary>
    public class InformationObjects
    {
        /// <summary>
        /// Primary key for the InformationObjects 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjects belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Name of the InformationObjects 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field PluralName of the InformationObjects 
        /// </summary>
        [Required]
        public string PluralName { get; set; }

        /// <summary>
        /// Required field Code of the InformationObjects 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field TableName of the InformationObjects 
        /// </summary>
        [Required]
        public string TableName { get; set; }

        /// <summary>
        /// Required field Schema of the InformationObjects 
        /// </summary>
        [Required]
        public string Schema { get; set; }

        /// <summary>
        /// Required field WorkFlowEnable of the InformationObjects 
        /// </summary>
        [Required]
        public bool WorkFlowEnable { get; set; }

        /// <summary>
        /// Required field Published of the InformationObjects 
        /// </summary>
        [Required]
        public bool Published { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InformationObjects belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InformationObjects 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InformationObjects belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InformationObjects 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Description of the InformationObjects 
        /// </summary>
        public string? Description { get; set; }
    }
}