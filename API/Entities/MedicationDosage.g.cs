using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medicationdosage entity with essential details
    /// </summary>
    public class MedicationDosage
    {
        /// <summary>
        /// Initializes a new instance of the MedicationDosage class.
        /// </summary>
        public MedicationDosage()
        {
            Flagged = false;
            Favourite = false;
            IsStandard = false;
            Sequence = 0;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the MedicationDosage belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the MedicationDosage 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Flagged of the MedicationDosage 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicationDosage belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the MedicationDosage 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the MedicationDosage belongs 
        /// </summary>
        [Required]
        public Guid User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }

        /// <summary>
        /// Required field Favourite of the MedicationDosage 
        /// </summary>
        [Required]
        public bool Favourite { get; set; }

        /// <summary>
        /// Required field EntityCode of the MedicationDosage 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the MedicationDosage 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the MedicationDosage 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the MedicationDosage 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Code of the MedicationDosage 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the MedicationDosage 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the MedicationDosage 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the MedicationDosage belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the MedicationDosage 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// DosageFormType of the MedicationDosage 
        /// </summary>
        public byte? DosageFormType { get; set; }
        /// <summary>
        /// DosageFormat of the MedicationDosage 
        /// </summary>
        public string? DosageFormat { get; set; }
        /// <summary>
        /// DosageFormatFrequency of the MedicationDosage 
        /// </summary>
        public Guid? DosageFormatFrequency { get; set; }
        /// <summary>
        /// Foreign key referencing the Medication to which the MedicationDosage belongs 
        /// </summary>
        public Guid? Medication { get; set; }

        /// <summary>
        /// Navigation property representing the associated Medication
        /// </summary>
        [ForeignKey("Medication")]
        public Medication? Medication_Medication { get; set; }
        /// <summary>
        /// Dosage of the MedicationDosage 
        /// </summary>
        public decimal? Dosage { get; set; }
        /// <summary>
        /// Foreign key referencing the UomInFormulation to which the MedicationDosage belongs 
        /// </summary>
        public Guid? DosageForm { get; set; }

        /// <summary>
        /// Navigation property representing the associated UomInFormulation
        /// </summary>
        [ForeignKey("DosageForm")]
        public UomInFormulation? DosageForm_UomInFormulation { get; set; }
        /// <summary>
        /// Frequency of the MedicationDosage 
        /// </summary>
        public int? Frequency { get; set; }
        /// <summary>
        /// FrequencyValue of the MedicationDosage 
        /// </summary>
        public Guid? FrequencyValue { get; set; }
        /// <summary>
        /// SingleDosage of the MedicationDosage 
        /// </summary>
        public bool? SingleDosage { get; set; }
        /// <summary>
        /// MedicationInstruction of the MedicationDosage 
        /// </summary>
        public Guid? MedicationInstruction { get; set; }
        /// <summary>
        /// Duration of the MedicationDosage 
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// Uom of the MedicationDosage 
        /// </summary>
        public Guid? Uom { get; set; }
        /// <summary>
        /// Ongoing of the MedicationDosage 
        /// </summary>
        public bool? Ongoing { get; set; }
        /// <summary>
        /// Stat of the MedicationDosage 
        /// </summary>
        public bool? Stat { get; set; }
        /// <summary>
        /// MedicationNotes of the MedicationDosage 
        /// </summary>
        public Guid? MedicationNotes { get; set; }
        /// <summary>
        /// Quantity of the MedicationDosage 
        /// </summary>
        public int? Quantity { get; set; }
        /// <summary>
        /// Sequence of the MedicationDosage 
        /// </summary>
        public int? Sequence { get; set; }
    }
}