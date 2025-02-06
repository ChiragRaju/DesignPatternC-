using System;

namespace DesignPattern
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 2.00;
    }

    public abstract class CoffeeDecoratorPattern : ICoffee
    {
        protected readonly ICoffee _coffee; // Changed to protected

        protected CoffeeDecoratorPattern(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual double GetCost() => _coffee.GetCost();
        public virtual string GetDescription() => _coffee.GetDescription();
    }

    public class MilkDecorator : CoffeeDecoratorPattern
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override double GetCost() => base.GetCost() + 0.50;
        public override string GetDescription() => base.GetDescription() + ", Milk";
    }

    public class SugarDecorator : CoffeeDecoratorPattern
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => base.GetDescription() + ", Sugar";
        public override double GetCost() => base.GetCost() + 0.20;
    }

    class Program
    {
        public static void Main(string[] args)
        {
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

            // Add Milk
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");

            // Add Sugar on top of Milk
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} : ${coffee.GetCost()}");
        }
    }
}
