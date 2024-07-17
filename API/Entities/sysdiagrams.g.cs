using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECODB1st2024Jul17.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a sysdiagrams entity with essential details
    /// </summary>
    public class sysdiagrams
    {
        /// <summary>
        /// Required field name of the sysdiagrams 
        /// </summary>
        [Required]
        public string name { get; set; }

        /// <summary>
        /// Required field principal_id of the sysdiagrams 
        /// </summary>
        [Required]
        public int principal_id { get; set; }

        /// <summary>
        /// Primary key for the sysdiagrams 
        /// </summary>
        [Key]
        [Required]
        public int diagram_id { get; set; }
        /// <summary>
        /// version of the sysdiagrams 
        /// </summary>
        public int? version { get; set; }
        /// <summary>
        /// definition of the sysdiagrams 
        /// </summary>
        public byte[]? definition { get; set; }
    }
}