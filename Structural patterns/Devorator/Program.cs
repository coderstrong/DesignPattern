using System;
using System.Collections.Generic;

namespace Devorator
{
    class Program
    {

        static void Main(string[] args)
        {
            //Task<int> task = new Task<int>(() =>
            //{
            //    Thread.Sleep(3000);
            //    return 1;
            //});

            //task.Start();

            // Create book

            Book book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video

            Video video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display

            Console.WriteLine("\nMaking video borrowable:");

            Borrowable borrowvideo = new Borrowable(video);
            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");

            borrowvideo.Display();

            Borrowable borrowbook = new Borrowable(book);
            borrowbook.BorrowItem("Customer #3");
            borrowbook.Display();

            IPizza tomato = new TomatoPizza();
            IPizza chicken = new ChickenPizza();

            Console.WriteLine(tomato.doPizza());
            Console.WriteLine(chicken.doPizza());
            
            // Add pepper to tomato-pizza
            //PepperDecorator pepperDecorator = new PepperDecorator(tomato);
            //Console.WriteLine(pepperDecorator.doPizza());
            tomato = new CheeseDecorator(tomato);

            // Add cheese to tomato-pizza
            //CheeseDecorator cheeseDecorator = new CheeseDecorator(tomato);
            //Console.WriteLine(cheeseDecorator.doPizza());
            tomato = new PepperDecorator(tomato);

            // Add cheese and pepper to tomato-pizza
            // We combine functionalities together easily.
            tomato = new PepperDecorator(tomato);
            Console.WriteLine(tomato.doPizza());

            //Thread thread = new Thread(() => { Thread.Sleep(3000); });
            //thread.Start();


            //ThreadPool.QueueUserWorkItem((Object stateInfo) =>
            //{
            //    Thread.Sleep(3000);
            //});

            // Wait for user

            Console.ReadKey();
        }
    }

    /// <summary>

    /// The 'Component' abstract class

    /// </summary>

    abstract class LibraryItem
    {
        public int NumCopies { get; set; }

        public abstract void Display();
    }


    /// <summary>

    /// The 'ConcreteComponent' class

    /// </summary>
    class Book : LibraryItem
    {
        private string _author;
        private string _title;

        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            this.NumCopies = numCopies;
        }
        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>

    /// The 'ConcreteComponent' class

    /// </summary>

    class Video : LibraryItem
    {
        private string _director;
        private string _title;
        private int _playTime;

        public Video(string director, string title, int numCopies, int playtime)
        {
            this._director = director;
            this._title = title;
            this.NumCopies = numCopies;
            this._playTime = playtime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }


    /// <summary>

    /// The 'Decorator' abstract class

    /// </summary>

    abstract class Decorator : LibraryItem
    {
        protected LibraryItem libratyItem;

        public Decorator(LibraryItem component)
        {
            this.libratyItem = component;
        }

        public override void Display()
        {
            libratyItem.Display();
        }
    }

    /// <summary>

    /// The 'ConcreteComponent' class

    /// </summary>
    class Borrowable : Decorator
    {
        protected List<string> borrowers = new List<string>();

        public Borrowable(LibraryItem libraryItem)
            : base(libraryItem)
        {

        }

        public void BorrowItem(string name)
        {
            this.borrowers.Add(name);
            libratyItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            borrowers.Remove(name);
            this.libratyItem.NumCopies++;
        }

        public override void Display()
        {
            base.Display();

            foreach (var borrower in borrowers)
            {
                Console.WriteLine("Borrower: " + borrower);
            }
        }
    }


    // NEW EXAMPLE
    public interface IPizza
    {
        string doPizza();
    }

    public class TomatoPizza : IPizza
    {
        public string doPizza()
        {
            return "I'm a Tomato Pizza";
        }
    }

    public class ChickenPizza : IPizza
    {
        public string doPizza()
        {
            return "I'm a Chicken Pizza";
        }
    }

    public abstract class PizzaDecorator : IPizza{
        protected IPizza mPizza {get; set;}

        public PizzaDecorator(IPizza pizza){
            mPizza = pizza;
        }

        public abstract string doPizza();
    }

    public class CheeseDecorator : PizzaDecorator{
        public CheeseDecorator(IPizza pizza) : base(pizza){
        }

        public override string doPizza()
        {
            return mPizza.doPizza() + ", Chesse";
        }
    }

    public class PepperDecorator : PizzaDecorator
    {
        public PepperDecorator(IPizza pizza)
            : base(pizza)
        {
        }

        public override string doPizza()
        {
            return mPizza.doPizza() + ", Pepper";
        }
    }
}
