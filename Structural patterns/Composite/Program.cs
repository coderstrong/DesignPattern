using System;
using System.Collections.Generic;

namespace Composite
{
    ///
    /// Create WorkUnit Use Composite pattern
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Component myteam = new Team("Front end");
            Component joh = new Employee("Jon Tran");
            Component evan = new Employee("Evan You");
            Component taylor = new Employee("Taylor swift");

            myteam.add(joh);
            myteam.add(evan);
            myteam.add(taylor);

            myteam.assignTask("Create core fontend");
            myteam.assignTask("Create input type");
            myteam.assignTask("Design frontend");
            taylor.assignTask("Create home page");
            myteam.completeTask("Create core fontend");

            myteam.displayState();
        }
    }

    // The 'Component' abstract class
    public abstract class Component
    {
        public string name { get; set; }

        public Component(string name){
            this.name = name;
        }

        public abstract void add(Component employee);

        public abstract void kick(Component employee);

        public abstract void assignTask(string task);

        public abstract void completeTask(string task);

        public abstract void displayState();
    }

    // The 'Composite' class
    public class Team : Component
    {
        private List<Component> _employee = new List<Component>(10);
        private List<string> _task = new List<string>(10);

        public Team(string name) : base(name)
        {
        }

        public override void add(Component employee)
        {
            this._employee.Add(employee);
            Console.WriteLine("{0} join team {1}", employee.name, this.name);
        }

        public override void kick(Component employee)
        {
            var rm = this._employee.Find(e=>e.name == employee.name);
            this._employee.Remove(rm);
            Console.WriteLine("team {0} kick {1}", this.name, employee.name);
        }

        public override void assignTask(string task)
        {
            this._task.Add(task);
            Console.WriteLine("a task {0} assign to team {1} ", task, this.name);
        }

        public override void completeTask(string task)
        {
            var rm = this._task.Find(t=>t == task);
            this._task.Remove(rm);
            Console.WriteLine("task {0} is complete", task);
        }

        public override void displayState()
        {
            Console.WriteLine("Team have employee: " + this._employee.Count);
            Console.WriteLine("Team have task: " + this._task.Count);
        }
    }

    // The 'Leaf' class
    public class Employee : Component
    {
        private List<string> _task = new List<string>(10);
        public Employee(string name): base(name) {
        }

        public override void add(Component leaf)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void assignTask(string task)
        {
            this._task.Add(task);
            Console.WriteLine("a task {0} assign to employee {1} ", task, this.name);
        }

        public override void completeTask(string task)
        {
            var rm = this._task.Find(t=>t == task);
            this._task.Remove(rm);
            Console.WriteLine("task {0} is complete", task);
        }

        public override void displayState()
        {
            Console.WriteLine("{0} have tasks: {1}",this.name , this._task.Count);
        }

        public override void kick(Component leaf)
        {
            Console.WriteLine("Cannot kick to a leaf");
        }
    }
}
