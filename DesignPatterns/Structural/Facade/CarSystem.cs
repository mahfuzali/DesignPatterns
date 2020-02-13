using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.Facade
{
    // The Facade class provides a simple interface to the complex logic of one
    // or several subsystems. The Facade delegates the client requests to the
    // appropriate objects within the subsystem. The Facade is also responsible
    // for managing their lifecycle. All of this shields the client from the
    // undesired complexity of the subsystem.
    public class Car
    {
        private Engine _engine;
        private Light _light;
        private Audio _audio;

        public Car(Engine engine, Light light, Audio audio) {
            _engine = engine;
            _light = light;
            _audio = audio;
        }

        // The Facade's methods are convenient shortcuts to the sophisticated
        // functionality of the subsystems. However, clients get only to a
        // fraction of a subsystem's capabilities.
        public void StartCar() 
        {
            _engine.start();
            _light.on();
            _audio.up();
        }

        public void StopCar()
        {
            _engine.stop();
            _light.off();
            _audio.down();
        }
    }

    // The Subsystem can accept requests either from the facade or client
    // directly. In any case, to the Subsystem, the Facade is yet another
    // client, and it's not a part of the Subsystem.
    public class Engine 
    {
        public string start() => "start";
        public string stop() => "stop";
    }

    public class Light
    {
        public string on() => "on";
        public string off() => "off";
    }

    public class Audio 
    {
        public string up() => "up";
        public string down() => "down";
    }


    // The client code works with complex subsystems through a simple
    // interface provided by the Facade. When a facade manages the lifecycle
    // of the subsystem, the client might not even know about the existence
    // of the subsystem. This approach lets you keep the complexity under
    // control.
    public class Driver 
    { 
        public void StartingMyCar(Car car)
        {
            car.StartCar();
        }

        public void StopingMyCar(Car car)
        {
            car.StopCar();
        }
    }
}
