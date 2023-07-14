using System;
using System.Collections.Generic;

namespace c1811066_project.Models
{
    public partial class RatedUser
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public byte[] Picture { get; set; } = null!;
        public string AvgRating { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public bool IsRated { get; set; }
    }
}
