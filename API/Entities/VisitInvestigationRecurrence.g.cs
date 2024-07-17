using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitinvestigationrecurrence entity with essential details
    /// </summary>
    public class VisitInvestigationRecurrence
    {
        /// <summary>
        /// Initializes a new instance of the VisitInvestigationRecurrence class.
        /// </summary>
        public VisitInvestigationRecurrence()
        {
            IsSpecificEndDate = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitInvestigationRecurrence belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitInvestigationRecurrence 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitInvestigation to which the VisitInvestigationRecurrence belongs 
        /// </summary>
        [Required]
        public Guid VisitInvestigationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitInvestigation
        /// </summary>
        [ForeignKey("VisitInvestigationId")]
        public VisitInvestigation? VisitInvestigationId_VisitInvestigation { get; set; }

        /// <summary>
        /// Foreign key referencing the UOM to which the VisitInvestigationRecurrence belongs 
        /// </summary>
        [Required]
        public Guid RecurringPatternUnit { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("RecurringPatternUnit")]
        public UOM? RecurringPatternUnit_UOM { get; set; }

        /// <summary>
        /// Required field RecurringPatternValue of the VisitInvestigationRecurrence 
        /// </summary>
        [Required]
        public short RecurringPatternValue { get; set; }

        /// <summary>
        /// Required field StartDate of the VisitInvestigationRecurrence 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required field EndDate of the VisitInvestigationRecurrence 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the VisitInvestigationRecurrence belongs 
        /// </summary>
        public Guid? EndDateUnit { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("EndDateUnit")]
        public UOM? EndDateUnit_UOM { get; set; }
        /// <summary>
        /// EndDateValue of the VisitInvestigationRecurrence 
        /// </summary>
        public short? EndDateValue { get; set; }
        /// <summary>
        /// IsSpecificEndDate of the VisitInvestigationRecurrence 
        /// </summary>
        public bool? IsSpecificEndDate { get; set; }
    }
}