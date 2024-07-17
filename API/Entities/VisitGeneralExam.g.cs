using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a visitgeneralexam entity with essential details
    /// </summary>
    public class VisitGeneralExam
    {
        /// <summary>
        /// Initializes a new instance of the VisitGeneralExam class.
        /// </summary>
        public VisitGeneralExam()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the VisitGeneralExam belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the VisitGeneralExam 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the VisitGeneralExam 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field GeneralExam of the VisitGeneralExam 
        /// </summary>
        [Required]
        public Guid GeneralExam { get; set; }

        /// <summary>
        /// Foreign key referencing the Visit to which the VisitGeneralExam belongs 
        /// </summary>
        [Required]
        public Guid Visit { get; set; }

        /// <summary>
        /// Navigation property representing the associated Visit
        /// </summary>
        [ForeignKey("Visit")]
        public Visit? Visit_Visit { get; set; }

        /// <summary>
        /// Required field EntityCode of the VisitGeneralExam 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the VisitGeneralExam 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the VisitGeneralExam 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the VisitGeneralExam belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the VisitGeneralExam 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the VisitGeneralExam belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the VisitGeneralExam 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the VisitGeneralExam 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the VisitGeneralExam 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the VisitGeneralExam 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Summary of the VisitGeneralExam 
        /// </summary>
        public string? Summary { get; set; }
    }
}