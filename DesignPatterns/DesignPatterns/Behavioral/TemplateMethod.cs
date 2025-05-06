using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Abstract Class - Defines the Template Method
abstract class PaymentProcessor
{
    // Template Method
    public void ProcessPayment()
    {
        Authenticate();
        PerformTransaction();
        SendConfirmation();
    }

    // Common steps (implemented in base class)
    private void Authenticate() => Console.WriteLine("Authenticating payment...");

    // Step to be customized by subclasses
    protected abstract void PerformTransaction();

    // Common step (can be overridden optionally)
    protected virtual void SendConfirmation() => Console.WriteLine("Sending payment confirmation...");
}


// Concrete Implementation: PayPal Payment
class GPayPayment : PaymentProcessor
{
    protected override void PerformTransaction()
    {
        Console.WriteLine("Processing payment via Google Pay...");
    }
}

// Concrete Implementation: Bank Transfer Payment
class BankTransferPayment : PaymentProcessor
{
    protected override void PerformTransaction()
    {
        Console.WriteLine("Processing payment via Bank Transfer...");
    }

    // Overriding confirmation step
    protected override void SendConfirmation()
    {
        Console.WriteLine("Sending confirmation via SMS for Bank Transfer.");
    }
}

