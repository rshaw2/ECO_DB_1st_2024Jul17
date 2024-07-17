using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a location entity with essential details
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Primary key for the Location 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Location belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Code of the Location 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Name of the Location 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field EmailAddress of the Location 
        /// </summary>
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Location belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Location 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the Location belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }

        /// <summary>
        /// Required field Enable of the Location 
        /// </summary>
        [Required]
        public bool Enable { get; set; }
        /// <summary>
        /// LocationRole of the Location 
        /// </summary>
        public byte? LocationRole { get; set; }
        /// <summary>
        /// ClinicTypeId of the Location 
        /// </summary>
        public Guid? ClinicTypeId { get; set; }
        /// <summary>
        /// PostalCode of the Location 
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Location belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Location 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DrugLicence of the Location 
        /// </summary>
        public string? DrugLicence { get; set; }
        /// <summary>
        /// FssaiNumber of the Location 
        /// </summary>
        public string? FssaiNumber { get; set; }
        /// <summary>
        /// TaxEnable of the Location 
        /// </summary>
        public bool? TaxEnable { get; set; }
        /// <summary>
        /// GstinNumber of the Location 
        /// </summary>
        public string? GstinNumber { get; set; }
        /// <summary>
        /// OpeningBalanceDone of the Location 
        /// </summary>
        public bool? OpeningBalanceDone { get; set; }
        /// <summary>
        /// AddressLine1 of the Location 
        /// </summary>
        public string? AddressLine1 { get; set; }
        /// <summary>
        /// AddressLine2 of the Location 
        /// </summary>
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// Foreign key referencing the State to which the Location belongs 
        /// </summary>
        public Guid? StateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated State
        /// </summary>
        [ForeignKey("StateId")]
        public State? StateId_State { get; set; }
        /// <summary>
        /// Foreign key referencing the City to which the Location belongs 
        /// </summary>
        public Guid? CityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated City
        /// </summary>
        [ForeignKey("CityId")]
        public City? CityId_City { get; set; }
        /// <summary>
        /// CountryCode of the Location 
        /// </summary>
        public short? CountryCode { get; set; }
        /// <summary>
        /// MobileNumber of the Location 
        /// </summary>
        public string? MobileNumber { get; set; }
    }
}