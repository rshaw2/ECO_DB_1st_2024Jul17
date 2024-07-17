using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitcovid19historyparameter entity with essential details
    /// </summary>
    public class VisitCovid19HistoryParameter
    {
        /// <summary>
        /// Initializes a new instance of the VisitCovid19HistoryParameter class.
        /// </summary>
        public VisitCovid19HistoryParameter()
        {
            IsStandard = false;
            IsSpecificValue = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitCovid19HistoryParameter belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitCovid19HistoryParameter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the VisitCovid19History to which the VisitCovid19HistoryParameter belongs 
        /// </summary>
        [Required]
        public Guid VisitCovid19History { get; set; }

        /// <summary>
        /// Navigation property representing the associated VisitCovid19History
        /// </summary>
        [ForeignKey("VisitCovid19History")]
        public VisitCovid19History? VisitCovid19History_VisitCovid19History { get; set; }

        /// <summary>
        /// Required field ClinicalParameter of the VisitCovid19HistoryParameter 
        /// </summary>
        [Required]
        public Guid ClinicalParameter { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitCovid19HistoryParameter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitCovid19HistoryParameter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitCovid19HistoryParameter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitCovid19HistoryParameter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitCovid19HistoryParameter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitCovid19HistoryParameter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitCovid19HistoryParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// ClinicalParameterValueName of the VisitCovid19HistoryParameter 
        /// </summary>
        public string? ClinicalParameterValueName { get; set; }
        /// <summary>
        /// AssociatedNotes of the VisitCovid19HistoryParameter 
        /// </summary>
        public string? AssociatedNotes { get; set; }
        /// <summary>
        /// Code of the VisitCovid19HistoryParameter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitCovid19HistoryParameter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitCovid19HistoryParameter 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// ClinicalParameterValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public Guid? ClinicalParameterValue { get; set; }
        /// <summary>
        /// IsSpecificValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public bool? IsSpecificValue { get; set; }
        /// <summary>
        /// TextValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public string? TextValue { get; set; }
        /// <summary>
        /// NumberValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public int? NumberValue { get; set; }
        /// <summary>
        /// DecimalValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public decimal? DecimalValue { get; set; }

        /// <summary>
        /// DateValue of the VisitCovid19HistoryParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateValue { get; set; }

        /// <summary>
        /// DateTimeValue of the VisitCovid19HistoryParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeValue { get; set; }

        /// <summary>
        /// TimeValue of the VisitCovid19HistoryParameter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TimeValue { get; set; }
        /// <summary>
        /// SystolicValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public int? SystolicValue { get; set; }
        /// <summary>
        /// DiastolicValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public int? DiastolicValue { get; set; }
        /// <summary>
        /// YearValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public int? YearValue { get; set; }
        /// <summary>
        /// DurationValue of the VisitCovid19HistoryParameter 
        /// </summary>
        public int? DurationValue { get; set; }
        /// <summary>
        /// UOM of the VisitCovid19HistoryParameter 
        /// </summary>
        public Guid? UOM { get; set; }
    }
}