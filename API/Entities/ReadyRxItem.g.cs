using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a readyrxitem entity with essential details
    /// </summary>
    public class ReadyRxItem
    {
        /// <summary>
        /// Initializes a new instance of the ReadyRxItem class.
        /// </summary>
        public ReadyRxItem()
        {
            Flagged = false;
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the ReadyRxItem belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the ReadyRxItem 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the ReadyRxItem 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Required field EntityCode of the ReadyRxItem 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the ReadyRxItem 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field Flagged of the ReadyRxItem 
        /// </summary>
        [Required]
        public bool Flagged { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the ReadyRxItem belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the ReadyRxItem 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the ReadyRxItem 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the ReadyRxItem 
        /// </summary>
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ReadyRxItem belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the ReadyRxItem 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the ReadyRxItem 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the ReadyRxItem 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the ReadyRxItem 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Medication of the ReadyRxItem 
        /// </summary>
        public Guid? Medication { get; set; }
        /// <summary>
        /// Foreign key referencing the Medication to which the ReadyRxItem belongs 
        /// </summary>
        public Guid? ReadyRx { get; set; }

        /// <summary>
        /// Navigation property representing the associated Medication
        /// </summary>
        [ForeignKey("ReadyRx")]
        public Medication? ReadyRx_Medication { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the ReadyRxItem belongs 
        /// </summary>
        public Guid? User { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("User")]
        public User? User_User { get; set; }
        /// <summary>
        /// IsDeleted of the ReadyRxItem 
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}