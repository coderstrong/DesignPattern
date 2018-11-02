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
            
            Factory factory = null;
            string config2 = "VN";
            switch (config2)
            {
                case "VN":
                    factory = new VNCountry();
                    break;
                case "US":
                    factory = new USCountry();
                    break;
            }
            if(factory!=null){
                Address vnadd = factory.createAddress();
                Phone vnphone = factory.createPhone();
            }
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

    // Example 2
    // manager Address and Phone
    public abstract class Address
    {
        public string address { get; set; }
        public abstract string validateAddress();
    }

    public abstract class Phone
    {
        public string phone { get; set; }
        public abstract string validatePhone();
    }

    public abstract class Factory
    {
        public abstract Phone createPhone();

        public abstract Address createAddress();
    }

    public class VNAddress : Address
    {
        public override string validateAddress()
        {
            if (this.address.Contains("VN"))
            {
                return this.address;
            }
            else
            {
                return "Your addess invaild!";
            }
        }
    }

    public class USAddress : Address
    {
        public override string validateAddress()
        {
            if (this.address.Contains("US"))
            {
                return this.address;
            }
            else
            {
                return "Your addess invaild!";
            }
        }
    }

    public class VNPhone : Phone
    {
        public override string validatePhone()
        {
            if (this.phone.Contains("+84"))
            {
                return this.phone;
            }
            else
            {
                return "Your phone invaild!";
            }
        }
    }

    public class USPhone : Phone
    {
        public override string validatePhone()
        {
            if (this.phone.Contains("+1"))
            {
                return this.phone;
            }
            else
            {
                return "Your phone invaild!";
            }
        }
    }

    public class VNCountry : Factory
    {
        public override Address createAddress()
        {
            return new VNAddress();
        }

        public override Phone createPhone()
        {
            return new VNPhone();
        }
    }

    public class USCountry : Factory
    {
        public override Phone createPhone()
        {
            return new USPhone();
        }

        public override Address createAddress()
        {
            return new USAddress();
        }
    }
}
