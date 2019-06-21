using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class JobCategories
    {
        public Guid Id { get; set; }
        public string CategoriesName { get; set; }
        public string Icon_Category { get; set; }
        public int Available_Jobs { get; set; }
    }
}