using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitchecklist entity with essential details
    /// </summary>
    public class VisitCheckList
    {
        /// <summary>
        /// Primary key for the VisitCheckList 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitCheckList belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitCheckList belongs 
        /// </summary>
        [Required]
        public Guid VisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("VisitId")]
        public Visit? VisitId_Visit { get; set; }

        /// <summary>
        /// Required field VisitTypeCheckListId of the VisitCheckList 
        /// </summary>
        [Required]
        public Guid VisitTypeCheckListId { get; set; }

        /// <summary>
        /// Required field ChecklistType of the VisitCheckList 
        /// </summary>
        [Required]
        public byte ChecklistType { get; set; }
        /// <summary>
        /// Value of the VisitCheckList 
        /// </summary>
        public bool? Value { get; set; }
        /// <summary>
        /// Name of the VisitCheckList 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitCheckList belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// CreatedOn of the VisitCheckList 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
    }
}