using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitinvestigationnotes entity with essential details
    /// </summary>
    public class VisitInvestigationNotes
    {
        /// <summary>
        /// Initializes a new instance of the VisitInvestigationNotes class.
        /// </summary>
        public VisitInvestigationNotes()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitInvestigationNotes belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigationNotes 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitInvestigationNotes 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitInvestigationNotes 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitInvestigationNotes 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationNotes belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitInvestigationNotes 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitInvestigationNotes belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitInvestigationNotes 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitInvestigationNotes 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitInvestigationNotes 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitInvestigationNotes 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the VisitInvestigationNotes belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
        /// <summary>
        /// Notes of the VisitInvestigationNotes 
        /// </summary>
        public string? Notes { get; set; }
    }
}