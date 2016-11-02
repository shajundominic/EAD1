

using System;

namespace Shape
{
	// abstract base class for all 3D shapes
	public abstract class ThreeDShape
	{	
		private String type;		// cone, sphere etc.
		
		public ThreeDShape(string type)
		{
			this.type = type;
		}
		
		// read-only property for type
		public String Type
		{
			get
			{
				return type;
			}
		}
		
		public abstract double CalcVolume();
		
		public override String ToString()
		{
			return "a " + type + " shape";
		}
	
	}
	
	// subclass
	public class Sphere : ThreeDShape	            // a Sphere is ThreeDShape
	{
        private double radius;
		
		// constructors
		public Sphere(double radius) : base("Sphere")
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
					throw new ApplicationException("Radius must be positive");
				}
			}
		}
		
		// calculate the volume of the sphere
		public override double CalcVolume()
		{
			return Math.PI * radius * radius * radius;
		}
		
		public override String ToString()
		{
			return base.ToString() + " of radius: " + radius.ToString();
		}
		
	}

}

// test class, default namespace
class Test
{
	public static void Main()
	{
	
		// poly collection
		Shape.ThreeDShape[] collection = {new Shape.Sphere(), new Shape.Sphere(10)};
		
		foreach (Shape.ThreeDShape s in collection)
		{
			Console.WriteLine(s + " volume: " + s.CalcVolume()); 
		}
	}
}
