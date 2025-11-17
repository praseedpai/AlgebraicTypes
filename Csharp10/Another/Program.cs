using System;


public abstract record Shape;

/////////////////////////
//
// A Simple Shape Hierarchy

public record Circle(double rad):Shape;
public record Rectangle(double l , double b ):Shape;
public record Triangle(double b , double h ):Shape;


class Program {

        public static string Area(Shape s ) {
		return s switch {
          Circle circle   => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
          Rectangle  rect => $"Rectangle Area: {rect.l * rect.b}",
          Triangle  tri => $"Triangle Area: {0.5 * tri.b * tri.h}",
          _ => "Invalid"
       };


        }

       public static string AreaWithout(Shape s ) {
		return s switch {
          (Circle  circle) => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
          (Rectangle  rect) => $"Rectangle Area: {rect.l * rect.b}",
          (Triangle  tri ) => $"Triangle Area: {0.5 * tri.b * tri.h}",
          _ => "Invalid"
        };


        }

         public static string AreaLambda(Shape s ) =>  s switch {
          (Circle  circle) => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
          (Rectangle  rect) => $"Rectangle Area: {rect.l * rect.b}",
          (Triangle  tri ) => $"Triangle Area: {0.5 * tri.b * tri.h}",
          _ => "Invalid"
         };


        


        // Explicit Main method
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello from an explicit Main method!");
            Shape sc01 = new Circle(10.0);
	    Shape sc02 = new Rectangle(10.0,2.0);
            Console.WriteLine(Area(sc01));
            Console.WriteLine(AreaWithout(sc02));

            // Return 0 to indicate success
            return 0;
        }
    }



