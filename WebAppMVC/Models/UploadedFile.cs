using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class UploadedFile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ContentType { get; set; } = string.Empty;

        public long FileSize { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
