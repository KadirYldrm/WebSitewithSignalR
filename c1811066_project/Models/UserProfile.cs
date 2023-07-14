using System;
using System.Collections.Generic;

namespace c1811066_project.Models
{
    public partial class UserProfile
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public byte[]? Picture { get; set; }
    }
}
