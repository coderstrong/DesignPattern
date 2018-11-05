using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            // Injection
            Candle cd = new Candle("long");
            Cake ca = new Cake(20, 15);
            Firework fw = new Firework("big");

            PartyProgram facade = new PartyProgram(cd, ca, fw);
            facade.doItAll();
        }
    }

    // class facade
    public class PartyProgram
    {
        private Candle _candel;
        private Cake _cake;
        private Firework _firework;

        public PartyProgram(Candle candle, Cake cake, Firework firework)
        {
            this._candel = candle;
            this._cake = cake;
            this._firework = firework;
        }

        public void doItAll()
        {
            Console.WriteLine("Cake H: {0}, W: {1}", this._cake.height, this._cake.width);
            Console.WriteLine("Candel type {0}", this._candel.type);
            Console.WriteLine("Firework type {0}", this._firework.type);
        }
    }

    // sub class 
    public class Candle
    {
        public string type { get; set; }

        public Candle(string type)
        {
            this.type = type;
        }
    }

    public class Cake
    {
        public int width { get; set; }

        public int height { get; set; }

        public Cake(int w, int h)
        {
            this.width = w;
            this.height = h;
        }
    }

    public class Firework
    {
        public string type { get; set; }

        public Firework(string type)
        {
            this.type = type;
        }
    }
}
