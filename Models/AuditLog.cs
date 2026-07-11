using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hogwartz_App.Models
{
    public partial class AuditLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LogMessage { get; set; } = null!;
        
        public DateTime? DateTrigerred { get; set; }
    }

}