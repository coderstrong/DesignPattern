using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            LogisticsFactory logistics = null;
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
            if(logistics!=null)
                Console.WriteLine(logistics.planDelevery());
            
        }
    }

    interface ITransport
    {
        string delevery();
    }

    class Truck : ITransport
    {
        public string delevery(){
            return "Delevery by land in a box";
        }
    }

    class Ship : ITransport
    {
        public string delevery(){
            return "Delevery by sea in a container";
        }
    }

    interface IWarehouse
    {
        string save();
    }

    class Pallet : IWarehouse{
        public string save(){
            return "save product using pallet nearth the sea";
        }
    }

    class Mezzanine : IWarehouse{
        public string save(){
            return "save product using Mezzanine nearth the mall";
        }
    }

    abstract class LogisticsFactory
    {
        public string planDelevery(){
            ITransport transport = createTransport();
            IWarehouse warehouse = createWarehouse();
            return "Have plan " + transport.delevery() + " and " + warehouse.save();
        }

        public abstract ITransport createTransport();
        public abstract IWarehouse createWarehouse();
    }

    class RoadLogistics : LogisticsFactory
    {
        public override ITransport createTransport(){
            return new Truck();
        }

        public override IWarehouse createWarehouse(){
            return new Mezzanine();
        }
    }

    class SeaLogistics : LogisticsFactory
    {
        public override ITransport createTransport(){
            return new Ship();
        }

        public override IWarehouse createWarehouse(){
            return new Pallet();
        }
    }
}
