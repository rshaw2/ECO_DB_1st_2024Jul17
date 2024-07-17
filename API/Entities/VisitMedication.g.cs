using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitmedication entity with essential details
    /// </summary>
    public class VisitMedication
    {
        /// <summary>
        /// Initializes a new instance of the VisitMedication class.
        /// </summary>
        public VisitMedication()
        {
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitMedication belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitMedication 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitMedication 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Medication of the VisitMedication 
        /// </summary>
        [Required]
        public Guid Medication { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitMedication belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field Flagged of the VisitMedication 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitMedication belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitMedication 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitMedication 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitMedication 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitMedication 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the VisitMedication 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the VisitMedication 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitMedication 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitMedication 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitMedication belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitMedication 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// MoveToCurrent of the VisitMedication 
        /// </summary>
        public bool? MoveToCurrent { get; set; }
        /// <summary>
        /// CeaseVisitId of the VisitMedication 
        /// </summary>
        public Guid? CeaseVisitId { get; set; }
        /// <summary>
        /// RefillCount of the VisitMedication 
        /// </summary>
        public short? RefillCount { get; set; }
        /// <summary>
        /// RefillDuration of the VisitMedication 
        /// </summary>
        public short? RefillDuration { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the VisitMedication belongs 
        /// </summary>
        public Guid? RefillDurationUomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("RefillDurationUomId")]
        public UOM? RefillDurationUomId_UOM { get; set; }
        /// <summary>
        /// Completed of the VisitMedication 
        /// </summary>
        public bool? Completed { get; set; }
        /// <summary>
        /// CompletedReason of the VisitMedication 
        /// </summary>
        public string? CompletedReason { get; set; }
        /// <summary>
        /// Dispensed of the VisitMedication 
        /// </summary>
        public bool? Dispensed { get; set; }
        /// <summary>
        /// Cease of the VisitMedication 
        /// </summary>
        public bool? Cease { get; set; }
        /// <summary>
        /// ReadyRxItem of the VisitMedication 
        /// </summary>
        public Guid? ReadyRxItem { get; set; }
        /// <summary>
        /// Summary of the VisitMedication 
        /// </summary>
        public string? Summary { get; set; }
    }
}