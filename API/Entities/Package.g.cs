using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a package entity with essential details
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Initializes a new instance of the Package class.
        /// </summary>
        public Package()
        {
            Default = false;
            NumberOfUser = 4;
            SubscriptionUnit = 1;
        }

        /// <summary>
        /// Primary key for the Package 
        /// </summary>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Required field Name of the Package 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field Code of the Package 
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Required field Default of the Package 
        /// </summary>
        [Required]
        public bool Default { get; set; }

        /// <summary>
        /// Required field NumberOfUser of the Package 
        /// </summary>
        [Required]
        public short NumberOfUser { get; set; }
        /// <summary>
        /// SubscriptionUnit of the Package 
        /// </summary>
        public byte? SubscriptionUnit { get; set; }
    }
}