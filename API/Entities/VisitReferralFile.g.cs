using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitreferralfile entity with essential details
    /// </summary>
    public class VisitReferralFile
    {
        /// <summary>
        /// Initializes a new instance of the VisitReferralFile class.
        /// </summary>
        public VisitReferralFile()
        {
            VisitReferralType = 1;
            Print = false;
        }

        /// <summary>
        /// Primary key for the VisitReferralFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitReferralFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitReferralFile belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitReferralFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitReferralFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field VisitReferralType of the VisitReferralFile 
        /// </summary>
        [Required]
        public byte VisitReferralType { get; set; }
        /// <summary>
        /// Print of the VisitReferralFile 
        /// </summary>
        public bool? Print { get; set; }
        /// <summary>
        /// Closed of the VisitReferralFile 
        /// </summary>
        public bool? Closed { get; set; }
        /// <summary>
        /// Title of the VisitReferralFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the VisitReferralFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the VisitReferralFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the VisitReferralFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the VisitReferralFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}