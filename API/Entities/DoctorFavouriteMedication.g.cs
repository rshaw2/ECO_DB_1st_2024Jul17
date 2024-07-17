using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a doctorfavouritemedication entity with essential details
    /// </summary>
    public class DoctorFavouriteMedication
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the DoctorFavouriteMedication belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DoctorFavouriteMedication 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Medication to which the DoctorFavouriteMedication belongs 
        /// </summary>
        [Required]
        public Guid Medication { get; set; }

        /// <summary>
        /// Navigation property representing the associated Medication
        /// </summary>
        [ForeignKey("Medication")]
        public Medication? Medication_Medication { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DoctorFavouriteMedication belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }
    }
}