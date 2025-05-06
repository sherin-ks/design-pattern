using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural;

// Implementor: Payment Gateway Interface
public interface IPaymentGateway
{
    void ProcessPayment(string account, decimal amount);
}

// Concrete Implementor: PayPal Payment Gateway
public class PayPalGateway : IPaymentGateway
{
    public void ProcessPayment(string account, decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} through PayPal for account: {account}");
    }
}

// Concrete Implementor: Stripe Payment Gateway
public class StripeGateway : IPaymentGateway
{
    public void ProcessPayment(string account, decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} through Stripe for account: {account}");
    }
}

// Abstraction: Payment Method
public abstract class Payment
{
    protected IPaymentGateway _paymentGateway;

    protected Payment(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public abstract void MakePayment(string account, decimal amount);
}

// Refined Abstraction: Credit Card Payment
public class CreditCardPayment : Payment
{
    public CreditCardPayment(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void MakePayment(string account, decimal amount)
    {
        Console.WriteLine("Initiating Credit Card Payment...");
        _paymentGateway.ProcessPayment(account, amount);
    }
}

// Refined Abstraction: Bank Transfer Payment
public class BankTransferPayment : Payment
{
    public BankTransferPayment(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void MakePayment(string account, decimal amount)
    {
        Console.WriteLine("Initiating Bank Transfer Payment...");
        _paymentGateway.ProcessPayment(account, amount);
    }
}


