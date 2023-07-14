using System;
using System.Collections.Generic;

namespace c1811066_project.Models
{
    public partial class UserRating
    {
        public int Id { get; set; }
        public int? Rating { get; set; }
        public string? Userid { get; set; }
        public string? Whorated { get; set; }
    }
}
