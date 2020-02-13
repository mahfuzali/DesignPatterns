using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioural.Strategy
{
    /* Client that can use the algorithms above interchangeably 
     *
     * Context: This is the client application that performs the decision making for which strategy should be used 
     * and uses the Strategy interface (which is referring to a ConcreteStrategy object) to perform the operations
    */
    public abstract class Car
    {
        private IBrakeBehaviour _brakeBehaviour;
        private IPower _power;

        public Car() { }

        public Car(IBrakeBehaviour brake, IPower power) {
            _brakeBehaviour = brake;
            _power = power;
        }

        public void ApplyBrake() 
        {
            _brakeBehaviour.Brake();
        }

        public void Acclerate() 
        {
            _power.Power();
        }

        public void setBrakeBehaviour(IBrakeBehaviour brake) {
            this._brakeBehaviour = brake;
        }

        public void setAccelerateBehaviour(IPower power)
        {
            this._power = power;
        }

    }

    // ConcreteContext
    public class Hatchback: Car 
    {
        private IDoors _doors;

        public Hatchback() { }

        public Hatchback(IBrakeBehaviour brake, IPower power, IDoors doors) : base(brake, power)  {
            _doors = doors;
        }

        public void setDoors(IDoors doors)
        {
            this._doors = doors;
        }

        public void PutDoors()
        {
            _doors.Doors();
        }
    }

    // ConcreteContext
    public class SUV : Car
    {
        private IDoors _doors;

        public SUV() { }

        public SUV(IBrakeBehaviour brake, IPower power, IDoors doors) : base(brake, power)
        {
            _doors = doors;
        }

        public void setDoors(IDoors doors)
        {
            this._doors = doors;
        }

        public void PutDoors()
        {
            _doors.Doors();
        }
    }


    /* Encapsulated family of Algorithms
     * Interface and its implementations
     */
    // Strategy: This is the interface common to all algorithms. Context uses this interface to perform the operations.
    public interface IBrakeBehaviour 
    {
        public void Brake();
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class ABSBrake : IBrakeBehaviour
    {
        public void Brake()
        {
            Console.WriteLine("ABS brake applied");
        }
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class ManualBrake : IBrakeBehaviour
    {
        public void Brake()
        {
            Console.WriteLine("Manual brake applied");
        }
    }

    /* Encapsulated family of Algorithms
     * Interface and its implementations
     */
    // Strategy: This is the interface common to all algorithms. Context uses this interface to perform the operations.
    public interface IPower
    {
        public void Power();
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class EnginePower : IPower
    {
        public void Power()
        {
            Console.WriteLine("Accelerate using internal combustion engine");
        }
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class ElectricPower : IPower
    {
        public void Power()
        {
            Console.WriteLine("Accelerate using electronic motor");
        }
    }

    /* Encapsulated family of Algorithms
     * Interface and its implementations
     */
    // Strategy: This is the interface common to all algorithms. Context uses this interface to perform the operations.
    public interface IDoors
    {
        public void Doors();
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class TwoDoor : IDoors
    {
        public void Doors()
        {
            Console.WriteLine("Two doors car"); 
        }
    }

    // ConcreteStrategy: This is the class that implements the actual algorithm.
    public class FourDoor : IDoors
    {
        public void Doors()
        {
            Console.WriteLine("Four doors car"); 
        }
    }


    public class CarDealer {
        public void Main() {
            Hatchback hatchback = new Hatchback();
            hatchback.setBrakeBehaviour(new ManualBrake());
            hatchback.setAccelerateBehaviour(new ElectricPower());
            hatchback.setDoors(new TwoDoor());

            hatchback.ApplyBrake();
            hatchback.Acclerate();
            hatchback.PutDoors();

            SUV suv = new SUV();
            suv.setBrakeBehaviour(new ABSBrake());
            suv.setAccelerateBehaviour(new EnginePower());
            suv.setDoors(new FourDoor());

            suv.ApplyBrake();
            suv.Acclerate();
            suv.PutDoors();
        }
    }
}
