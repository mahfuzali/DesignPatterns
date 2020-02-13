using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.Decorator
{
    // Component 
    public abstract class Beverage
    {
        public string description { get; private set; }
        public string setDescription(string desc) => description = desc;
        public abstract double cost();
    }

    // ConcreteComponent 
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            base.setDescription("House Blend Coffee");
        }

        public override double cost() => .89;
    }

    // ConcreteComponent 
    public class Espresso : Beverage
    {
        public Espresso()
        {
            base.setDescription("Espresso");
        }

        public override double cost() => 1.99;
    }

    // ConcreteComponent 
    public class Decaf: Beverage
    {
        public Decaf()
        {
            base.setDescription("Decaf Coffee");
        }

        public override double cost() => 1.05;
    }

    // Decorator 
    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage _beverage;

        public CondimentDecorator(Beverage beverage)
        {
            _beverage = beverage;
        }
    }

    // ConcreteDecorator 
    public class Milk : CondimentDecorator
    {
        public Milk(Beverage beverage) : base(beverage) 
        {
            base.setDescription(base.description + " with Mocha");
        }

        public override double cost() => _beverage.cost() + .10;
    }

    // ConcreteDecorator 
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage) 
        {
            base.setDescription(base.description + " with Milk");
        }

        public override double cost() => _beverage.cost() + .20;
    }

    public class CoffeeStore 
    { 
        public void Main()
        {
            Beverage espresso = new Espresso();
            Console.WriteLine(espresso.description + " £" + espresso.cost());

            Beverage houseBlend = new HouseBlend();
            houseBlend = new Milk(houseBlend);
            Console.WriteLine(houseBlend.description + " £" + houseBlend.cost());
        }
    }
}
