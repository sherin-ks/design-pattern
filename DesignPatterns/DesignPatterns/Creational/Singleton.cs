using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational;

public sealed class Singleton
{
    private static Singleton _instance = null;
    private static readonly object _lock = new object();

    // Private constructor to prevent instantiation
    private Singleton() { }


    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }

    public void ShowMessage() => Console.WriteLine("Singleton instance in action!");
}
