using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user entity with essential details
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User()
        {
            IsStandard = false;
            Disabled = false;
            Gender = new Guid("00000000-0000-0000-0000-000000000000");
            Deleted = false;
            UserType = 1;
            BankDetailCompleted = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the User belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the User 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("Id")]
        public User? Id_User { get; set; }

        /// <summary>
        /// Required field CreatedBy of the User 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Required field CreatedOn of the User 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the User 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field EntityCode of the User 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the User 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Disabled of the User 
        /// </summary>
        [Required]
        public bool Disabled { get; set; }
        /// <summary>
        /// Code of the User 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the User 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// UpdatedBy of the User 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// UpdatedOn of the User 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Gender of the User 
        /// </summary>
        public Guid? Gender { get; set; }
        /// <summary>
        /// MedicalRegistrationNumber of the User 
        /// </summary>
        public string? MedicalRegistrationNumber { get; set; }
        /// <summary>
        /// Qualifications of the User 
        /// </summary>
        public string? Qualifications { get; set; }
        /// <summary>
        /// Specialisations of the User 
        /// </summary>
        public string? Specialisations { get; set; }
        /// <summary>
        /// ProfessionalMemberships of the User 
        /// </summary>
        public string? ProfessionalMemberships { get; set; }
        /// <summary>
        /// CommunicationVerificationId of the User 
        /// </summary>
        public Guid? CommunicationVerificationId { get; set; }
        /// <summary>
        /// AgeUnit of the User 
        /// </summary>
        public Guid? AgeUnit { get; set; }
        /// <summary>
        /// Age of the User 
        /// </summary>
        public int? Age { get; set; }
        /// <summary>
        /// Deleted of the User 
        /// </summary>
        public bool? Deleted { get; set; }
        /// <summary>
        /// UserType of the User 
        /// </summary>
        public byte? UserType { get; set; }
        /// <summary>
        /// BankDetailCompleted of the User 
        /// </summary>
        public bool? BankDetailCompleted { get; set; }
        /// <summary>
        /// Foreign key referencing the Speciality to which the User belongs 
        /// </summary>
        public Guid? Speciality { get; set; }

        /// <summary>
        /// Navigation property representing the associated Speciality
        /// </summary>
        [ForeignKey("Speciality")]
        public Speciality? Speciality_Speciality { get; set; }
        /// <summary>
        /// CalendarSync of the User 
        /// </summary>
        public bool? CalendarSync { get; set; }
        /// <summary>
        /// StaffCode of the User 
        /// </summary>
        public string? StaffCode { get; set; }
        /// <summary>
        /// ZohoLeadId of the User 
        /// </summary>
        public string? ZohoLeadId { get; set; }
        /// <summary>
        /// AuthorizationCode of the User 
        /// </summary>
        public string? AuthorizationCode { get; set; }
        /// <summary>
        /// Foreign key referencing the Title to which the User belongs 
        /// </summary>
        public Guid? TitleId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Title
        /// </summary>
        [ForeignKey("TitleId")]
        public Title? TitleId_Title { get; set; }
        /// <summary>
        /// FirstName of the User 
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// MiddleName of the User 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// LastName of the User 
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// ContactInformationId of the User 
        /// </summary>
        public Guid? ContactInformationId { get; set; }
        /// <summary>
        /// OfficialAddressId of the User 
        /// </summary>
        public Guid? OfficialAddressId { get; set; }
        /// <summary>
        /// InvoiceAddressId of the User 
        /// </summary>
        public Guid? InvoiceAddressId { get; set; }
        /// <summary>
        /// PostalAddressId of the User 
        /// </summary>
        public Guid? PostalAddressId { get; set; }
        /// <summary>
        /// AvatarId of the User 
        /// </summary>
        public Guid? AvatarId { get; set; }
        /// <summary>
        /// TimezoneId of the User 
        /// </summary>
        public Guid? TimezoneId { get; set; }
        /// <summary>
        /// Foreign key referencing the Language to which the User belongs 
        /// </summary>
        public Guid? PreferredLanguageId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Language
        /// </summary>
        [ForeignKey("PreferredLanguageId")]
        public Language? PreferredLanguageId_Language { get; set; }

        /// <summary>
        /// DOB of the User 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DOB { get; set; }
        /// <summary>
        /// DOBIsApproximate of the User 
        /// </summary>
        public bool? DOBIsApproximate { get; set; }
        /// <summary>
        /// NationalityId of the User 
        /// </summary>
        public Guid? NationalityId { get; set; }
        /// <summary>
        /// UserCredentialId of the User 
        /// </summary>
        public Guid? UserCredentialId { get; set; }
    }
}