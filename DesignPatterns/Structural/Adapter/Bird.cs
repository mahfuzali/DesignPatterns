using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.Adapter
{

    // The Target defines the domain-specific interface used by the client code.
    public interface IToyCar
    {
        string move();
        string stop();
    }
    
    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    public class CarAdapter : IToyCar
    {
        private readonly ICar _car;

        public CarAdapter(ICar car)
        {
            car = _car;
        }

        public string move() => _car.accelerate();

        public string stop() => _car.brake();
    }


    public interface ICar
    {
        string accelerate();
        string brake();
    }

    // The Adaptee contains some useful behavior, but its interface is
    // incompatible with the existing client code. The Adaptee needs some
    // adaptation before the client code can use it.
    public class Car : ICar
    {
        public string accelerate() => "Accelerating";

        public string brake() => "Braking";
    }
    
    public class Client 
    {
        public void Main() 
        {
            // Adaptee
            ICar car = new Car();
            
            // Target 
            IToyCar toycar = new CarAdapter(car);

            // Adaptee interface is incompatible with the client.
            // But with adapter client can call it's method.
            toycar.move();
            toycar.stop();

        }
    }
}
