using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural;

// Component Interface
public interface ILoggerDecorator
{
    void Log(string message);
}

// Concrete Component: File Logger
public class FileLogger : ILoggerDecorator
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging to file: {message}");
    }
}

// Base Decorator
public abstract class LoggerDecorator : ILoggerDecorator
{
    protected readonly ILoggerDecorator _logger;

    protected LoggerDecorator(ILoggerDecorator logger)
    {
        _logger = logger;
    }

    public abstract void Log(string message);
}

// Concrete Decorator 1: Add Timestamp
public class TimestampLogger : LoggerDecorator
{
    public TimestampLogger(ILoggerDecorator logger) : base(logger) { }

    public override void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _logger.Log($"[{timestamp}] {message}");
    }
}

// Concrete Decorator 2: Log to Database
public class DatabaseLogger : LoggerDecorator
{
    public DatabaseLogger(ILoggerDecorator logger) : base(logger) { }

    public override void Log(string message)
    {
        _logger.Log(message);
        Console.WriteLine($"Also logging to database: {message}");
    }
}


