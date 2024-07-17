using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a druglistspeciality entity with essential details
    /// </summary>
    public class DrugListSpeciality
    {
        /// <summary>
        /// Primary key for the DrugListSpeciality 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugListSpeciality belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Speciality to which the DrugListSpeciality belongs 
        /// </summary>
        [Required]
        public Guid SpecialityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Speciality
        /// </summary>
        [ForeignKey("SpecialityId")]
        public Speciality? SpecialityId_Speciality { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugList to which the DrugListSpeciality belongs 
        /// </summary>
        [Required]
        public Guid DrugListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugList
        /// </summary>
        [ForeignKey("DrugListId")]
        public DrugList? DrugListId_DrugList { get; set; }
    }
}