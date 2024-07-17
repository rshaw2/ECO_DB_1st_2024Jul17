using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a specialitypersonalisationallergy entity with essential details
    /// </summary>
    public class SpecialityPersonalisationAllergy
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the SpecialityPersonalisationAllergy belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the SpecialityPersonalisationAllergy 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the SpecialityPersonalisation to which the SpecialityPersonalisationAllergy belongs 
        /// </summary>
        [Required]
        public Guid SpecialityPersonalisationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SpecialityPersonalisation
        /// </summary>
        [ForeignKey("SpecialityPersonalisationId")]
        public SpecialityPersonalisation? SpecialityPersonalisationId_SpecialityPersonalisation { get; set; }

        /// <summary>
        /// Foreign key referencing the Allergy to which the SpecialityPersonalisationAllergy belongs 
        /// </summary>
        [Required]
        public Guid AllergyId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Allergy
        /// </summary>
        [ForeignKey("AllergyId")]
        public Allergy? AllergyId_Allergy { get; set; }
    }
}