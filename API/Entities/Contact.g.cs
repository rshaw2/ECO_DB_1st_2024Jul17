using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contact entity with essential details
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Required field FirstName of the Contact 
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Contact belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Contact 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Primary key for the Contact 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Contact belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field ContactRole of the Contact 
        /// </summary>
        [Required]
        public byte ContactRole { get; set; }

        /// <summary>
        /// Required field ContactType of the Contact 
        /// </summary>
        [Required]
        public byte ContactType { get; set; }
        /// <summary>
        /// Foreign key referencing the Title to which the Contact belongs 
        /// </summary>
        public Guid? TitleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Title
        /// </summary>
        [ForeignKey("TitleId")]
        public Title? TitleId_Title { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Contact belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Contact 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Contact 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the Contact belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
        /// <summary>
        /// Name of the Contact 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// RepeatVisitSpan of the Contact 
        /// </summary>
        public short? RepeatVisitSpan { get; set; }
        /// <summary>
        /// BusinessRegistrationNumber of the Contact 
        /// </summary>
        public string? BusinessRegistrationNumber { get; set; }
        /// <summary>
        /// LabType of the Contact 
        /// </summary>
        public byte? LabType { get; set; }
        /// <summary>
        /// JobTitle of the Contact 
        /// </summary>
        public string? JobTitle { get; set; }
        /// <summary>
        /// CountryCode of the Contact 
        /// </summary>
        public short? CountryCode { get; set; }
        /// <summary>
        /// Mobile of the Contact 
        /// </summary>
        public string? Mobile { get; set; }
        /// <summary>
        /// Email of the Contact 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Foreign key referencing the Speciality to which the Contact belongs 
        /// </summary>
        public Guid? SpecialityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Speciality
        /// </summary>
        [ForeignKey("SpecialityId")]
        public Speciality? SpecialityId_Speciality { get; set; }
        /// <summary>
        /// Notes of the Contact 
        /// </summary>
        public string? Notes { get; set; }
        /// <summary>
        /// AddressLine1 of the Contact 
        /// </summary>
        public string? AddressLine1 { get; set; }
        /// <summary>
        /// AddressLine2 of the Contact 
        /// </summary>
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// Foreign key referencing the State to which the Contact belongs 
        /// </summary>
        public Guid? StateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated State
        /// </summary>
        [ForeignKey("StateId")]
        public State? StateId_State { get; set; }
        /// <summary>
        /// Foreign key referencing the City to which the Contact belongs 
        /// </summary>
        public Guid? CityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated City
        /// </summary>
        [ForeignKey("CityId")]
        public City? CityId_City { get; set; }
        /// <summary>
        /// Foreign key referencing the Country to which the Contact belongs 
        /// </summary>
        public Guid? CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }
        /// <summary>
        /// PostalCode of the Contact 
        /// </summary>
        public string? PostalCode { get; set; }
    }
}