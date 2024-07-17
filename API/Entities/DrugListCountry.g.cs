using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a druglistcountry entity with essential details
    /// </summary>
    public class DrugListCountry
    {
        /// <summary>
        /// Primary key for the DrugListCountry 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DrugListCountry belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the DrugListCountry belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }

        /// <summary>
        /// Foreign key referencing the DrugList to which the DrugListCountry belongs 
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