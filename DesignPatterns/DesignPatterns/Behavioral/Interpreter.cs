using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral;

// Abstract Expression
interface IExpression
{
    int Interpret();
}

// Terminal Expressions
class NumberExpression : IExpression
{
    private int _number;
    public NumberExpression(int number) { _number = number; }
    public int Interpret() => _number;
}

// Non-Terminal Expressions
class AddExpression : IExpression
{
    private IExpression _left, _right;
    public AddExpression(IExpression left, IExpression right) { _left = left; _right = right; }
    public int Interpret() => _left.Interpret() + _right.Interpret();
}

class MultiplyExpression : IExpression
{
    private IExpression _left, _right;
    public MultiplyExpression(IExpression left, IExpression right) { _left = left; _right = right; }
    public int Interpret() => _left.Interpret() * _right.Interpret();
}

