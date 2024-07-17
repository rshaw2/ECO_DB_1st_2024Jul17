using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tenantextension entity with essential details
    /// </summary>
    public class TenantExtension
    {
        /// <summary>
        /// Initializes a new instance of the TenantExtension class.
        /// </summary>
        public TenantExtension()
        {
            PrePrinted = false;
            TopMargin = 0M;
            BottomMargin = 0M;
            KycCompleted = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the TenantExtension belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the TenantExtension 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }
        /// <summary>
        /// PrescriptionFooterAddress of the TenantExtension 
        /// </summary>
        public string? PrescriptionFooterAddress { get; set; }
        /// <summary>
        /// RequireAcceptance of the TenantExtension 
        /// </summary>
        public bool? RequireAcceptance { get; set; }
        /// <summary>
        /// RequireReAcceptance of the TenantExtension 
        /// </summary>
        public bool? RequireReAcceptance { get; set; }
        /// <summary>
        /// Accepted of the TenantExtension 
        /// </summary>
        public bool? Accepted { get; set; }
        /// <summary>
        /// ClinicDetailCompleted of the TenantExtension 
        /// </summary>
        public bool? ClinicDetailCompleted { get; set; }
        /// <summary>
        /// PrescriptionDetailCompleted of the TenantExtension 
        /// </summary>
        public bool? PrescriptionDetailCompleted { get; set; }
        /// <summary>
        /// PrescriptionFooterVisitingHours of the TenantExtension 
        /// </summary>
        public string? PrescriptionFooterVisitingHours { get; set; }
        /// <summary>
        /// PrePrinted of the TenantExtension 
        /// </summary>
        public bool? PrePrinted { get; set; }
        /// <summary>
        /// TopMargin of the TenantExtension 
        /// </summary>
        public decimal? TopMargin { get; set; }
        /// <summary>
        /// BottomMargin of the TenantExtension 
        /// </summary>
        public decimal? BottomMargin { get; set; }
        /// <summary>
        /// LeftMargin of the TenantExtension 
        /// </summary>
        public decimal? LeftMargin { get; set; }
        /// <summary>
        /// RightMargin of the TenantExtension 
        /// </summary>
        public decimal? RightMargin { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the TenantExtension belongs 
        /// </summary>
        public Guid? User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }
        /// <summary>
        /// Foreign key referencing the Image to which the TenantExtension belongs 
        /// </summary>
        public Guid? AvatarId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Image
        /// </summary>
        [ForeignKey("AvatarId")]
        public Image? AvatarId_Image { get; set; }
        /// <summary>
        /// Foreign key referencing the Image to which the TenantExtension belongs 
        /// </summary>
        public Guid? DigitalSignatureId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Image
        /// </summary>
        [ForeignKey("DigitalSignatureId")]
        public Image? DigitalSignatureId_Image { get; set; }
        /// <summary>
        /// TrialOnboardingCompleted of the TenantExtension 
        /// </summary>
        public bool? TrialOnboardingCompleted { get; set; }
        /// <summary>
        /// KycCompleted of the TenantExtension 
        /// </summary>
        public bool? KycCompleted { get; set; }
    }
}