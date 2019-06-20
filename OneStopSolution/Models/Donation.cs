using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneStopSolution.Models
{
    public class Donation
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Money { get; set; }
        public User User { get; set; }
        public User UserId { get; set; }

    }
}