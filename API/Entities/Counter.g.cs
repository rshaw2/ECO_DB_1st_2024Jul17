using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a counter entity with essential details
    /// </summary>
    public class Counter
    {
        /// <summary>
        /// Initializes a new instance of the Counter class.
        /// </summary>
        public Counter()
        {
            IsStandard = false;
            Active = new Guid("00000000-0000-0000-0000-000000000000");
        }

        /// <summary>
        /// Required field TenantId of the Counter 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Counter 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field EntityCode of the Counter 
        /// </summary>
        [Required]
        public string EntityCode { get; set; }

        /// <summary>
        /// Required field EntitySubTypeCode of the Counter 
        /// </summary>
        [Required]
        public string EntitySubTypeCode { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the Counter belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the Counter 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field IsStandard of the Counter 
        /// </summary>
        [Required]
        public bool IsStandard { get; set; }
        /// <summary>
        /// ParentId of the Counter 
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// UpdatedOn of the Counter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the Counter belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }
        /// <summary>
        /// InitialCounterN of the Counter 
        /// </summary>
        public int? InitialCounterN { get; set; }
        /// <summary>
        /// InitialCounterO of the Counter 
        /// </summary>
        public int? InitialCounterO { get; set; }
        /// <summary>
        /// InitialCounterP of the Counter 
        /// </summary>
        public int? InitialCounterP { get; set; }

        /// <summary>
        /// CounterNUpdatedOn of the Counter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CounterNUpdatedOn { get; set; }

        /// <summary>
        /// CounterOUpdatedOn of the Counter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CounterOUpdatedOn { get; set; }

        /// <summary>
        /// CounterPUpdatedOn of the Counter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CounterPUpdatedOn { get; set; }
        /// <summary>
        /// SubTypeId of the Counter 
        /// </summary>
        public Guid? SubTypeId { get; set; }
        /// <summary>
        /// Code of the Counter 
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Name of the Counter 
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Description of the Counter 
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Pattern of the Counter 
        /// </summary>
        public string? Pattern { get; set; }
        /// <summary>
        /// CounterN of the Counter 
        /// </summary>
        public int? CounterN { get; set; }
        /// <summary>
        /// CounterO of the Counter 
        /// </summary>
        public int? CounterO { get; set; }
        /// <summary>
        /// CounterP of the Counter 
        /// </summary>
        public int? CounterP { get; set; }
        /// <summary>
        /// ResetCounterN of the Counter 
        /// </summary>
        public Guid? ResetCounterN { get; set; }
        /// <summary>
        /// ResetCounterO of the Counter 
        /// </summary>
        public Guid? ResetCounterO { get; set; }
        /// <summary>
        /// ResetCounterP of the Counter 
        /// </summary>
        public Guid? ResetCounterP { get; set; }
        /// <summary>
        /// EntityId of the Counter 
        /// </summary>
        public string? EntityId { get; set; }
        /// <summary>
        /// EntityObjectId of the Counter 
        /// </summary>
        public Guid? EntityObjectId { get; set; }
        /// <summary>
        /// Active of the Counter 
        /// </summary>
        public Guid? Active { get; set; }
    }
}