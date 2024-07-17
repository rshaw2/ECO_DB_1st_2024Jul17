using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a lifestylechoice entity with essential details
    /// </summary>
    public class LifeStyleChoice
    {
        /// <summary>
        /// Initializes a new instance of the LifeStyleChoice class.
        /// </summary>
        public LifeStyleChoice()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the LifeStyleChoice belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the LifeStyleChoice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the LifeStyleChoice 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the Lifestyle to which the LifeStyleChoice belongs 
        /// </summary>
        [Required]
        public Guid Lifestyle { get; set; }

        /// <summary>
        /// Navigation property representing the associated Lifestyle
        /// </summary>
        [ForeignKey("Lifestyle")]
        public Lifestyle? Lifestyle_Lifestyle { get; set; }

        /// <summary>
        /// Required field EntityCode of the LifeStyleChoice 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the LifeStyleChoice 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the LifeStyleChoice 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the LifeStyleChoice belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the LifeStyleChoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the LifeStyleChoice belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the LifeStyleChoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the LifeStyleChoice 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the LifeStyleChoice 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the LifeStyleChoice 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// LifeStyleChoiceTemplate of the LifeStyleChoice 
        /// </summary>
        public Guid? LifeStyleChoiceTemplate { get; set; }
    }
}