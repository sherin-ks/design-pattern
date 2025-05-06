using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational;

public interface IDocument
{
    IDocument Clone();
    void Display();
}

// Contract Document
public class ContractDocument : IDocument
{
    public string PartyA { get; set; }
    public string PartyB { get; set; }
    public string Terms { get; set; }

    public IDocument Clone()
    {
        return (IDocument)MemberwiseClone(); // Shallow copy
    }

    public void Display()
    {
        Console.WriteLine("Contract Document:");
        Console.WriteLine($"Party A: {PartyA}, Party B: {PartyB}, Terms: {Terms}");
    }
}

// Report Document
public class ReportDocument : IDocument
{
    public string Title { get; set; }
    public string Content { get; set; }

    public IDocument Clone()
    {
        return (IDocument)MemberwiseClone(); // Shallow copy
    }

    public void Display()
    {
        Console.WriteLine("Report Document:");
        Console.WriteLine($"Title: {Title}, Content: {Content}");
    }
}

public class DocumentRegistry
{
    private readonly Dictionary<string, IDocument> _prototypes = new();

    public void RegisterDocument(string key, IDocument document)
    {
        _prototypes[key] = document;
    }

    public IDocument GetDocument(string key)
    {
        if (_prototypes.ContainsKey(key))
        {
            return _prototypes[key].Clone();
        }

        throw new ArgumentException($"No document registered with key: {key}");
    }
}

