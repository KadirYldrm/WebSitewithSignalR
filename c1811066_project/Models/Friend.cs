using System;
using System.Collections.Generic;

namespace c1811066_project.Models
{
    public partial class Friend
    {
        public int Id { get; set; }
        public string? Userid { get; set; }
        public string? Friendid { get; set; }
        public bool? Aprrove { get; set; }
    }
}
