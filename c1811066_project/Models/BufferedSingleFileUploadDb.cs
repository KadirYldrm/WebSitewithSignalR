
using System.ComponentModel.DataAnnotations;
using c1811066_project.Models;
namespace c1811066_project.Models

{
    public class BufferedSingleFileUploadDb
    {
        [Required]
        [Display(Name = "Profile Picture")]
        public IFormFile? FormFile { get; set; }
    }
}
