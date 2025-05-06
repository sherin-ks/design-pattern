using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Abstract Handler
abstract class SupportHandler
{
    protected SupportHandler nextHandler;

    public void SetNext(SupportHandler next)
    {
        nextHandler = next;
    }

    public abstract void HandleRequest(string issueType);
}

// Concrete Handlers
class Level1Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "Basic")
            Console.WriteLine("Level 1 Support: Issue resolved.");
        else if (nextHandler != null)
            nextHandler.HandleRequest(issueType);
    }
}

class Level2Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        if (issueType == "Advanced")
            Console.WriteLine("Level 2 Support: Issue resolved.");
        else if (nextHandler != null)
            nextHandler.HandleRequest(issueType);
    }
}

class Level3Support : SupportHandler
{
    public override void HandleRequest(string issueType)
    {
        Console.WriteLine("Level 3 Support: Handling all unresolved issues.");
    }
}

