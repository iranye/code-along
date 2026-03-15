using System.ComponentModel.DataAnnotations;

namespace LogicSolver.Web.Models
{
    public class EntityMapperViewModel
    {
        [MaxLength(50), Required]
        public string EntityMainType { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string Entity02Type { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string Entity03Type { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string Entity04Type { get; set; } = string.Empty;
    }
}
