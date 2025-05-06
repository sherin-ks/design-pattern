using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural;

// Subject Interface
public interface IFile
{
    void DisplayContent();
}

// Real Subject: Actual File
public class ProxyFile : IFile
{
    public string FileName { get; }
    private string _content;

    public ProxyFile(string fileName)
    {
        FileName = fileName;
        LoadFile();
    }

    private void LoadFile()
    {
        Console.WriteLine($"Loading file: {FileName}...");
        _content = $"Content of {FileName}";
    }

    public void DisplayContent()
    {
        Console.WriteLine($"File: {FileName}, Content: {_content}");
    }
}

// Proxy: Secure and Lazy-Loaded File Access
public class SecureFileProxy : IFile
{
    private readonly string _fileName;
    private ProxyFile _file;
    private readonly string _userRole;

    public SecureFileProxy(string fileName, string userRole)
    {
        _fileName = fileName;
        _userRole = userRole;
    }

    public void DisplayContent()
    {
        if (_userRole != "Admin")
        {
            Console.WriteLine("Access Denied: Insufficient permissions.");
            return;
        }

        // Lazy Loading
        if (_file == null)
        {
            _file = new ProxyFile(_fileName);
        }

        _file.DisplayContent();
    }
}

