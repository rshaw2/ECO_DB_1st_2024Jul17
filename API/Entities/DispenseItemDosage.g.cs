using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dispenseitemdosage entity with essential details
    /// </summary>
    public class DispenseItemDosage
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the DispenseItemDosage belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the DispenseItemDosage 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the DispenseItem to which the DispenseItemDosage belongs 
        /// </summary>
        [Required]
        public Guid DispenseItemId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DispenseItem
        /// </summary>
        [ForeignKey("DispenseItemId")]
        public DispenseItem? DispenseItemId_DispenseItem { get; set; }

        /// <summary>
        /// Required field Sequence of the DispenseItemDosage 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DispenseItemDosage belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DispenseItemDosage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the DispenseItemDosage belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the DispenseItemDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DosageFormType of the DispenseItemDosage 
        /// </summary>
        public byte? DosageFormType { get; set; }
        /// <summary>
        /// DosageFormat of the DispenseItemDosage 
        /// </summary>
        public string? DosageFormat { get; set; }
        /// <summary>
        /// DosageFormatFrequencyId of the DispenseItemDosage 
        /// </summary>
        public Guid? DosageFormatFrequencyId { get; set; }
        /// <summary>
        /// Dosage of the DispenseItemDosage 
        /// </summary>
        public decimal? Dosage { get; set; }
        /// <summary>
        /// Foreign key referencing the UomInFormulation to which the DispenseItemDosage belongs 
        /// </summary>
        public Guid? DosageFormId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UomInFormulation
        /// </summary>
        [ForeignKey("DosageFormId")]
        public UomInFormulation? DosageFormId_UomInFormulation { get; set; }
        /// <summary>
        /// Frequency of the DispenseItemDosage 
        /// </summary>
        public int? Frequency { get; set; }
        /// <summary>
        /// FrequencyValueId of the DispenseItemDosage 
        /// </summary>
        public Guid? FrequencyValueId { get; set; }
        /// <summary>
        /// SingleDosage of the DispenseItemDosage 
        /// </summary>
        public bool? SingleDosage { get; set; }
        /// <summary>
        /// Foreign key referencing the MedicationInstruction to which the DispenseItemDosage belongs 
        /// </summary>
        public Guid? MedicationInstructionId { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationInstruction
        /// </summary>
        [ForeignKey("MedicationInstructionId")]
        public MedicationInstruction? MedicationInstructionId_MedicationInstruction { get; set; }
        /// <summary>
        /// Duration of the DispenseItemDosage 
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// Foreign key referencing the UOM to which the DispenseItemDosage belongs 
        /// </summary>
        public Guid? UomId { get; set; }

        /// <summary>
        /// Navigation property representing the associated UOM
        /// </summary>
        [ForeignKey("UomId")]
        public UOM? UomId_UOM { get; set; }
        /// <summary>
        /// Ongoing of the DispenseItemDosage 
        /// </summary>
        public bool? Ongoing { get; set; }
        /// <summary>
        /// Stat of the DispenseItemDosage 
        /// </summary>
        public bool? Stat { get; set; }
        /// <summary>
        /// MedicationNoteId of the DispenseItemDosage 
        /// </summary>
        public Guid? MedicationNoteId { get; set; }
        /// <summary>
        /// Quantity of the DispenseItemDosage 
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// StartDate of the DispenseItemDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate of the DispenseItemDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
    }
}