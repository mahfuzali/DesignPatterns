using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.AbstractFactory
{

    // AbstractProduct
    public interface ILaptop
    {
        string Name();
    }

    // AbstractProduct
    public interface ISmartPhone
    {
        string Name();
    }

    // Product
    public class MacbookPro : ILaptop
    {
        public string Name()
        {
            return "Macbook Pro";
        }
    }

    // Product
    public class NotePad : ILaptop
    {
        public string Name()
        {
            return "NotePad";
        }
    }

    // Product
    public class IPhone : ISmartPhone
    {
        public string Name()
        {
            return "IPhone";
        }
    }

    // Product
    public class Galaxy : ISmartPhone
    {
        public string Name()
        {
            return "Galaxy";
        }
    }

    // AbstractFactory
    public interface IDeviceFactory
    {
        ISmartPhone GetSmartPhone();
        ILaptop GetLaptop();
    }

    // ConcreteFactory
    public class AppleFactory : IDeviceFactory
    {
        public ILaptop GetLaptop()
        {
            return new MacbookPro();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new IPhone();
        }
    }

    // ConcreteFactory
    public class SamsungFactory : IDeviceFactory
    {
        public ILaptop GetLaptop()
        {
            return new NotePad();
        }

        public ISmartPhone GetSmartPhone()
        {
            return new Galaxy();
        }
    }

    public enum Manufacturers 
    { 
        SAMSUNG,
        APPLE
    }

    // Client
    public class ElectronicStoreClient {

        public IDeviceFactory CheckProducts(Manufacturers manufacturer) {
            IDeviceFactory deviceFactory = null;

            switch (manufacturer)
            {
                case Manufacturers.SAMSUNG:
                    deviceFactory = new SamsungFactory();
                    break;
                case Manufacturers.APPLE:
                    deviceFactory = new AppleFactory();
                    break;
            }

            return deviceFactory;
        }

        public void Main() {
            ElectronicStoreClient e = new ElectronicStoreClient();
            IDeviceFactory apple = e.CheckProducts(Manufacturers.APPLE);
            
            ILaptop macbookPro = apple.GetLaptop();
            ISmartPhone smartPhone = apple.GetSmartPhone();

            IDeviceFactory samsung = e.CheckProducts(Manufacturers.SAMSUNG);
            ILaptop galaxy = samsung.GetLaptop();
            ISmartPhone notebook = samsung.GetSmartPhone();
        }
    }
}
