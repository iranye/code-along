using System.ComponentModel.DataAnnotations;

namespace LogicSolver.Web.Models
{
    public class EntityTypesViewModel
    {
        [MaxLength(50), Required]
        public string EntityFirst { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string EntitySecond { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string EntityThird { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string EntityFourth { get; set; } = string.Empty;

        public bool HasDupes
        {
            get
            {
                var values = new[] { EntityFirst, EntitySecond, EntityThird, EntityFourth };
                return values.Select(v => v.ToLowerInvariant()).Distinct().Count() < values.Length;
            }
        }
    }
}
