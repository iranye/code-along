using System.Collections.ObjectModel;

namespace CodeAlong.Domain.Data.Models
{
    public class DuckOrder
    {
        public ObservableCollection<DuckOrderItem> Ducks { get; set; } = new ObservableCollection<DuckOrderItem>();
    }
}
