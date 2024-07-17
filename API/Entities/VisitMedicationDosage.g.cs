using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitmedicationdosage entity with essential details
    /// </summary>
    public class VisitMedicationDosage
    {
        /// <summary>
        /// Initializes a new instance of the VisitMedicationDosage class.
        /// </summary>
        public VisitMedicationDosage()
        {
            Flagged = false;
            IsStandard = false;
            Sequence = 0;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitMedicationDosage belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitMedicationDosage 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the VisitMedicationDosage 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicationDosage belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitMedicationDosage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitMedicationDosage 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitMedicationDosage 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitMedicationDosage 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the VisitMedicationDosage 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the VisitMedicationDosage 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitMedicationDosage 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitMedicationDosage 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitMedicationDosage belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitMedicationDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DosageFormType of the VisitMedicationDosage 
        /// </summary>
        public byte? DosageFormType { get; set; }
        /// <summary>
        /// DosageFormat of the VisitMedicationDosage 
        /// </summary>
        public string? DosageFormat { get; set; }
        /// <summary>
        /// DosageFormatFrequency of the VisitMedicationDosage 
        /// </summary>
        public Guid? DosageFormatFrequency { get; set; }
        /// <summary>
        /// Foreign key referencing the VisitMedication to which the VisitMedicationDosage belongs 
        /// </summary>
        public Guid? VisitMedication { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitMedication
        /// </summary>
        [ForeignKey("VisitMedication")]
        public VisitMedication? VisitMedication_VisitMedication { get; set; }
        /// <summary>
        /// Dosage of the VisitMedicationDosage 
        /// </summary>
        public decimal? Dosage { get; set; }
        /// <summary>
        /// Foreign key referencing the UomInFormulation to which the VisitMedicationDosage belongs 
        /// </summary>
        public Guid? DosageForm { get; set; }

        /// <summary>
        /// Navigation property representing the associated UomInFormulation
        /// </summary>
        [ForeignKey("DosageForm")]
        public UomInFormulation? DosageForm_UomInFormulation { get; set; }
        /// <summary>
        /// Frequency of the VisitMedicationDosage 
        /// </summary>
        public int? Frequency { get; set; }
        /// <summary>
        /// FrequencyValue of the VisitMedicationDosage 
        /// </summary>
        public Guid? FrequencyValue { get; set; }
        /// <summary>
        /// SingleDosage of the VisitMedicationDosage 
        /// </summary>
        public bool? SingleDosage { get; set; }
        /// <summary>
        /// MedicationInstruction of the VisitMedicationDosage 
        /// </summary>
        public Guid? MedicationInstruction { get; set; }
        /// <summary>
        /// Duration of the VisitMedicationDosage 
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// Uom of the VisitMedicationDosage 
        /// </summary>
        public Guid? Uom { get; set; }
        /// <summary>
        /// Ongoing of the VisitMedicationDosage 
        /// </summary>
        public bool? Ongoing { get; set; }
        /// <summary>
        /// Stat of the VisitMedicationDosage 
        /// </summary>
        public bool? Stat { get; set; }
        /// <summary>
        /// MedicationNotes of the VisitMedicationDosage 
        /// </summary>
        public Guid? MedicationNotes { get; set; }
        /// <summary>
        /// Quantity of the VisitMedicationDosage 
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// StartDate of the VisitMedicationDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the VisitMedicationDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// Sequence of the VisitMedicationDosage 
        /// </summary>
        public int? Sequence { get; set; }
    }
}