using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Strategy Interface
interface IPaymentStrategy
{
    void Pay(int amount);
}

// Concrete Strategies
class CreditCardPayment : IPaymentStrategy
{
    public void Pay(int amount) => Console.WriteLine($"Paid {amount} using Credit Card.");
}

class PayPalPayment : IPaymentStrategy
{
    public void Pay(int amount) => Console.WriteLine($"Paid {amount} using PayPal.");
}

// Context
class ShoppingCart
{
    private IPaymentStrategy _paymentStrategy;

    public void SetPaymentMethod(IPaymentStrategy paymentStrategy) => _paymentStrategy = paymentStrategy;
    public void Checkout(int amount) => _paymentStrategy.Pay(amount);
}


