using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a requisitionfile entity with essential details
    /// </summary>
    public class RequisitionFile
    {
        /// <summary>
        /// Initializes a new instance of the RequisitionFile class.
        /// </summary>
        public RequisitionFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the RequisitionFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the RequisitionFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Required field RequisitionId of the RequisitionFile 
        /// </summary>
        [Required]
        public Guid RequisitionId { get; set; }

        /// <summary>
        /// Required field RequisitionCode of the RequisitionFile 
        /// </summary>
        [Required]
        public string RequisitionCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the RequisitionFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the RequisitionFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the RequisitionFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the RequisitionFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the RequisitionFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the RequisitionFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the RequisitionFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the RequisitionFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}