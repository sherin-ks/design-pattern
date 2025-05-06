using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural;

// Component
public interface IFileSystemItem
{
    void Display(string indent = "");
}

// Leaf
public class File : IFileSystemItem
{
    private readonly string _name;

    public File(string name)
    {
        _name = name;
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}File: {_name}");
    }
}

// Composite
public class Directory : IFileSystemItem
{
    private readonly string _name;
    private readonly List<IFileSystemItem> _items = new();

    public Directory(string name)
    {
        _name = name;
    }

    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}Directory: {_name}");
        foreach (var item in _items)
        {
            item.Display(indent + "  ");
        }
    }
}


