using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        public string ImageURL { get; set; }
        public DateTime Datepublished { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}