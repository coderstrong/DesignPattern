using System;

namespace Prototype
{
    class Program
    {

        static void Main(string[] args)
        {
            Client client = new Client();
            client.ClientCode();

            // Wait for user
            Console.ReadKey();
        }
    }

    public class Client
    {
        public void ClientCode()
        {
            Circle c1 = new Circle("red", 5);
            Circle c2 = (Circle)c1.clone();
            c1.color = "yellow";
            Console.WriteLine("Cloned: {0}", c2.r);
        }
    }

    public abstract class Shape
    {
        public string color { get; set; }

        public Shape(string color)
        {
            this.color = color;
        }

        public abstract Shape clone();
    }

    public class Rectangle : Shape
    {
        public Rectangle(string color) : base(color) { }

        public override Shape clone()
        {
            return (Shape)this.MemberwiseClone();
        }
    }

    public class Circle : Shape
    {
        public int r { get; set; }
        public Circle(string color, int r) : base(color) {
            this.r = r;
        }

        public override Shape clone()
        {
            return (Shape)this.MemberwiseClone();
        }
    }
}
