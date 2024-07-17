using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a emrgeneralsettings entity with essential details
    /// </summary>
    public class EmrGeneralSettings
    {
        /// <summary>
        /// Initializes a new instance of the EmrGeneralSettings class.
        /// </summary>
        public EmrGeneralSettings()
        {
            MedicationLayout = 1;
            RxDosageMandatory = false;
            RxFrequencyMandatory = false;
            RxDurationMandatory = false;
            RxInstructionsMandatory = false;
            RxRouteMandatory = false;
            RxFormulationMandatory = false;
            RxRefillMandatory = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the EmrGeneralSettings belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EmrGeneralSettings 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field DropoutValue of the EmrGeneralSettings 
        /// </summary>
        [Required]
        public byte DropoutValue { get; set; }

        /// <summary>
        /// Required field DropoutValueUnit of the EmrGeneralSettings 
        /// </summary>
        [Required]
        public byte DropoutValueUnit { get; set; }

        /// <summary>
        /// Required field MedicationLayout of the EmrGeneralSettings 
        /// </summary>
        [Required]
        public byte MedicationLayout { get; set; }
        /// <summary>
        /// InvestigationResultMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? InvestigationResultMandatory { get; set; }
        /// <summary>
        /// VisitOpenInvoiceCheck of the EmrGeneralSettings 
        /// </summary>
        public bool? VisitOpenInvoiceCheck { get; set; }
        /// <summary>
        /// RxDosageMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxDosageMandatory { get; set; }
        /// <summary>
        /// RxFrequencyMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxFrequencyMandatory { get; set; }
        /// <summary>
        /// RxDurationMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxDurationMandatory { get; set; }
        /// <summary>
        /// RxInstructionsMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxInstructionsMandatory { get; set; }
        /// <summary>
        /// RxRouteMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxRouteMandatory { get; set; }
        /// <summary>
        /// RxFormulationMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxFormulationMandatory { get; set; }
        /// <summary>
        /// RxRefillMandatory of the EmrGeneralSettings 
        /// </summary>
        public bool? RxRefillMandatory { get; set; }
        /// <summary>
        /// DosageFormat of the EmrGeneralSettings 
        /// </summary>
        public byte? DosageFormat { get; set; }
        /// <summary>
        /// RxQuantityAutoCalculate of the EmrGeneralSettings 
        /// </summary>
        public bool? RxQuantityAutoCalculate { get; set; }
        /// <summary>
        /// RxAdditionalDetails of the EmrGeneralSettings 
        /// </summary>
        public bool? RxAdditionalDetails { get; set; }
        /// <summary>
        /// DualDiagnosis of the EmrGeneralSettings 
        /// </summary>
        public bool? DualDiagnosis { get; set; }
        /// <summary>
        /// DiagnosisType of the EmrGeneralSettings 
        /// </summary>
        public byte? DiagnosisType { get; set; }
        /// <summary>
        /// MedicalCertificateMapped of the EmrGeneralSettings 
        /// </summary>
        public bool? MedicalCertificateMapped { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the EmrGeneralSettings belongs 
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("ProductId")]
        public Product? ProductId_Product { get; set; }
    }
}