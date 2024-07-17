using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a dispensefile entity with essential details
    /// </summary>
    public class DispenseFile
    {
        /// <summary>
        /// Initializes a new instance of the DispenseFile class.
        /// </summary>
        public DispenseFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the DispenseFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the DispenseFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the Dispense to which the DispenseFile belongs 
        /// </summary>
        [Required]
        public Guid DispenseId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Dispense
        /// </summary>
        [ForeignKey("DispenseId")]
        public Dispense? DispenseId_Dispense { get; set; }

        /// <summary>
        /// Required field DispenseNo of the DispenseFile 
        /// </summary>
        [Required]
        public string DispenseNo { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the DispenseFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the DispenseFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the DispenseFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the DispenseFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the DispenseFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the DispenseFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the DispenseFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the DispenseFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
        /// <summary>
        /// Foreign key referencing the DispenseItem to which the DispenseFile belongs 
        /// </summary>
        public Guid? DispenseItemId { get; set; }

        /// <summary>
        /// Navigation property representing the associated DispenseItem
        /// </summary>
        [ForeignKey("DispenseItemId")]
        public DispenseItem? DispenseItemId_DispenseItem { get; set; }
    }
}