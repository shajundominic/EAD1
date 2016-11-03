// sample solution to Lab 2
// author GC

using System;

namespace Shape
{
    public interface IHasVolume
    {
        double CalcVolume();		// public and abstract
    }

    // subclass
    public class Sphere : System.Object, IHasVolume	        // implement i/f
    {
        private double radius;		// field

        // constructors
        public Sphere(double radius)
        {
            Radius = radius;
        }

        public Sphere() : this(0)
        {
        }

        // read-write property for radius
        public double Radius
        {
            get
            {
                return radius;
            }

            set	// validate
            {
                if (value >= 0)
                {
                    radius = value;
                }
                else
                {
                    throw new ApplicationException("radius must be positive");
                }
            }
        }

        // calculate the volume of the sphere
        // can be overriden in a subclass
        public virtual double CalcVolume()
        {
            return Math.PI * radius * radius * radius;
        }

        public override String ToString()
        {
            return "A Sphere of radius: " + radius.ToString();
        }

    }

}

// test class, default namespace
class Test
{
    public static void Main()
    {
        // collection of sphere objects referenced by HasVolume refs
        Shape.IHasVolume[] collection = { new Shape.Sphere(), new Shape.Sphere(10) };

        foreach (Shape.IHasVolume s in collection)
        {
            Console.WriteLine(s + " volume: " + s.CalcVolume());
        }
    }
}