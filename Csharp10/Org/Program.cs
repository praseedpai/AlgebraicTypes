using System;
using System.Collections.Generic;


public abstract record OrgNode;

// Employee  - Can be considered as Leaf Node
public record Employee(string Name, string Role):OrgNode;

// Manager - Can be considered as a intermediate node
public record Manager(string Name, List<OrgNode> Reports):OrgNode;

// Director - Can be considered top level node 
public record Director(string Name, List<OrgNode> Managers):OrgNode;


class Program
{
    static void Main()
    {
        // Build hierarchy
        var org = new Director("Praveen Nair", new List<OrgNode>
        {
            new Manager("Anuraj", new List<OrgNode>
            {
                new Employee("Sanjay", "Engineer"),
                new Employee("Vaisakh", "Designer")
            }),
            new Manager("Abhishek", new List<OrgNode>
            {
                new Employee("John", "QA")
            })
        });

        PrintHierarchy(org, 0);
    }

    static void PrintHierarchy(OrgNode node, int indent){
    string pad = new string(' ', indent * 2);

     switch (node) {
       case Employee emp:        {
            Console.WriteLine($"{pad}- {emp.Name} ({emp.Role})");
        };
        break;
      case  Manager  mgr:         {
            Console.WriteLine($"{pad}+ Manager: {mgr.Name}");
            foreach (var report in mgr.Reports)
                PrintHierarchy(report, indent + 1);
        };
        break;
       case  Director  dir:         {
            Console.WriteLine($"{pad}# Director: {dir.Name}");
            foreach (var mgr in dir.Managers)
                PrintHierarchy(mgr, indent + 1);
        };
        break;
      default: break;
     };
}

}

