using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a druglistitems entity with essential details
    /// </summary>
    public class DrugListItems
    {
        /// <summary>
        /// Primary key for the DrugListItems 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugListItems belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugList to which the DrugListItems belongs 
        /// </summary>
        [Required]
        public Guid DrugListId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugList
        /// </summary>
        [ForeignKey("DrugListId")]
        public DrugList? DrugListId_DrugList { get; set; }

        /// <summary>
        /// Required field MedicationId of the DrugListItems 
        /// </summary>
        [Required]
        public Guid MedicationId { get; set; }
    }
}