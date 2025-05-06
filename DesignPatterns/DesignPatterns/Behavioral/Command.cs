using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Command Interface
interface ICommand
{
    void Execute();
    void Undo();
}

// Receiver - The actual business logic of Order Processing
class Order
{
    private string _orderId;
    public Order(string orderId) { _orderId = orderId; }

    public void PlaceOrder() => Console.WriteLine($"Order {_orderId} has been placed.");
    public void CancelOrder() => Console.WriteLine($"Order {_orderId} has been cancelled.");
    public void ShipOrder() => Console.WriteLine($"Order {_orderId} has been shipped.");
}

// Concrete Command for Placing an Order
class PlaceOrderCommand : ICommand
{
    private Order _order;
    public PlaceOrderCommand(Order order) { _order = order; }

    public void Execute() => _order.PlaceOrder();
    public void Undo() => _order.CancelOrder();
}

// Concrete Command for Shipping an Order
class ShipOrderCommand : ICommand
{
    private Order _order;
    public ShipOrderCommand(Order order) { _order = order; }

    public void Execute() => _order.ShipOrder();
    public void Undo() => Console.WriteLine($"Shipping undone for Order {_order}");
}

// Concrete Command for Cancelling an Order
class CancelOrderCommand : ICommand
{
    private Order _order;
    public CancelOrderCommand(Order order) { _order = order; }

    public void Execute() => _order.CancelOrder();
    public void Undo() => _order.PlaceOrder();
}

// Invoker - Manages command execution
class OrderProcessor
{
    private Stack<ICommand> commandHistory = new Stack<ICommand>();

    public void ProcessCommand(ICommand command)
    {
        command.Execute();
        commandHistory.Push(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            ICommand lastCommand = commandHistory.Pop();
            lastCommand.Undo();
        }
        else
        {
            Console.WriteLine("No commands to undo.");
        }
    }
}

