using System;
using OneOf;  // include OneOf library to simulate union type

/////////////////////////
//
// A Simple Shape Hierarchy

public record Circle(double rad);
public record Rectangle(double l , double b );
public record Triangle(double b , double h ); 
public class Shape : OneOfBase<Circle,Rectangle,Triangle> {
	public Shape( OneOf<Circle,Rectangle,Triangle> inp ) : base(inp){}

}

class Program {

        public static string Area(Shape s ) {
		return s.Match(
            circle => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
            rect => $"Rectangle Area: {rect.l * rect.b}",
            tri => $"Triangle Area: {0.5 * tri.b * tri.h}"
        );


        }

       public static string AreaWithout(Shape s ) {
		return s.Match(
          (Circle  circle) => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
          (Rectangle  rect) => $"Rectangle Area: {rect.l * rect.b}",
          (Triangle  tri ) => $"Triangle Area: {0.5 * tri.b * tri.h}"
        );


        }

         public static string AreaLambda(Shape s ) =>  s.Match(
          (Circle  circle) => $"Circle Area: {Math.PI * Math.Pow(circle.rad, 2)}",
          (Rectangle  rect) => $"Rectangle Area: {rect.l * rect.b}",
          (Triangle  tri ) => $"Triangle Area: {0.5 * tri.b * tri.h}"
        );


        


        // Explicit Main method
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello from an explicit Main method!");
            Shape sc01 = new Shape(new Circle(10.0));
	    Shape sc02 = new Shape(new Rectangle(10.0,2.0));
            Console.WriteLine(Area(sc01));
            Console.WriteLine(AreaWithout(sc02));

            // Return 0 to indicate success
            return 0;
        }
    }


