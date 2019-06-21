using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public User Poster { get; set; }
        public Guid PosterId { get; set; }
        public JobCategories Categories { get; set; }
        public Guid CategoriesId { get; set; }
        public string Location { get; set; }
        public string Skill_Requirements { get; set; }
        public string Company { get; set; }
        public string Icon_Company { get; set; }
    }
}