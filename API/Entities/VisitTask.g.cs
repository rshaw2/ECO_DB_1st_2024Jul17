using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visittask entity with essential details
    /// </summary>
    public class VisitTask
    {
        /// <summary>
        /// Initializes a new instance of the VisitTask class.
        /// </summary>
        public VisitTask()
        {
            Completed = false;
        }

        /// <summary>
        /// Primary key for the VisitTask 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the TaskType to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid TaskId { get; set; }

        /// <summary>
        /// Navigation property representing the associated TaskType
        /// </summary>
        [ForeignKey("TaskId")]
        public TaskType? TaskId_TaskType { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid AssignTo { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("AssignTo")]
        public User? AssignTo_User { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field Completed of the VisitTask 
        /// </summary>
        [Required]
        public bool Completed { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitTask 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the VisitTask belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the SubLocation to which the VisitTask belongs 
        /// </summary>
        public Guid? SubLocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated SubLocation
        /// </summary>
        [ForeignKey("SubLocationId")]
        public SubLocation? SubLocationId_SubLocation { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitTask belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitTask 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }

        /// <summary>
        /// DueDate of the VisitTask 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        /// <summary>
        /// FromPreviousVisit of the VisitTask 
        /// </summary>
        public bool? FromPreviousVisit { get; set; }
        /// <summary>
        /// TaskStatus of the VisitTask 
        /// </summary>
        public byte? TaskStatus { get; set; }
        /// <summary>
        /// Notes of the VisitTask 
        /// </summary>
        public string? Notes { get; set; }
    }
}