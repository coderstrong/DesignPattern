using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory logistics = null;
            // load config from a file
            string config = "box";
            switch (config)
            {
                case "container":
                    logistics = new SeaLogistics();
                    break;
                case "box":
                    logistics = new RoadLogistics();
                    break;
            }
            if (logistics != null)
                Console.WriteLine(logistics.planDelevery());

            
            
        }
    }

    interface ITransport
    {
        string delevery();
    }

    class Truck : ITransport
    {
        public string delevery()
        {
            return "Delevery by land in a box";
        }
    }

    class Ship : ITransport
    {
        public string delevery()
        {
            return "Delevery by sea in a container";
        }
    }

    abstract class Factory
    {
        public string planDelevery()
        {
            ITransport transport = createTransport();
            return "Have plan " + transport.delevery();
        }

        public abstract ITransport createTransport();
    }

    class RoadLogistics : Factory
    {
        public override ITransport createTransport()
        {
            return new Truck();
        }
    }

    class SeaLogistics : Factory
    {
        public override ITransport createTransport()
        {
            return new Ship();
        }
    }
}
