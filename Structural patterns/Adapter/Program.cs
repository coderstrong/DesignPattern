using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            AdapterFile iofile = new AdapterFile();
            client cl = new client(iofile);
            cl.read();
            cl.write();

            cl = new client(new AdapterDatabase());
            cl.read();
            cl.write();
        }
    }

    public class client{
        private IAdapter io;

        public client(IAdapter io){
            this.io = io;
        }

        public void read(){
            io.readData();
        }

        public void write(){
            io.writeData();
        }
    }

    public interface IAdapter
    {
        void readData();

        void writeData();
    }

    public class AdapterFile : IAdapter
    {
        public string data {get;set;}
        public void readData()
        {
            this.data = "read data from file";
        }

        public void writeData()
        {
            Console.WriteLine(this.data);
        }
    }

    public class AdapterDatabase : IAdapter
    {
        public string database {get; set;}
        public void readData()
        {
            this.database = "read data from database";
        }

        public void writeData()
        {
            Console.WriteLine(this.database);
        }
    }
}
