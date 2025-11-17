using System;
using System.Collections.Generic;
using OneOf;

// Employee  - Can be considered as Leaf Node
public record Employee(string Name, string Role);

// Manager - Can be considered as a intermediate node
public record Manager(string Name, List<OrgNode> Reports);

// Director - Can be considered top level node 
public record Director(string Name, List<OrgNode> Managers);

// Union type
public class OrgNode : OneOfBase<Employee, Manager, Director>
{
    public OrgNode(OneOf<Employee, Manager, Director> input) : base(input) { }
}

class Program
{
    static void Main()
    {
        // Build hierarchy
        var org = new OrgNode(new Director("Praveen Nair", new List<OrgNode>
        {
            new OrgNode(new Manager("Anuraj", new List<OrgNode>
            {
                new OrgNode(new Employee("Sanjay", "Engineer")),
                new OrgNode(new Employee("Vaisakh", "Designer"))
            })),
            new OrgNode(new Manager("Abhishek", new List<OrgNode>
            {
                new OrgNode(new Employee("John", "QA"))
            }))
        }));

        PrintHierarchy(org, 0);
    }

    static void PrintHierarchy(OrgNode node, int indent){
    string pad = new string(' ', indent * 2);

    node.Switch(
        (Employee emp) =>
        {
            Console.WriteLine($"{pad}- {emp.Name} ({emp.Role})");
        },
        (Manager mgr) =>
        {
            Console.WriteLine($"{pad}+ Manager: {mgr.Name}");
            foreach (var report in mgr.Reports)
                PrintHierarchy(report, indent + 1);
        },
        (Director dir) =>
        {
            Console.WriteLine($"{pad}# Director: {dir.Name}");
            foreach (var mgr in dir.Managers)
                PrintHierarchy(mgr, indent + 1);
        }
    );
}

}
