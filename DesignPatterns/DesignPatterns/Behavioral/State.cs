using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// State Interface
interface ITrafficLightState
{
    void Handle(TrafficLight context);
}

// Concrete States
class RedState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Red Light - Stop");
        context.SetState(new GreenState());
    }
}

class GreenState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Green Light - Go");
        context.SetState(new YellowState());
    }
}

class YellowState : ITrafficLightState
{
    public void Handle(TrafficLight context)
    {
        Console.WriteLine("Yellow Light - Slow Down");
        context.SetState(new RedState());
    }
}

// Context
class TrafficLight
{
    private ITrafficLightState _state;
    public TrafficLight() { _state = new RedState(); }
    public void SetState(ITrafficLightState state) { _state = state; }
    public void ChangeLight() => _state.Handle(this);
}

