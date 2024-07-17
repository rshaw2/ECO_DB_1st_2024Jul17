using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a tokenmanagement entity with essential details
    /// </summary>
    public class TokenManagement
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the TokenManagement belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the TokenManagement 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field TokenDate of the TokenManagement 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TokenDate { get; set; }

        /// <summary>
        /// Foreign key referencing the Patient to which the TokenManagement belongs 
        /// </summary>
        [Required]
        public Guid PatientId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Patient
        /// </summary>
        [ForeignKey("PatientId")]
        public Patient? PatientId_Patient { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TokenManagement belongs 
        /// </summary>
        [Required]
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("DoctorId")]
        public User? DoctorId_User { get; set; }

        /// <summary>
        /// Required field TokenNumber of the TokenManagement 
        /// </summary>
        [Required]
        public int TokenNumber { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the TokenManagement belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the TokenManagement 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Foreign key referencing the Location to which the TokenManagement belongs 
        /// </summary>
        [Required]
        public Guid LocationId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Location
        /// </summary>
        [ForeignKey("LocationId")]
        public Location? LocationId_Location { get; set; }
        /// <summary>
        /// Foreign key referencing the DayVisit to which the TokenManagement belongs 
        /// </summary>
        public Guid? DayVisitId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DayVisit
        /// </summary>
        [ForeignKey("DayVisitId")]
        public DayVisit? DayVisitId_DayVisit { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the TokenManagement belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the TokenManagement 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// PatientArrivalStatus of the TokenManagement 
        /// </summary>
        public byte? PatientArrivalStatus { get; set; }
    }
}