using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FactoryMethod
{
    // This is the Product from the UML
    public interface IPaymentGateway {
        void MakePayment();
    }

    // This is a ConcreteProduct from the UML
    public class Amex : IPaymentGateway
    {
        public void MakePayment()
        {
            Console.WriteLine("Making a payment in AMEX");
        }
    }

    // This is a ConcreteProduct from the UML
    public class MasterCard : IPaymentGateway
    {
        public void MakePayment()
        {
            Console.WriteLine("Making a payment in MasterCard");
        }
    }

    // This is a ConcreteProduct from the UML
    public class Natwest : IPaymentGateway
    {
        public void MakePayment()
        {
            Console.WriteLine("Making a payment in Natwest");
        }
    }

    public enum CardType
    { 
        // Global
        AMEX,
        MASTERCARD,
        // UK
        NATWEST
    }

    // This is the Creator from the UML
    public class GlobalPaymentGateway
    {
        public virtual IPaymentGateway CreatePaymentGateway(CardType type) 
        {
            IPaymentGateway gateway = null;

            switch (type)
            {
                case CardType.AMEX:
                    gateway = new Amex();
                    break;
                case CardType.MASTERCARD:
                    gateway = new MasterCard();
                    break;
            }

            return gateway;
        }
    }

    // This is a ConcreteCreator from the UML
    public class UKPaymentGateway: GlobalPaymentGateway
    {
        public override IPaymentGateway CreatePaymentGateway(CardType type)
        {
            IPaymentGateway gateway = null;

            switch (type)
            {
                case CardType.NATWEST:
                    gateway = new Natwest();
                    break;
                default:
                    base.CreatePaymentGateway(type);
                    break;
            }

            return gateway;
        }
    }

    public class ClientStore {

        IPaymentGateway gateway = null;

        public void Transaction(CardType card)
        {
            UKPaymentGateway factory = new UKPaymentGateway();
            gateway = factory.CreatePaymentGateway(card);
            gateway.MakePayment();
        }
    }
}
