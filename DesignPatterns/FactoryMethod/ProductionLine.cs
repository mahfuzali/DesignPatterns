using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    abstract class ProductionLine
    {

        public abstract IVehicle FactoryMethod();

        public string FinalProduct()
        {
            var product = FactoryMethod();

            var result = product.Drive();

            return result;
        }
    }

    class CarLine : ProductionLine
    {
        public override IVehicle FactoryMethod()
        {
            return new Car();
        }
    }

    class MotorcycleLine : ProductionLine
    {
        public override IVehicle FactoryMethod()
        {
            return new Motorcycle();
        }
    }


    public interface IVehicle
    {
        string Drive();
    }

    class Car : IVehicle
    {
        public string Drive()
        {
            return "This is a car";
        }
    }

    class Motorcycle : IVehicle
    {
        public string Drive()
        {
            return "This is a motorcycle";
        }
    }


    class Manufacturer
    {
        public void Main()
        {
            ClientCode(new CarLine());
            ClientCode(new MotorcycleLine());
        }

        public void ClientCode(ProductionLine productionLine)
        {
            Console.WriteLine(productionLine.FinalProduct());
        }
    }
}
