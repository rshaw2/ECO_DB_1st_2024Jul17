using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitchiefcomplaint entity with essential details
    /// </summary>
    public class VisitChiefComplaint
    {
        /// <summary>
        /// Initializes a new instance of the VisitChiefComplaint class.
        /// </summary>
        public VisitChiefComplaint()
        {
            IsStandard = false;
            FollowUpVisit = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitChiefComplaint 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitChiefComplaint 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field ChiefComplaint of the VisitChiefComplaint 
        /// </summary>
        [Required]
        public Guid ChiefComplaint { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitChiefComplaint 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitChiefComplaint 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitChiefComplaint 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitChiefComplaint belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitChiefComplaint 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitChiefComplaint belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitChiefComplaint 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitChiefComplaint 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitChiefComplaint 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitChiefComplaint 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Summary of the VisitChiefComplaint 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// FollowUpVisit of the VisitChiefComplaint 
        /// </summary>
        public bool? FollowUpVisit { get; set; }
    }
}