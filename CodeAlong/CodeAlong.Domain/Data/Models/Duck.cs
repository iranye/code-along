namespace CodeAlong.Domain.Data.Models
{
    public interface IFlyBehavior
    {
        public string Fly();
    }

    public class FlyWithWings : IFlyBehavior
    {
        public string Fly()
        {
            return "Flying with wings";
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public string Fly()
        {
            return "I cannot fly";
        }
    }

    public class FlyRocketPowered : IFlyBehavior
    {
        public string Fly()
        {
            return "I'm flying with a rocket!";
        }
    }

    public interface IQuackBehavior
    {
        public string Quack();
    }

    public class QuackDefault : IQuackBehavior
    {
        public string Quack()
        {
            return "Quack Quack";
        }
    }

    public class QuackMute : IQuackBehavior
    {
        public string Quack()
        {
            return "<< Silence >>";
        }
    }

    public class QuackSqueak : IQuackBehavior
    {
        public string Quack()
        {
            return "Squeak Squeak";
        }
    }

    public abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;

        protected Duck()
        {
            flyBehavior = new FlyWithWings();
            quackBehavior = new QuackDefault();
        }

        public string PerformFly()
        {
            return flyBehavior.Fly();
        }

        public string PerformQuack()
        {
            return quackBehavior.Quack();
        }

        public void SetFlyBehavior(IFlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void SetQuackBehavior(IQuackBehavior qb)
        {
            quackBehavior = qb;
        }
    }

    public class  MallardDuck : Duck
    {

    }

    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new QuackMute();
        }
    }
}
