using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a patient entity with essential details
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Initializes a new instance of the Patient class.
        /// </summary>
        public Patient()
        {
            Flagged = false;
            IsStandard = false;
            IsDeceased = false;
            IsDisabled = false;
        }

        /// <summary>
        /// Required field Gender of the Patient 
        /// </summary>
        [Required]
        public Guid Gender { get; set; }

        /// <summary>
        /// Required field Dob of the Patient 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Dob { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Patient belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Patient 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Patient 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Patient 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the Patient 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Patient belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Patient 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field FirstName of the Patient 
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Required field IsStandard of the Patient 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Patient 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// LastName of the Patient 
        /// </summary>
        public string? LastName { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Patient belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MiddleName of the Patient 
        /// </summary>
        public string? MiddleName { get; set; }
        /// <summary>
        /// AgeUnit of the Patient 
        /// </summary>
        public Guid? AgeUnit { get; set; }

        /// <summary>
        /// DateOfDeath of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateOfDeath { get; set; }
        /// <summary>
        /// ReasonOfDeath of the Patient 
        /// </summary>
        public string? ReasonOfDeath { get; set; }
        /// <summary>
        /// IsDeceased of the Patient 
        /// </summary>
        public bool? IsDeceased { get; set; }
        /// <summary>
        /// Mobile of the Patient 
        /// </summary>
        public string? Mobile { get; set; }
        /// <summary>
        /// Email of the Patient 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// BloodGroup of the Patient 
        /// </summary>
        public string? BloodGroup { get; set; }
        /// <summary>
        /// FileNumber of the Patient 
        /// </summary>
        public string? FileNumber { get; set; }
        /// <summary>
        /// AlternateMobile of the Patient 
        /// </summary>
        public string? AlternateMobile { get; set; }
        /// <summary>
        /// IsDisabled of the Patient 
        /// </summary>
        public bool? IsDisabled { get; set; }
        /// <summary>
        /// Foreign key referencing the Contact to which the Patient belongs 
        /// </summary>
        public Guid? ReferredById { get; set; }

        /// <summary>
        /// Navigation property representing the associated Contact
        /// </summary>
        [ForeignKey("ReferredById")]
        public Contact? ReferredById_Contact { get; set; }
        /// <summary>
        /// MobileNumberCountryCode of the Patient 
        /// </summary>
        public short? MobileNumberCountryCode { get; set; }
        /// <summary>
        /// AlternateNumberCountryCode of the Patient 
        /// </summary>
        public short? AlternateNumberCountryCode { get; set; }
        /// <summary>
        /// Foreign key referencing the Location to which the Patient belongs 
        /// </summary>
        public Guid? LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Import of the Patient 
        /// </summary>
        public bool? Import { get; set; }
        /// <summary>
        /// Foreign key referencing the Membership to which the Patient belongs 
        /// </summary>
        public Guid? MembershipId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Membership
        /// </summary>
        [ForeignKey("MembershipId")]
        public Membership? MembershipId_Membership { get; set; }
        /// <summary>
        /// PatientEnrollment of the Patient 
        /// </summary>
        public bool? PatientEnrollment { get; set; }

        /// <summary>
        /// EnrollmentDate of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EnrollmentDate { get; set; }
        /// <summary>
        /// Landline of the Patient 
        /// </summary>
        public string? Landline { get; set; }
        /// <summary>
        /// IsVip of the Patient 
        /// </summary>
        public bool? IsVip { get; set; }
        /// <summary>
        /// IsConfidential of the Patient 
        /// </summary>
        public bool? IsConfidential { get; set; }
        /// <summary>
        /// Code of the Patient 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Patient 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Patient 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// AvatarId of the Patient 
        /// </summary>
        public Guid? AvatarId { get; set; }
        /// <summary>
        /// Foreign key referencing the Title to which the Patient belongs 
        /// </summary>
        public Guid? Title { get; set; }

        /// <summary>
        /// Navigation property representing the associated Title
        /// </summary>
        [ForeignKey("Title")]
        public Title? Title_Title { get; set; }
        /// <summary>
        /// Age of the Patient 
        /// </summary>
        public decimal? Age { get; set; }
        /// <summary>
        /// DOBIsApproximate of the Patient 
        /// </summary>
        public bool? DOBIsApproximate { get; set; }
        /// <summary>
        /// NationalIdType of the Patient 
        /// </summary>
        public Guid? NationalIdType { get; set; }
        /// <summary>
        /// NationalIdNumber of the Patient 
        /// </summary>
        public string? NationalIdNumber { get; set; }

        /// <summary>
        /// RegisteredOn of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RegisteredOn { get; set; }
        /// <summary>
        /// NextOfKinName of the Patient 
        /// </summary>
        public string? NextOfKinName { get; set; }
        /// <summary>
        /// NextOfKinMobile of the Patient 
        /// </summary>
        public string? NextOfKinMobile { get; set; }
        /// <summary>
        /// ReferredBy of the Patient 
        /// </summary>
        public string? ReferredBy { get; set; }
        /// <summary>
        /// Occupation of the Patient 
        /// </summary>
        public Guid? Occupation { get; set; }
        /// <summary>
        /// PatientAddressId of the Patient 
        /// </summary>
        public Guid? PatientAddressId { get; set; }
        /// <summary>
        /// SocialHistoryId of the Patient 
        /// </summary>
        public Guid? SocialHistoryId { get; set; }

        /// <summary>
        /// LastVisitDate of the Patient 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LastVisitDate { get; set; }
    }
}