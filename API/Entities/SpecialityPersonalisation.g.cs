using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialitypersonalisation entity with essential details
    /// </summary>
    public class SpecialityPersonalisation
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SpecialityPersonalisation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SpecialityPersonalisation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Name of the SpecialityPersonalisation 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Enable of the SpecialityPersonalisation 
        /// </summary>
        [Required]
        public bool Enable { get; set; }

        /// <summary>
        /// Required field Default of the SpecialityPersonalisation 
        /// </summary>
        [Required]
        public bool Default { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the SpecialityPersonalisation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the SpecialityPersonalisation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the SpecialityPersonalisation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the SpecialityPersonalisation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
    }
}