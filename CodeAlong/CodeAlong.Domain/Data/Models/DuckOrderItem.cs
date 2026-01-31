using System.ComponentModel;

namespace CodeAlong.Domain.Data.Models
{
    public class DuckOrderItem : INotifyPropertyChanged
    {
        public string DuckType { get; set; }
        public IFlyBehavior FlyBehavior { get; set; }
        public IQuackBehavior QuackBehavior { get; set; }

        public string FlyInfo => $"Fly: {FlyBehavior.Fly()}";
        public string QuackInfo => $"Quack: {QuackBehavior.Quack()}";

        public DuckOrderItem(string duckType, IFlyBehavior flyBehavior, IQuackBehavior quackBehavior)
        {
            DuckType = duckType;
            FlyBehavior = flyBehavior;
            QuackBehavior = quackBehavior;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
