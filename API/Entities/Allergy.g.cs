using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a allergy entity with essential details
    /// </summary>
    public class Allergy
    {
        /// <summary>
        /// Initializes a new instance of the Allergy class.
        /// </summary>
        public Allergy()
        {
            IsStandard = false;
            Favourite = false;
            NoKnownAllergy = false;
            IsDeleted = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Allergy belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Allergy 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the Allergy 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the Allergy 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Allergy 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the Allergy 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Allergy belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Allergy 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Allergy belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Allergy 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Allergy 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Allergy 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Allergy 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Favourite of the Allergy 
        /// </summary>
        public bool? Favourite { get; set; }
        /// <summary>
        /// NoKnownAllergy of the Allergy 
        /// </summary>
        public bool? NoKnownAllergy { get; set; }
        /// <summary>
        /// IsDeleted of the Allergy 
        /// </summary>
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// Foreign key referencing the AllergyTemplate to which the Allergy belongs 
        /// </summary>
        public Guid? AllergyTemplate { get; set; }

        /// <summary>
        /// Navigation property representing the associated AllergyTemplate
        /// </summary>
        [ForeignKey("AllergyTemplate")]
        public AllergyTemplate? AllergyTemplate_AllergyTemplate { get; set; }
    }
}