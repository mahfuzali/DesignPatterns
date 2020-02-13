using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioural.Command
{
    public interface IDevice
    {
        void On();
        void Off();
        void volumeUp();
        void volumeDown();
    }

    // Receiver: It contains the real operational logic that need to be performed on the data. 
    public class Television : IDevice
    {
        public void Off()
        {
            Console.WriteLine("TV is off");
        }

        public void On()
        {
            Console.WriteLine("TV is on");
        }

        public void volumeDown()
        {
            Console.WriteLine("Volume is down");
        }

        public void volumeUp()
        {
            Console.WriteLine("Volume is up");
        }
    }

    // Command: This is an interface for executing an action
    public interface IExecuteCommand
    {
        void Execute();
        void UnExecute();
    }

    // ConcreteCommand: This object specifies the binding between a Receiver/action taker and an action invoker. This object is responsible for executing corresponding operationon Receiver.
    public class TurnTVOnCommand : IExecuteCommand
    {
        private IDevice _tv;

        public TurnTVOnCommand(IDevice tv) 
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.On();
        }

        public void UnExecute()
        {
            _tv.Off();
        }
    }

    public class TurnTVOffCommand : IExecuteCommand
    {
        private IDevice _tv;

        public TurnTVOffCommand(IDevice tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.Off();
        }

        public void UnExecute()
        {
            _tv.On();
        }
    }

    // Invoker: It will use Command object to carry out the request
    public class DeviceButton 
    {
        private IExecuteCommand _command;

        public DeviceButton(IExecuteCommand command) 
        {
            _command = command;
        }

        public void Press() {
            _command.Execute();
        }

        public void UndoPress()
        {
            _command.UnExecute();
        }
    }

    // Client: creates a ConcreteCommand object and sets its receiver
    public class Client 
    {
        public void Main() 
        {
            IDevice television = new Television();

            TurnTVOnCommand turnTVOnCommand = new TurnTVOnCommand(television);

            DeviceButton onPress = new DeviceButton(turnTVOnCommand);
            onPress.Press();
        }
    }

}
