using System;


public abstract record Tree;
// Define record types for leaf and branch nodes
public record Leaf(int Value):Tree;
public record Branch(Tree Left, Tree Right):Tree;



class Program
{
    static void Main()
    {
        // Construct a binary tree: ((1) <- 2 -> (3))
        Tree tree = new Branch(
            new Leaf(1),
            new Branch(
                new  Leaf(2),
                new Leaf(3)
            )
        );

        Console.WriteLine("Sum of tree: " + Sum(tree));
        Console.WriteLine("In-order traversal: " + InOrder(tree));
    }

    // Functional switch to sum values
    static int Sum(Tree tree) =>
        tree switch {
          Leaf  leaf => leaf.Value,
          Branch  branch => Sum(branch.Left) + Sum(branch.Right),
           _ => 0 // fallback for safety
        };

    // Functional switch to traverse in-order
    static string InOrder(Tree tree) =>
        tree switch {
          Leaf  leaf => leaf.Value.ToString(),
          Branch  branch => $"({InOrder(branch.Left)} <- {InOrder(branch.Right)})",
	   _ => "" // fallback for safety
        };
}

