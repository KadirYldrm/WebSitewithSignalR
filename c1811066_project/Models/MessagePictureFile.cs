using System.ComponentModel.DataAnnotations;

namespace c1811066_project.Models
{
    public class MessagePictureFile
    {
        [Display(Name="Picture")]
        public IFormFile? FormFile { get; set; }

    }
}
