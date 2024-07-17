using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a enrolledprogramreward entity with essential details
    /// </summary>
    public class EnrolledProgramReward
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the EnrolledProgramReward belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the EnrolledProgramReward 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgram to which the EnrolledProgramReward belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgram
        /// </summary>
        [ForeignKey("EnrolledProgramId")]
        public EnrolledProgram? EnrolledProgramId_EnrolledProgram { get; set; }

        /// <summary>
        /// Foreign key referencing the EnrolledProgramDetails to which the EnrolledProgramReward belongs 
        /// </summary>
        [Required]
        public Guid EnrolledProgramDetailId { get; set; }

        /// <summary>
        /// Navigation property representing the associated EnrolledProgramDetails
        /// </summary>
        [ForeignKey("EnrolledProgramDetailId")]
        public EnrolledProgramDetails? EnrolledProgramDetailId_EnrolledProgramDetails { get; set; }

        /// <summary>
        /// Required field EcCoinsEarned of the EnrolledProgramReward 
        /// </summary>
        [Required]
        public decimal EcCoinsEarned { get; set; }

        /// <summary>
        /// Required field EcCoinsRedeemed of the EnrolledProgramReward 
        /// </summary>
        [Required]
        public decimal EcCoinsRedeemed { get; set; }

        /// <summary>
        /// Required field BalanceAfterTransaction of the EnrolledProgramReward 
        /// </summary>
        [Required]
        public decimal BalanceAfterTransaction { get; set; }

        /// <summary>
        /// Required field TransactionType of the EnrolledProgramReward 
        /// </summary>
        [Required]
        public short TransactionType { get; set; }

        /// <summary>
        /// Required field Debit of the EnrolledProgramReward 
        /// </summary>
        [Required]
        public bool Debit { get; set; }

        /// <summary>
        /// Required field CreatedOn of the EnrolledProgramReward 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }
        /// <summary>
        /// SubscriptionGained of the EnrolledProgramReward 
        /// </summary>
        public int? SubscriptionGained { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the EnrolledProgramReward belongs 
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }
        /// <summary>
        /// Description of the EnrolledProgramReward 
        /// </summary>
        public string? Description { get; set; }
    }
}