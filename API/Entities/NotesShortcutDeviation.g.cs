using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a notesshortcutdeviation entity with essential details
    /// </summary>
    public class NotesShortcutDeviation
    {
        /// <summary>
        /// Foreign key referencing the Tenant to which the NotesShortcutDeviation belongs 
        /// </summary>
        [Required]
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Tenant
        /// </summary>
        [ForeignKey("TenantId")]
        public Tenant? TenantId_Tenant { get; set; }

        /// <summary>
        /// Primary key for the NotesShortcutDeviation 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key referencing the NotesShortcut to which the NotesShortcutDeviation belongs 
        /// </summary>
        [Required]
        public Guid NotesShortcut { get; set; }

        /// <summary>
        /// Navigation property representing the associated NotesShortcut
        /// </summary>
        [ForeignKey("NotesShortcut")]
        public NotesShortcut? NotesShortcut_NotesShortcut { get; set; }

        /// <summary>
        /// Foreign key referencing the User to which the NotesShortcutDeviation belongs 
        /// </summary>
        [Required]
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("CreatedBy")]
        public User? CreatedBy_User { get; set; }

        /// <summary>
        /// Required field CreatedOn of the NotesShortcutDeviation 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Required field DeviationType of the NotesShortcutDeviation 
        /// </summary>
        [Required]
        public byte DeviationType { get; set; }
        /// <summary>
        /// Foreign key referencing the NotesShortcut to which the NotesShortcutDeviation belongs 
        /// </summary>
        public Guid? ReplacedNotesShortcut { get; set; }

        /// <summary>
        /// Navigation property representing the associated NotesShortcut
        /// </summary>
        [ForeignKey("ReplacedNotesShortcut")]
        public NotesShortcut? ReplacedNotesShortcut_NotesShortcut { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the NotesShortcutDeviation belongs 
        /// </summary>
        public Guid? UpdatedBy { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UpdatedBy")]
        public User? UpdatedBy_User { get; set; }

        /// <summary>
        /// UpdatedOn of the NotesShortcutDeviation 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// Foreign key referencing the User to which the NotesShortcutDeviation belongs 
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Navigation property representing the associated User
        /// </summary>
        [ForeignKey("UserId")]
        public User? UserId_User { get; set; }
    }
}