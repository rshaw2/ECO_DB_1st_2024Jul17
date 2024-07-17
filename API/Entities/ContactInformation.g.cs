using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contactinformation entity with essential details
    /// </summary>
    public class ContactInformation
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the ContactInformation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ContactInformation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// PersonalPhone1 of the ContactInformation 
        /// </summary>
        public string? PersonalPhone1 { get; set; }
        /// <summary>
        /// PersonalPhone2 of the ContactInformation 
        /// </summary>
        public string? PersonalPhone2 { get; set; }
        /// <summary>
        /// PersonalMobile1 of the ContactInformation 
        /// </summary>
        public string? PersonalMobile1 { get; set; }
        /// <summary>
        /// PersonalEmail1 of the ContactInformation 
        /// </summary>
        public string? PersonalEmail1 { get; set; }
        /// <summary>
        /// PersonalEmail2 of the ContactInformation 
        /// </summary>
        public string? PersonalEmail2 { get; set; }
        /// <summary>
        /// WorkPhone1 of the ContactInformation 
        /// </summary>
        public string? WorkPhone1 { get; set; }
        /// <summary>
        /// WorkPhone2 of the ContactInformation 
        /// </summary>
        public string? WorkPhone2 { get; set; }
        /// <summary>
        /// WorkPhoneExtension of the ContactInformation 
        /// </summary>
        public string? WorkPhoneExtension { get; set; }
        /// <summary>
        /// WorkMobile1 of the ContactInformation 
        /// </summary>
        public string? WorkMobile1 { get; set; }
        /// <summary>
        /// WorkFax1 of the ContactInformation 
        /// </summary>
        public string? WorkFax1 { get; set; }
        /// <summary>
        /// WorkEmail1 of the ContactInformation 
        /// </summary>
        public string? WorkEmail1 { get; set; }
        /// <summary>
        /// MobileNumberCountryCode of the ContactInformation 
        /// </summary>
        public short? MobileNumberCountryCode { get; set; }
    }
}