using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational;

// Product Interface
public interface IShape
{
    void Draw();
}

// Concrete Products
public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Circle");
}

public class Square : IShape
{
    public void Draw() => Console.WriteLine("Drawing a Square");
}

// Creator
public abstract class ShapeFactory
{
    public abstract IShape CreateShape();
}

// Concrete Creators
public class CircleFactory : ShapeFactory
{
    public override IShape CreateShape() => new Circle();
}

public class SquareFactory : ShapeFactory
{
    public override IShape CreateShape() => new Square();
}

