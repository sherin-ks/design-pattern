namespace DesignPatterns.Structural;

// Target Interface
public interface ILogger
{
    void LogInfo(string message);
    void LogError(string message);
    void LogWarning(string message);
}

// Adaptee: NLog (Third-Party Logging Library)
public class NLog
{
    public void WriteLog(string type, string message)
    {
        Console.WriteLine($"[NLog {type}]: {message}");
    }
}

// Adaptee: Serilog (Third-Party Logging Library)
public class Serilog
{
    public void Log(string severity, string details)
    {
        Console.WriteLine($"[Serilog {severity}]: {details}");
    }
}


// Adapter for NLog
public class NLogAdapter : ILogger
{
    private readonly NLog _nLog;

    public NLogAdapter(NLog nLog)
    {
        _nLog = nLog;
    }

    public void LogInfo(string message) => _nLog.WriteLog("INFO", message);

    public void LogError(string message) => _nLog.WriteLog("ERROR", message);

    public void LogWarning(string message) => _nLog.WriteLog("WARNING", message);
}

// Adapter for Serilog
public class SerilogAdapter : ILogger
{
    private readonly Serilog _serilog;

    public SerilogAdapter(Serilog serilog)
    {
        _serilog = serilog;
    }

    public void LogInfo(string message) => _serilog.Log("INFO", message);

    public void LogError(string message) => _serilog.Log("ERROR", message);

    public void LogWarning(string message) => _serilog.Log("WARNING", message);
}

