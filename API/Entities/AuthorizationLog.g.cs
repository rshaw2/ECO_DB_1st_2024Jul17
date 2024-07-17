using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a authorizationlog entity with essential details
    /// </summary>
    public class AuthorizationLog
    {
        /// <summary>
        /// Primary key for the AuthorizationLog 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the AuthorizationLog belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field Description of the AuthorizationLog 
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the AuthorizationLog belongs 
        /// </summary>
        [Required]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }

        /// <summary>
        /// Required field AuthorizationCode of the AuthorizationLog 
        /// </summary>
        [Required]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Required field CreatedOn of the AuthorizationLog 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the Patient to which the AuthorizationLog belongs 
        /// </summary>
        public Guid? PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the AuthorizationLog belongs 
        /// </summary>
        public Guid? VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }
        /// <summary>
        /// Foreign key referencing the ContactMember to which the AuthorizationLog belongs 
        /// </summary>
        public Guid? ContactMemberId { get; set; }

        /// <summary>
        /// Navigation property representing the associated ContactMember
        /// </summary>
        [ForeignKey("ContactMemberId")]
        public ContactMember? ContactMemberId_ContactMember { get; set; }
    }
}