using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class Notification
    {
        [Key]
        public Guid Guid { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public bool Is_New { get; set; }
    }
}