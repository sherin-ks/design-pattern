using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.Structural;
using Directory = DesignPatterns.Structural.Directory;
using Document = DesignPatterns.Structural.Document;
using File = DesignPatterns.Structural.File;

namespace DesignPatterns;

public static class Program
{
    public static void Main(string[] args)
    {
        ShowMenu("Select Pattern:", new[]
        {
                "1. Creational Design Pattern",
                "2. Structural Design Pattern",
                "3. Behavioral Design Pattern"
            });

        if (int.TryParse(Console.ReadLine(), out int designPatternType))
        {
            switch (designPatternType)
            {
                case 1:
                    HandleCreationalPattern();
                    break;
                case 2:
                    HandleStructuralPattern();
                    break;
                case 3:
                    HandleBehavioralPattern();
                    break;
                default:
                    Console.WriteLine("Invalid design pattern type selected.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void HandleCreationalPattern()
    {
        ShowMenu("Select Creational Design Pattern:", new[]
        {
                "1. Singleton",
                "2. Factory",
                "3. Abstract Factory",
                "4. Builder",
                "5. Prototype"
            });

        if (int.TryParse(Console.ReadLine(), out int designPattern))
        {
            ExecuteCreationalPattern(designPattern);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void HandleStructuralPattern()
    {
        ShowMenu("Select Structural Design Pattern:", new[]
        {
                "1. Adapter",
                "2. Bridge",
                "3. Composite",
                "4. Decorator",
                "5. Facade",
                "6. Flyweight",
                "7. Proxy"
            });

        if (int.TryParse(Console.ReadLine(), out int designPattern))
        {
            ExecuteStructuralPattern(designPattern);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void HandleBehavioralPattern()
    {
        ShowMenu("Select Creational Design Pattern:", new[]
        {
                "1. Chain of Responsibility",
                "2. Command",
                "3. Observer",
                "4. Strategy",
                "5. Interpreter",
                "6. Iterator",
                "7. Mediator",
                "8. Memento",
                "9. State",
                "10. Visitor",
                "11. Template Method"
            });

        if (int.TryParse(Console.ReadLine(), out int designPattern))
        {
            ExecuteBehavioralPattern(designPattern);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void ShowMenu(string title, string[] options)
    {
        var sb = new StringBuilder();
        sb.AppendLine(title);
        foreach (var option in options)
        {
            sb.AppendLine(option);
        }
        Console.WriteLine(sb.ToString());
    }

    #region Creational
    private static void ExecuteCreationalPattern(int designPattern)
    {
        switch (designPattern)
        {
            case 1:
                ExecuteSingletonPattern();
                break;
            case 2:
                ExecuteFactoryPattern();
                break;
            case 3:
                ExecuteAbstractFactoryPattern();
                break;
            case 4:
                ExecuteBuilderPattern();
                break;
            case 5:
                ExecutePrototypePattern();
                break;
            default:
                Console.WriteLine("Invalid Creational Design Pattern selected.");
                break;
        }
    }

    private static void ExecuteSingletonPattern()
    {
        Singleton.Instance.ShowMessage();
    }

    private static void ExecuteFactoryPattern()
    {
        ShapeFactory factory = new CircleFactory();
        IShape shape = factory.CreateShape();
        shape.Draw();
    }

    private static void ExecuteAbstractFactoryPattern()
    {
        IGUIFactory guiFactory = new WindowsFactory();
        IButton button = guiFactory.CreateButton();
        ICheckbox checkbox = guiFactory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }

    private static void ExecuteBuilderPattern()
    {
        var director = new ReportDirector();
        var builder = new ReportBuilder();

        // Create a Financial Report
        Report financialReport = director.BuildFinancialReport(builder);
        financialReport.Display();

        Console.WriteLine();

        // Create an HR Report
        Report hrReport = director.BuildHRReport(builder);
        hrReport.Display();
    }

    private static void ExecutePrototypePattern()
    {
        var registry = new DocumentRegistry();

        var contractPrototype = new ContractDocument
        {
            PartyA = "Company A",
            PartyB = "Company B",
            Terms = "Payment within 30 days."
        };

        var reportPrototype = new ReportDocument
        {
            Title = "Annual Report",
            Content = "This report contains yearly performance data."
        };

        registry.RegisterDocument("Contract", contractPrototype);
        registry.RegisterDocument("Report", reportPrototype);

        var contract1 = (ContractDocument)registry.GetDocument("Contract");
        contract1.PartyA = "Company X";

        var report1 = (ReportDocument)registry.GetDocument("Report");
        report1.Title = "Quarterly Report";

        contract1.Display();
        Console.WriteLine();
        report1.Display();
    }
    #endregion

    #region Structural

    private static void ExecuteStructuralPattern(int designPattern)
    {
        switch (designPattern)
        {
            case 1:
                ExecuteAdapterPattern();
                break;
            case 2:
                ExecuteBridgePattern();
                break;
            case 3:
                ExecuteCompositePattern();
                break;
            case 4:
                ExecuteDecoratorPattern();
                break;
            case 5:
                ExecuteFacadePattern();
                break;
            case 6:
                ExecuteFlyweightPattern();
                break;
            case 7:
                ExecuteProxyPattern();
                break;

            default:
                Console.WriteLine("Invalid Structural Design Pattern selected.");
                break;
        }
    }

    private static void ExecuteAdapterPattern()
    {
        NLog nLog = new NLog();
        Serilog serilog = new Serilog();

        ILogger nLogLogger = new NLogAdapter(nLog);
        ILogger serilogLogger = new SerilogAdapter(serilog);

        Console.WriteLine("\nUsing NLog:");
        nLogLogger.LogInfo("This is an info message.");
        nLogLogger.LogError("This is an error message.");
        nLogLogger.LogWarning("This is a warning message.");

        Console.WriteLine("\nUsing Serilog:");
        serilogLogger.LogInfo("This is an info message.");
        serilogLogger.LogError("This is an error message.");
        serilogLogger.LogWarning("This is a warning message.");
    }

    private static void ExecuteBridgePattern()
    {
        // Using PayPal with Credit Card Payment
        IPaymentGateway paypalGateway = new PayPalGateway();
        Payment creditCardPayment = new Structural.CreditCardPayment(paypalGateway);
        creditCardPayment.MakePayment("user@example.com", 100.50m);

        // Using Stripe with Bank Transfer Payment
        IPaymentGateway stripeGateway = new StripeGateway();
        Payment bankTransferPayment = new BankTransferPayment(stripeGateway);
        bankTransferPayment.MakePayment("user@example.com", 250.75m);

    }

    private static void ExecuteCompositePattern()
    {
        var root = new Directory("Root");
        var file1 = new File("File1.txt");
        var file2 = new File("File2.txt");

        var subDir = new Directory("SubDirectory");
        var subFile = new File("SubFile.txt");

        root.Add(file1);
        root.Add(file2);
        root.Add(subDir);

        subDir.Add(subFile);

        root.Display();

    }

    public static void ExecuteDecoratorPattern()
    {
        ILoggerDecorator fileLogger = new FileLogger();

        // Add timestamp functionality
        ILoggerDecorator timestampLogger = new TimestampLogger(fileLogger);

        // Add database logging on top of timestamp logging
        ILoggerDecorator enhancedLogger = new DatabaseLogger(timestampLogger);

        // Use enhanced logger
        enhancedLogger.Log("This is a log entry.");

    }

    public static void ExecuteFacadePattern()
    {
        CloudResourceManager cloudManager = new();

        // Start an application
        cloudManager.StartApplication("App123");

        // Stop an application
        cloudManager.StopApplication("App123");

    }

    public static void ExecuteFlyweightPattern()
    {
        Document document = new();

        // Add characters with shared styles
        document.AddCharacter("H", 0, 0, "Arial", 12, "Black");
        document.AddCharacter("e", 10, 0, "Arial", 12, "Black");
        document.AddCharacter("l", 20, 0, "Arial", 12, "Black");
        document.AddCharacter("l", 30, 0, "Arial", 12, "Black");
        document.AddCharacter("o", 40, 0, "Arial", 12, "Black");

        // Render the document
        document.Render();

    }

    public static void ExecuteProxyPattern()
    {
        List<IFile> files = new()
        {
            new SecureFileProxy("Document1.txt", "User"),    // Restricted access
            new SecureFileProxy("Document2.txt", "Admin"),   // Full access
            new SecureFileProxy("Document3.txt", "Admin")    // Lazy loading
        };

        foreach (var file in files)
        {
            file.DisplayContent();
            Console.WriteLine();
        }

    }
    #endregion

    #region Behavioural pattern
    private static void ExecuteBehavioralPattern(int designPattern)
    {
        switch (designPattern)
        {
            case 1:
                ExecuteChainOfResponsibilityPattern();
                break;
            case 2:
                ExecuteCommandPattern();
                break;
            case 3:
                ExecuteObserverPattern();
                break;
            case 4:
                ExecuteStrategyPattern();
                break;
            case 5:
                ExecuteInterpreterPattern();
                break;
            case 6:
                ExecuteIteratorPattern();
                break;
            case 7:
                ExecuteMediatorPattern();
                break;
            case 8:
                ExecuteMementoPattern();
                break;
            case 9:
                ExecuteStatePattern();
                break;
            case 10:
                ExecuteVisitorPattern();
                break;
            case 11:
                ExecuteTemplatePattern();
                break;
            default:
                Console.WriteLine("Invalid Behavioral Design Pattern selected.");
                break;
        }
    }

    public static void ExecuteChainOfResponsibilityPattern()
    {
        var level1 = new Level1Support();
        var level2 = new Level2Support();
        var level3 = new Level3Support();

        level1.SetNext(level2);
        level2.SetNext(level3);

        level1.HandleRequest("Advanced");
    }

    public static void ExecuteCommandPattern()
    {
        Order order1 = new Order("1234");

        // Create command instances
        ICommand placeOrder = new PlaceOrderCommand(order1);
        ICommand shipOrder = new ShipOrderCommand(order1);
        ICommand cancelOrder = new CancelOrderCommand(order1);

        // Order Processor (Invoker)
        OrderProcessor processor = new OrderProcessor();

        // Execute commands
        processor.ProcessCommand(placeOrder); // Output: Order 1234 has been placed.
        processor.ProcessCommand(shipOrder);  // Output: Order 1234 has been shipped.

        // Undo last operation
        processor.UndoLastCommand();          // Output: Shipping undone for Order 1234

        processor.ProcessCommand(cancelOrder); // Output: Order 1234 has been cancelled.

    }

    public static void ExecuteObserverPattern()
    {
        var stock = new Stock("Tesla", 800);
        var investor1 = new Investor("Alice");
        var investor2 = new Investor("Bob");

        stock.Attach(investor1);
        stock.Attach(investor2);

        stock.SetPrice(820); // Both Alice and Bob are notified.

    }

    public static void ExecuteStrategyPattern()
    {
        var cart = new ShoppingCart();

        cart.SetPaymentMethod(new Behavioral.CreditCardPayment());
        cart.Checkout(100); // Output: Paid 100 using Credit Card.

        cart.SetPaymentMethod(new PayPalPayment());
        cart.Checkout(200); // Output: Paid 200 using PayPal.

    }

    public static void ExecuteInterpreterPattern()
    {
        IExpression expression = new AddExpression(
            new NumberExpression(2),
            new MultiplyExpression(new NumberExpression(3), new NumberExpression(4))
        );

        Console.WriteLine(expression.Interpret()); 
    }

    public static void ExecuteIteratorPattern()
    {
        var playlist = new Playlist();
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");

        var iterator = playlist.GetIterator();
        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }

    }

    public static void ExecuteMediatorPattern()
    {
        IChatMediator chat = new ChatMediator();
        var user1 = new User("Alice", chat);
        var user2 = new User("Bob", chat);

        chat.RegisterUser(user1);
        chat.RegisterUser(user2);

        user1.SendMessage("Hello everyone!");

    }

    public static void ExecuteMementoPattern()
    {
        var editor = new TextEditor();
        var history = new EditorHistory();

        editor.Write("Hello, ");
        history.Save(editor);

        editor.Write("World!");
        Console.WriteLine(editor.Read()); // Output: Hello, World!

        history.Undo(editor);
        Console.WriteLine(editor.Read()); // Output: Hello, 


    }

    public static void ExecuteStatePattern()
    {
        var light = new TrafficLight();

        light.ChangeLight(); // Red → Green
        light.ChangeLight(); // Green → Yellow
        light.ChangeLight(); // Yellow → Red

    }

    public static void ExecuteVisitorPattern() 
    {
        List<IEmployee> employees = new()
        {
            new PermanentEmployee("Alice", 5000),
            new ContractEmployee("Bob", 3000)
        };

        IEmployeeVisitor salaryCalculator = new SalaryCalculator();

        foreach (var emp in employees)
        {
            emp.Accept(salaryCalculator);
        }

    }

    public static void ExecuteTemplatePattern()
    {
        Console.WriteLine("GPay Payment:");
        PaymentProcessor gpay = new GPayPayment();
        gpay.ProcessPayment();

        Console.WriteLine("\nBank Transfer Payment:");
        PaymentProcessor bankTransfer = new Behavioral.BankTransferPayment();
        bankTransfer.ProcessPayment();

    }

    #endregion
}
