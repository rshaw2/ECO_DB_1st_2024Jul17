using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a informationobjectfields entity with essential details
    /// </summary>
    public class InformationObjectFields
    {
        /// <summary>
        /// Primary key for the InformationObjectFields 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the InformationObjectFields belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the InformationObjects to which the InformationObjectFields belongs 
        /// </summary>
        [Required]
        public Guid InformationObjectId { get; set; }

        /// <summary>
        /// Navigation property representing the associated InformationObjects
        /// </summary>
        [ForeignKey("InformationObjectId")]
        public InformationObjects? InformationObjectId_InformationObjects { get; set; }

        /// <summary>
        /// Required field Name of the InformationObjectFields 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field PrimaryKey of the InformationObjectFields 
        /// </summary>
        [Required]
        public bool PrimaryKey { get; set; }

        /// <summary>
        /// Required field Size of the InformationObjectFields 
        /// </summary>
        [Required]
        public int Size { get; set; }

        /// <summary>
        /// Required field Code of the InformationObjectFields 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field DatabaseColumn of the InformationObjectFields 
        /// </summary>
        [Required]
        public string DatabaseColumn { get; set; }

        /// <summary>
        /// Required field DataType of the InformationObjectFields 
        /// </summary>
        [Required]
        public byte DataType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the InformationObjectFields belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the InformationObjectFields 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the InformationObjectFields belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the InformationObjectFields 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// RelatedInformationObjectId of the InformationObjectFields 
        /// </summary>
        public Guid? RelatedInformationObjectId { get; set; }
        /// <summary>
        /// RelatedInformationField of the InformationObjectFields 
        /// </summary>
        public string? RelatedInformationField { get; set; }
    }
}