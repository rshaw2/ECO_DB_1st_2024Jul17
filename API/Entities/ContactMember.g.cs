using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contactmember entity with essential details
    /// </summary>
    public class ContactMember
    {
        /// <summary>
        /// Required field LastName of the ContactMember 
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Required field Name of the ContactMember 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Foreign key referencing the Gender to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid GenderId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Gender
        /// </summary>
        [ForeignKey("GenderId")]
        public Gender? GenderId_Gender { get; set; }

        /// <summary>
        /// Required field Dob of the ContactMember 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Dob { get; set; }

        /// <summary>
        /// Required field Age of the ContactMember 
        /// </summary>
        [Required]
        public decimal Age { get; set; }

        /// <summary>
        /// Required field DobIsApproximate of the ContactMember 
        /// </summary>
        [Required]
        public bool DobIsApproximate { get; set; }

        /// <summary>
        /// Foreign key referencing the AgeUnit to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid AgeUnitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated AgeUnit
        /// </summary>
        [ForeignKey("AgeUnitId")]
        public AgeUnit? AgeUnitId_AgeUnit { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ContactMember 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Contact to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid ContactId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ContactId")]
        public Contact? ContactId_Contact { get; set; }

        /// <summary>
        /// Foreign key referencing the CoverCategory to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid CoverCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated CoverCategory
        /// </summary>
        [ForeignKey("CoverCategoryId")]
        public CoverCategory? CoverCategoryId_CoverCategory { get; set; }

        /// <summary>
        /// Required field MobileNumberCountryCode of the ContactMember 
        /// </summary>
        [Required]
        public short MobileNumberCountryCode { get; set; }

        /// <summary>
        /// Required field Mobile of the ContactMember 
        /// </summary>
        [Required]
        public string Mobile { get; set; }

        /// <summary>
        /// Required field MembershipNumber of the ContactMember 
        /// </summary>
        [Required]
        public string MembershipNumber { get; set; }

        /// <summary>
        /// Required field MembershipExpiryDate of the ContactMember 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime MembershipExpiryDate { get; set; }

        /// <summary>
        /// Foreign key referencing the State to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid StateId { get; set; }

        /// <summary>
        /// Navigation property representing the associated State
        /// </summary>
        [ForeignKey("StateId")]
        public State? StateId_State { get; set; }

        /// <summary>
        /// Foreign key referencing the City to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid CityId { get; set; }

        /// <summary>
        /// Navigation property representing the associated City
        /// </summary>
        [ForeignKey("CityId")]
        public City? CityId_City { get; set; }

        /// <summary>
        /// Foreign key referencing the Country to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid CountryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Country
        /// </summary>
        [ForeignKey("CountryId")]
        public Country? CountryId_Country { get; set; }

        /// <summary>
        /// Required field FirstName of the ContactMember 
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ContactMember belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ContactMember 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ContactMember belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ContactMember 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the SubscriptionCategory to which the ContactMember belongs 
        /// </summary>
        public Guid? SubscriptionCategoryId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubscriptionCategory
        /// </summary>
        [ForeignKey("SubscriptionCategoryId")]
        public SubscriptionCategory? SubscriptionCategoryId_SubscriptionCategory { get; set; }
        /// <summary>
        /// MiddleName of the ContactMember 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// PostalCode of the ContactMember 
        /// </summary>
        public string? PostalCode { get; set; }
        /// <summary>
        /// Foreign key referencing the NationalIdType to which the ContactMember belongs 
        /// </summary>
        public Guid? NationalTypeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated NationalIdType
        /// </summary>
        [ForeignKey("NationalTypeId")]
        public NationalIdType? NationalTypeId_NationalIdType { get; set; }
        /// <summary>
        /// NationalIdNumber of the ContactMember 
        /// </summary>
        public string? NationalIdNumber { get; set; }
        /// <summary>
        /// IsDisabled of the ContactMember 
        /// </summary>
        public bool? IsDisabled { get; set; }
        /// <summary>
        /// IsDependent of the ContactMember 
        /// </summary>
        public bool? IsDependent { get; set; }
        /// <summary>
        /// PrincipalMemberName of the ContactMember 
        /// </summary>
        public string? PrincipalMemberName { get; set; }
        /// <summary>
        /// PrincipalMembershipNumber of the ContactMember 
        /// </summary>
        public string? PrincipalMembershipNumber { get; set; }
        /// <summary>
        /// AddressLine1 of the ContactMember 
        /// </summary>
        public string? AddressLine1 { get; set; }
        /// <summary>
        /// AddressLine2 of the ContactMember 
        /// </summary>
        public string? AddressLine2 { get; set; }
        /// <summary>
        /// AlternateNumberCountryCode of the ContactMember 
        /// </summary>
        public short? AlternateNumberCountryCode { get; set; }
        /// <summary>
        /// AlternateMobile of the ContactMember 
        /// </summary>
        public string? AlternateMobile { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the ContactMember belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the Title to which the ContactMember belongs 
        /// </summary>
        public Guid? TitleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Title
        /// </summary>
        [ForeignKey("TitleId")]
        public Title? TitleId_Title { get; set; }
        /// <summary>
        /// Email of the ContactMember 
        /// </summary>
        public string? Email { get; set; }
    }
}