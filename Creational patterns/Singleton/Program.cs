using System;

namespace Singleton
{
    class Program
    {

        static void Main(string[] args)
        {
            

            // Create book
            Logs.Instance.writeLog("hello word");

            // Wait for user

            Console.ReadKey();
        }
    }


    class Logs
    {
        #region SingleTon constructor
        private Logs() { }

        public static Logs Instance
        {
            get
            {
                return Nested._instance;
            }
        }

        class Nested
        {
            static Nested() { }
            internal volatile static Logs _instance = new Logs();
        }
        #endregion

        public void writeLog(string input)
        {
            Console.WriteLine(input);
        }
    }
}
