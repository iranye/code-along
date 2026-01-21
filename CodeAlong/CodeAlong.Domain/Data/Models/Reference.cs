namespace CodeAlong.Domain.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reference
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }

        [StringLength(5000)]
        public string? Description { get; set; }
    }
}
