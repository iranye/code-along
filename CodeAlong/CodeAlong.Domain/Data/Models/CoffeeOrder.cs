using System.Collections.ObjectModel;

namespace CodeAlong.Domain.Data.Models
{
    public class CoffeeOrder
    {
        public ObservableCollection<Beverage> Beverages { get; set; } = new ObservableCollection<Beverage>();
    }
}
