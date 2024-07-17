using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a stocktakefile entity with essential details
    /// </summary>
    public class StockTakeFile
    {
        /// <summary>
        /// Initializes a new instance of the StockTakeFile class.
        /// </summary>
        public StockTakeFile()
        {
            Print = false;
        }

        /// <summary>
        /// Primary key for the StockTakeFile 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Tenant to which the StockTakeFile belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Foreign key referencing the StockTake to which the StockTakeFile belongs 
        /// </summary>
        [Required]
        public Guid StockTakeId { get; set; }

        /// <summary>
        /// Navigation property representing the associated StockTake
        /// </summary>
        [ForeignKey("StockTakeId")]
        public StockTake? StockTakeId_StockTake { get; set; }

        /// <summary>
        /// Required field StockTakeCode of the StockTakeFile 
        /// </summary>
        [Required]
        public string StockTakeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the StockTakeFile belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the StockTakeFile 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field Print of the StockTakeFile 
        /// </summary>
        [Required]
        public bool Print { get; set; }
        /// <summary>
        /// Title of the StockTakeFile 
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// FileName of the StockTakeFile 
        /// </summary>
        public string? FileName { get; set; }
        /// <summary>
        /// FileExtension of the StockTakeFile 
        /// </summary>
        public string? FileExtension { get; set; }
        /// <summary>
        /// MimeType of the StockTakeFile 
        /// </summary>
        public string? MimeType { get; set; }
        /// <summary>
        /// AzureFilePath of the StockTakeFile 
        /// </summary>
        public string? AzureFilePath { get; set; }
    }
}