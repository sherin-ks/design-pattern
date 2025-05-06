using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Mediator Interface
interface IChatMediator
{
    void SendMessage(string message, User user);
    void RegisterUser(User user);
}

// Concrete Mediator
class ChatMediator : IChatMediator
{
    private List<User> _users = new();
    public void RegisterUser(User user) => _users.Add(user);
    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.ReceiveMessage(message);
        }
    }
}

// Colleague
class User
{
    private string _name;
    private IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        _name = name;
        _mediator = mediator;
    }

    public void SendMessage(string message) => _mediator.SendMessage(message, this);
    public void ReceiveMessage(string message) => Console.WriteLine($"{_name} received: {message}");
}

