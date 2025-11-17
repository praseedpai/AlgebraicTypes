using System;


public abstract record Expr;
// Product types (records)
public record Constant(double Value):Expr;
public record Add(Expr Left, Expr Right):Expr;
public record Subtract(Expr Left, Expr Right):Expr;
public record Multiply(Expr Left, Expr Right):Expr;
public record Divide(Expr Left, Expr Right):Expr;



class Program
{
    static void Main()
    {
        // Expression: (3 + 5) * (10 - 2)
        Expr expr = new Multiply(
            new Add(
                new Constant(3),
                new Constant(5)
            ),
            new Subtract(
                new Constant(10),
                new Constant(2)
            )
        );

        Console.WriteLine($"Result: {Evaluate(expr)}");
    }

   static double Evaluate(Expr expr) => expr switch{
    Constant c => c.Value,
    Add a => Evaluate(a.Left) + Evaluate(a.Right),
    Subtract s => Evaluate(s.Left) - Evaluate(s.Right),
    Multiply m => Evaluate(m.Left) * Evaluate(m.Right),
    Divide d => Evaluate(d.Left) / Evaluate(d.Right),
    _ => throw new InvalidOperationException("Unknown expression")
	};

}

