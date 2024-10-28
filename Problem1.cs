/*
 ******* Problem 1 *******
 You are developing a payment processing system that needs to support multiple payment
 methods (e.g., credit card, PayPal, cryptocurrency). The system should allow for easy addition
 of new payment methods without modifying the existing code structure.

1. Identify the design pattern(s) you would use to implement this system.
--  Factory Design Pattern

2. Describe why you chose that pattern and how it would benefit the application.
--  I chose the Factory Design Pattern to implement the payment processing system because it provides 
    a flexible way to create different payment method instances without tightly coupling the client code 
    to specific implementations. This pattern adheres to the Open/Closed Principle, allowing us to add 
    new payment methods with minimal modifications to the existing code.

    Benefits of the Factory Pattern in This Context:
    i) Encapsulation of Object Creation: The factory encapsulates the logic for creating payment method instances, 
    simplifying the client code and making it easier to manage.

    ii) Scalability: Adding a new payment method only requires adding a new class that implements the payment method 
    interface and adding it to the factory. This makes the code easily extendable as new payment methods are introduced.

    iii) Simplified Client Code: The client does not need to understand the details of each payment method 
    implementation. It simply requests a payment method from the factory, making the overall system easier 
    to maintain.

 */

namespace Problem1
{
    // Defined the PaymentMethod interface for all payment types
    public interface IPaymentMethod
    {
        void ProcessPayment(decimal amount);
    }

    // Implemented different payment methods as classes
    public class CreditCardPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing credit card payment of " + amount);
        }
    }

    public class PayPalPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing PayPal payment of " + amount);
        }
    }

    public class CryptoPayment : IPaymentMethod
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing cryptocurrency payment of " + amount);
        }
    }

    // Implementing the Factory to create instances of payment methods
    public static class PaymentMethodFactory
    {
        public static IPaymentMethod CreatePaymentMethod(string type)
        {
            switch (type)
            {
                case "CreditCard":
                    return new CreditCardPayment();
                case "PayPal":
                    return new PayPalPayment();
                case "Crypto":
                    return new CryptoPayment();
                default:
                    throw new ArgumentException("Invalid payment method type.");
            }
        }
    }

    // PaymentProcessor to get the appropriate payment method
    public class PaymentProcessor
    {
        private readonly IPaymentMethod _paymentMethod;

        public PaymentProcessor(string paymentType)
        {
            // Use the factory to create the desired payment method
            _paymentMethod = PaymentMethodFactory.CreatePaymentMethod(paymentType);
        }

        public void Process(decimal amount)
        {
            _paymentMethod.ProcessPayment(amount);
        }
    }

    class Problem1
    {
        static void Main()
        {
            var processor = new PaymentProcessor("PayPal");
            processor.Process(100.00m); // Processes payment via PayPal
        }
    }

}
