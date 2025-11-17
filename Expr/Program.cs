using System;
using OneOf;

// Product types (records)
public record Constant(double Value);
public record Add(Expr Left, Expr Right);
public record Subtract(Expr Left, Expr Right);
public record Multiply(Expr Left, Expr Right);
public record Divide(Expr Left, Expr Right);

// Sum type using OneOf
public class Expr : OneOfBase<Constant, Add, Subtract, Multiply, Divide>
{
    public Expr(OneOf<Constant, Add, Subtract, Multiply, Divide> input) : base(input) { }
}

class Program
{
    static void Main()
    {
        // Expression: (3 + 5) * (10 - 2)
        Expr expr = new Expr(new Multiply(
            new Expr(new Add(
                new Expr(new Constant(3)),
                new Expr(new Constant(5))
            )),
            new Expr(new Subtract(
                new Expr(new Constant(10)),
                new Expr(new Constant(2))
            ))
        ));

        Console.WriteLine($"Result: {Evaluate(expr)}");
    }

    static double Evaluate(Expr expr) => expr switch
    {
        { Value: Constant c } => c.Value,
        { Value: Add a } => Evaluate(a.Left) + Evaluate(a.Right),
        { Value: Subtract s } => Evaluate(s.Left) - Evaluate(s.Right),
        { Value: Multiply m } => Evaluate(m.Left) * Evaluate(m.Right),
        { Value: Divide d } => Evaluate(d.Left) / Evaluate(d.Right),
        _ => throw new InvalidOperationException("Unknown expression")
    };
}
