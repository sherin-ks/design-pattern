using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Observer Interface
interface IInvestor
{
    void Update(string stockName, double price);
}

// Concrete Observer
class Investor : IInvestor
{
    private string _name;
    public Investor(string name) { _name = name; }
    public void Update(string stockName, double price)
    {
        Console.WriteLine($"{_name} notified: {stockName} is now {price}");
    }
}

// Subject
class Stock
{
    private List<IInvestor> investors = new List<IInvestor>();
    private string _stockName;
    private double _price;

    public Stock(string name, double price)
    {
        _stockName = name;
        _price = price;
    }

    public void Attach(IInvestor investor) => investors.Add(investor);
    public void Detach(IInvestor investor) => investors.Remove(investor);
    public void Notify() => investors.ForEach(i => i.Update(_stockName, _price));

    public void SetPrice(double price)
    {
        _price = price;
        Notify();
    }
}
