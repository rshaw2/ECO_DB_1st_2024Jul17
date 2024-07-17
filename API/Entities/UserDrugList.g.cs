using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a userdruglist entity with essential details
    /// </summary>
    public class UserDrugList
    {
        /// <summary>
        /// Primary key for the UserDrugList 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the UserDrugList belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugList to which the UserDrugList belongs 
        /// </summary>
        [Required]
        public Guid DrugListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugList
        /// </summary>
        [ForeignKey("DrugListId")]
        public DrugList? DrugListId_DrugList { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the UserDrugList belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}