using System;

namespace Builder
{
    class Program
    {

        static void Main(string[] args)
        {
            IBuilder builder = new BasicCarBuilder();
            Director director = new Director(builder);

            Client client = new Client();
            client.ClientCode(director, builder);

            // Wait for user

            Console.ReadKey();
        }
    }

    public class Client
    {
        public void ClientCode(Director director, IBuilder builder)
        {
            Console.WriteLine("Standart basic product:");
            director.constructorMinnimalCar();
            Console.WriteLine(builder.getState());

            Console.WriteLine("Standart full featured product:");
            director.constructorFullCar();
            Console.WriteLine(builder.getState());

            Console.WriteLine("Custom product:");
            builder.reset();
            builder.setGPS(true);
            Console.WriteLine(builder.getState());
        }
    }

    public interface IBuilder
    {
        void reset();

        void setSeats(int num);

        void setGPS(bool isset);

        string getState();
    }

    public class Car
    {
        public int totalseat { get; set; }
        public int seated { get; private set; }
        public bool GPS { get; set; }

        public string Printstate()
        {
           return "totalseat: " + totalseat + ", GPS:" + GPS;
        }
    }

    public class BasicCarBuilder : IBuilder
    {
        Car car = new Car();
        public void reset()
        {
            car = new Car();
        }

        public void setGPS(bool isset)
        {
            car.GPS = isset;
        }

        public void setSeats(int num)
        {
            car.totalseat = num;
        }

        public string getState()
        {
            return car.Printstate();
        }
    }

    public class Director
    {
        protected IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public void constructorMinnimalCar()
        {
            builder.reset();
            builder.setSeats(2);
        }

        public void constructorFullCar()
        {
            builder.reset();
            builder.setSeats(3);
            builder.setGPS(true);
        }
    }
}
