using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a address entity with essential details
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the Address belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Address 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// AddressLine1 of the Address 
        /// </summary>
        public string? AddressLine1 { get; set; }
        /// <summary>
        /// AddressLine2 of the Address 
        /// </summary>
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// AddressLine3 of the Address 
        /// </summary>
        public string? AddressLine3 { get; set; }
        /// <summary>
        /// CareOf of the Address 
        /// </summary>
        public string? CareOf { get; set; }
        /// <summary>
        /// POBox of the Address 
        /// </summary>
        public string? POBox { get; set; }
        /// <summary>
        /// CountryId of the Address 
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// CityId of the Address 
        /// </summary>
        public Guid? CityId { get; set; }
        /// <summary>
        /// MunicipalityId of the Address 
        /// </summary>
        public Guid? MunicipalityId { get; set; }
        /// <summary>
        /// StateId of the Address 
        /// </summary>
        public Guid? StateId { get; set; }
        /// <summary>
        /// PostalCode of the Address 
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// AddressLine4 of the Address 
        /// </summary>
        public string? AddressLine4 { get; set; }
    }
}