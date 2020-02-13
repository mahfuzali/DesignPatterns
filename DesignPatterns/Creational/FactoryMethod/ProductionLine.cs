using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    // This is the Creator from the UML
    public abstract class ProductionLine
    {
        public abstract IVehicle FactoryMethod();

        public string FinalProduct()
        {
            var product = FactoryMethod();

            var result = product.Drive();

            return result;
        }
    }

    // This is a ConcreteCreator from the UML
    internal class CarLine : ProductionLine
    {
        public override IVehicle FactoryMethod()
        {
            return new Car();
        }
    }

    // This is a ConcreteCreator from the UML
    internal class MotorcycleLine : ProductionLine
    {
        public override IVehicle FactoryMethod()
        {
            return new Motorcycle();
        }
    }

    // This is the Product from the UML
    public interface IVehicle
    {
        string Drive();
    }

    // This is a ConcreteProduct from the UML
    internal class Car : IVehicle
    {
        public string Drive()
        {
            return "This is a car";
        }
    }

    // This is a ConcreteProduct from the UML
    internal class Motorcycle : IVehicle
    {
        public string Drive()
        {
            return "This is a motorcycle";
        }
    }

    public enum VehicleType { CAR, MOTORCYCLE }

    public class Manufacturer
    {
        public void Main()
        {

            VehicleType input = VehicleType.CAR;

            if (input == VehicleType.CAR)
            {
                ClientCode(new CarLine());
            }
            else if (input == VehicleType.MOTORCYCLE) 
            { 
                ClientCode(new MotorcycleLine());
            }

            /*
            IVehicle vehicle = null;
            switch (input)
            {
                case VehicleType.CAR:
                    vehicle = new CarLine().FactoryMethod();
                    break;
                case VehicleType.MOTORCYCLE:
                    vehicle = new MotorcycleLine().FactoryMethod();
                    break;
            }

            vehicle.Drive();
            */
        }

        public void ClientCode(ProductionLine productionLine)
        {
            Console.WriteLine(productionLine.FinalProduct());
        }
    }
    
}
