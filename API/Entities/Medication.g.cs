using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a medication entity with essential details
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// Initializes a new instance of the Medication class.
        /// </summary>
        public Medication()
        {
            Flagged = false;
            IsStandard = false;
            Deleted = false;
            ReadyRx = false;
            OtcDrug = false;
            SystemFavourite = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Medication belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Medication 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Medication 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Medication 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the Medication 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Medication belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Medication 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Medication 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Required field Deleted of the Medication 
        /// </summary>
        [Required]
        public bool Deleted { get; set; }
        /// <summary>
        /// MedicationType of the Medication 
        /// </summary>
        public byte? MedicationType { get; set; }
        /// <summary>
        /// Foreign key referencing the Route to which the Medication belongs 
        /// </summary>
        public Guid? RouteId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Route
        /// </summary>
        [ForeignKey("RouteId")]
        public Route? RouteId_Route { get; set; }
        /// <summary>
        /// ParentId of the Medication 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Medication belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Medication 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Medication 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Medication 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Generic of the Medication 
        /// </summary>
        public string? Generic { get; set; }
        /// <summary>
        /// Active of the Medication 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// ReadyRx of the Medication 
        /// </summary>
        public bool? ReadyRx { get; set; }
        /// <summary>
        /// FormulationCode of the Medication 
        /// </summary>
        public string? FormulationCode { get; set; }
        /// <summary>
        /// OtcDrug of the Medication 
        /// </summary>
        public bool? OtcDrug { get; set; }
        /// <summary>
        /// SystemFavourite of the Medication 
        /// </summary>
        public bool? SystemFavourite { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Medication belongs 
        /// </summary>
        public Guid? User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }
    }
}