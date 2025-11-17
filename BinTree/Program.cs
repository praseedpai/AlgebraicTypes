using System;
using OneOf;

// Define record types for leaf and branch nodes
public record Leaf(int Value);
public record Branch(Tree Left, Tree Right);

// Union type for Tree using OneOf
public class Tree : OneOfBase<Leaf, Branch>
{
    public Tree(OneOf<Leaf, Branch> input) : base(input) { }
}

class Program
{
    static void Main()
    {
        // Construct a binary tree: ((1) <- 2 -> (3))
        Tree tree = new Tree(new Branch(
            new Tree(new Leaf(1)),
            new Tree(new Branch(
                new Tree(new Leaf(2)),
                new Tree(new Leaf(3))
            ))
        ));

        Console.WriteLine("Sum of tree: " + Sum(tree));
        Console.WriteLine("In-order traversal: " + InOrder(tree));
    }

    // Functional switch to sum values
    static int Sum(Tree tree) =>
        tree.Match(
            leaf => leaf.Value,
            branch => Sum(branch.Left) + Sum(branch.Right)
        );

    // Functional switch to traverse in-order
    static string InOrder(Tree tree) =>
        tree.Match(
            leaf => leaf.Value.ToString(),
            branch => $"({InOrder(branch.Left)} <- {InOrder(branch.Right)})"
        );
}
