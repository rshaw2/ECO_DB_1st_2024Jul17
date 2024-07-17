using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a covid19historychoice entity with essential details
    /// </summary>
    public class Covid19HistoryChoice
    {
        /// <summary>
        /// Initializes a new instance of the Covid19HistoryChoice class.
        /// </summary>
        public Covid19HistoryChoice()
        {
            IsStandard = false;
        }

        /// <summary>
        /// Foreign key referencing the Tenant to which the Covid19HistoryChoice belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the Covid19HistoryChoice 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Sequence of the Covid19HistoryChoice 
        /// </summary>
        [Required]
        public int Sequence { get; set; }

        /// <summary>
        /// Foreign key referencing the Covid19History to which the Covid19HistoryChoice belongs 
        /// </summary>
        [Required]
        public Guid Covid19History { get; set; }

        /// <summary>
        /// Navigation property representing the associated Covid19History
        /// </summary>
        [ForeignKey("Covid19History")]
        public Covid19History? Covid19History_Covid19History { get; set; }

        /// <summary>
        /// Required field EntityCode of the Covid19HistoryChoice 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Covid19HistoryChoice 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Required field IsStandard of the Covid19HistoryChoice 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Covid19HistoryChoice belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Covid19HistoryChoice 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Covid19HistoryChoice belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the Covid19HistoryChoice 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Code of the Covid19HistoryChoice 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Covid19HistoryChoice 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Active of the Covid19HistoryChoice 
        /// </summary>
        public Guid? Active { get; set; }
        /// <summary>
        /// Covid19HistoryChoiceTemplate of the Covid19HistoryChoice 
        /// </summary>
        public Guid? Covid19HistoryChoiceTemplate { get; set; }
    }
}