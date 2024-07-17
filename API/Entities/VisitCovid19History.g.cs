using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitcovid19history entity with essential details
    /// </summary>
    public class VisitCovid19History
    {
        /// <summary>
        /// Initializes a new instance of the VisitCovid19History class.
        /// </summary>
        public VisitCovid19History()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitCovid19History belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitCovid19History 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitCovid19History 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Covid19History of the VisitCovid19History 
        /// </summary>
        [Required]
        public Guid Covid19History { get; set; }

        /// <summary>
        /// Required field Covid19HistoryChoice of the VisitCovid19History 
        /// </summary>
        [Required]
        public Guid Covid19HistoryChoice { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitCovid19History 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitCovid19History 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitCovid19History 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitCovid19History belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitCovid19History 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the VisitCovid19History belongs 
        /// </summary>
        [Required]
        public Guid Patient { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("Patient")]
        public Patient? Patient_Patient { get; set; }
        /// <summary>
        /// Summary of the VisitCovid19History 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitCovid19History belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitCovid19History 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Covid19HistoryChoiceName of the VisitCovid19History 
        /// </summary>
        public string? Covid19HistoryChoiceName { get; set; }
        /// <summary>
        /// Code of the VisitCovid19History 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitCovid19History 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitCovid19History 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Foreign key referencing the Visit to which the VisitCovid19History belongs 
        /// </summary>
        public Guid? Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }
    }
}