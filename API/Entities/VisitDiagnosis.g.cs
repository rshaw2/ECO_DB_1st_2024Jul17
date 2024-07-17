using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitdiagnosis entity with essential details
    /// </summary>
    public class VisitDiagnosis
    {
        /// <summary>
        /// Initializes a new instance of the VisitDiagnosis class.
        /// </summary>
        public VisitDiagnosis()
        {
            IsStandard = false;
            FollowupVisit = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitDiagnosis belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitDiagnosis 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitDiagnosis 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field Diagnosis of the VisitDiagnosis 
        /// </summary>
        [Required]
        public Guid Diagnosis { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitDiagnosis belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitDiagnosis 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitDiagnosis 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitDiagnosis belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitDiagnosis 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitDiagnosis 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// IcdCode of the VisitDiagnosis 
        /// </summary>
        public string? IcdCode { get; set; }
        /// <summary>
        /// IcdName of the VisitDiagnosis 
        /// </summary>
        public string? IcdName { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitDiagnosis belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitDiagnosis 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitDiagnosis 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitDiagnosis 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitDiagnosis 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Summary of the VisitDiagnosis 
        /// </summary>
        public string? Summary { get; set; }
        /// <summary>
        /// FollowupVisit of the VisitDiagnosis 
        /// </summary>
        public bool? FollowupVisit { get; set; }
    }
}