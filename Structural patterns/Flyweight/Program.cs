using System;
using System.Collections.Generic;
namespace Flyweight
{

    ///
    /// TreeType share help save RAM
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class TreeFactory
    {
        private List<TreeType> _treeTypes = new List<TreeType>(10); 
        public TreeFactory()
        {
            for (int i = 0; i < 10; i++)
            {
                TreeType tt = new TreeType("Tree " + i, "Color", 100);
                this._treeTypes.Add(tt);
            }
        }
        
        public TreeType GetTreeType(string name, string color){
            return this._treeTypes.Find(x=>x.name == name && x.color = color);
        }
    }

    public class Tree{
        public int x{get; set;}
        public int y{get; set;}
        public TreeType type{get; set;}
    }

    public class TreeType{
        public string name {get; set;}
        public string color {get; set;}
        public int height {get; set;}

        public TreeType(string name, string color, int height){
            this.name = name;
            this.color = color;
            this.height = height;
        }

        public void draw(){

        }
    }

    public class Forest{

    }
}