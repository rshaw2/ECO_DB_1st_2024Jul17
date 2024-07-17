using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organizationsettings entity with essential details
    /// </summary>
    public class OrganizationSettings
    {
        /// <summary>
        /// Initializes a new instance of the OrganizationSettings class.
        /// </summary>
        public OrganizationSettings()
        {
            SubLocationRequired = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the OrganizationSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the OrganizationSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field OrganizationLegalName of the OrganizationSettings 
        /// </summary>
        [Required]
        public string OrganizationLegalName { get; set; }

        /// <summary>
        /// Required field OrganizationType of the OrganizationSettings 
        /// </summary>
        [Required]
        public byte OrganizationType { get; set; }

        /// <summary>
        /// Required field AdressLine1 of the OrganizationSettings 
        /// </summary>
        [Required]
        public string AdressLine1 { get; set; }

        /// <summary>
        /// Foreign key referencing the State to which the OrganizationSettings belongs 
        /// </summary>
        [Required]
        public Guid StateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated State
        /// </summary>
        [ForeignKey("StateId")]
        public State? StateId_State { get; set; }

        /// <summary>
        /// Foreign key referencing the City to which the OrganizationSettings belongs 
        /// </summary>
        [Required]
        public Guid CityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated City
        /// </summary>
        [ForeignKey("CityId")]
        public City? CityId_City { get; set; }

        /// <summary>
        /// Required field PinCode of the OrganizationSettings 
        /// </summary>
        [Required]
        public string PinCode { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the OrganizationSettings belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the OrganizationSettings belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the OrganizationSettings 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field SubLocationRequired of the OrganizationSettings 
        /// </summary>
        [Required]
        public bool SubLocationRequired { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the OrganizationSettings belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the OrganizationSettings 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// TaxEnable of the OrganizationSettings 
        /// </summary>
        public bool? TaxEnable { get; set; }
        /// <summary>
        /// GstinNumber of the OrganizationSettings 
        /// </summary>
        public string? GstinNumber { get; set; }
        /// <summary>
        /// CinNumber of the OrganizationSettings 
        /// </summary>
        public string? CinNumber { get; set; }
        /// <summary>
        /// LlpinNumber of the OrganizationSettings 
        /// </summary>
        public string? LlpinNumber { get; set; }
        /// <summary>
        /// PanNumber of the OrganizationSettings 
        /// </summary>
        public string? PanNumber { get; set; }
        /// <summary>
        /// AdressLine2 of the OrganizationSettings 
        /// </summary>
        public string? AdressLine2 { get; set; }
    }
}