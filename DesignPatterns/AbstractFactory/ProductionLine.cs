using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.AbstractFactory
{
    class ProductionLine
    {
    }

    public interface IProductionLine
    {
        IVehicle CreateAVehicle();
        IEngine CreateAEngine();
    }

    class JapaneseManufacturer : IProductionLine
    {
        public IEngine CreateAEngine()
        {
            return new TwoLiter();
        }

        public IVehicle CreateAVehicle()
        {
            return new Car();
        }
    }


    class BritishManufacturer : IProductionLine
    {
        public IEngine CreateAEngine()
        {
            return new OneLiter();
        }

        public IVehicle CreateAVehicle()
        {
            return new Motorcycle();
        }
    }


    public interface IVehicle
    {
        string Drive(IEngine engine);
    }

    class Car : IVehicle
    {
        public string Drive(IEngine engine)
        {
            return "This is a car";
        }
    }

    class Motorcycle : IVehicle
    {
        public string Drive(IEngine engine)
        {
            return "This is a motorcycle";
        }
    }


    public interface IEngine
    {
        string Start();
    }

    class OneLiter : IEngine
    {
        public string Start()
        {
            return "This is a one liter engine";
        }
    }

    class TwoLiter : IEngine
    {
        public string Start()
        {
            return "This is a two liter engine";
        }
    }


    class Client
    {
        public void Main()
        {
            ClientMethod(new JapaneseManufacturer());
            Console.WriteLine();

            ClientMethod(new BritishManufacturer());
        }

        public void ClientMethod(IProductionLine productionLine)
        {
            var car = productionLine.CreateAVehicle();
            var engine = productionLine.CreateAEngine();

            Console.WriteLine(engine.Start());
            Console.WriteLine(car.Drive(engine));
        }
    }

}
