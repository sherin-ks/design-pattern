using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Common interface for all Employees
interface IEmployee
{
    void Accept(IEmployeeVisitor visitor);
}


class PermanentEmployee : IEmployee
{
    public string Name { get; }
    public double Salary { get; }

    public PermanentEmployee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public void Accept(IEmployeeVisitor visitor) => visitor.Visit(this);
}

class ContractEmployee : IEmployee
{
    public string Name { get; }
    public double Salary { get; }

    public ContractEmployee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public void Accept(IEmployeeVisitor visitor) => visitor.Visit(this);
}

// Visitor Interface with a single Visit method
interface IEmployeeVisitor
{
    void Visit(IEmployee employee);
}

class SalaryCalculator : IEmployeeVisitor
{
    public void Visit(IEmployee employee)
    {
        if (employee is PermanentEmployee pe)
        {
            Console.WriteLine($"Permanent Employee {pe.Name} has a salary of {pe.Salary}");
        }
        else if (employee is ContractEmployee ce)
        {
            Console.WriteLine($"Contract Employee {ce.Name} has a salary of {ce.Salary}");
        }
    }
}

