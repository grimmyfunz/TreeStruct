using System;
using System.Collections.Generic;

namespace TreeStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree latvija = new Tree("Latvija");

            //ADDING CHILD
            latvija.AddChild("Riga");
            latvija.AddChild("Olaine");
            latvija.AddChild("Jelgava");
            latvija.AddChild("Jaunolaine", "Olaine");
            latvija.AddChild("Veselibas centrs", "Jaunolaine");
            latvija.AddChild("Veselibas centrs", "Tokyo");

            latvija.PrintTree();

            Console.WriteLine(latvija.FindChild("Tokyo"));
            Console.WriteLine(latvija.FindChild("Latvija"));
            Console.WriteLine(latvija.FindChild("Jelgava"));

            Console.WriteLine(latvija.EditNode("Foo", "Tokyo"));

            Console.WriteLine(latvija.EditNode("Jelgava", "Tokyo"));

            latvija.PrintTree();

            Console.WriteLine();
        }
    }

    class Tree
    {
        public string data;
        private LinkedList<Tree> children;

        public Tree(string data)
        {
            //Console.WriteLine($"New tree {data} was created!");
            this.data = data;
            children = new LinkedList<Tree>();
        }

        public Tree AddChild(string data, string childName = null)
        {

            if (childName != null)
            {
                if (FindChildNode(childName) != null)
                {
                    return FindChildNode(childName).AddChild(data);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //Console.WriteLine($"New child {data} was added to {this.data}!");
                Tree added = new Tree(data);
                children.AddFirst(added);
                return added;
            }
        }

        public bool FindChild(string data)
        {
            //Console.WriteLine($"Searching {data} in {this.data}!");

            if (data == this.data)
            {
                return true;
            }

            foreach (Tree child in children)
            {
                if (child.FindChild(data))
                {
                    //Console.WriteLine($"Child {data} was found in {this.data}!");
                    return true;
                }
            }
            
            //Console.WriteLine($"Child {data} was NOT found in {this.data}!");
            return false;
        }

        public Tree FindChildNode(string data)
        {
            //Console.WriteLine($"Searching node:{data} in {this.data}");

            if (data == this.data)
            {
                return this;
            }

            foreach (Tree child in children)
            {
                if (child.FindChildNode(data) != null)
                {
                    //Console.WriteLine($"Child {data} node was found in {this.data}!");
                    return child.FindChildNode(data);
                }
            }

            //Console.WriteLine($"Child {data} node was NOT found in {this.data}!");
            return null;
        }


        public bool EditNode(string data, string newData)
        {
            if (FindChildNode(data) != null)
            {
                //Console.WriteLine($"Childs {data} name was changed on {newData}");

                FindChildNode(data).data = newData;

                return true;
            }

           // Console.WriteLine($"Childs {data} name was NOT changed on {newData}");
            return false;
        }

        public void PrintTree(int level = 0)
        {
            string text = "--";

            for (int i = 0; i < level; i++)
            {
                text += "--";
            }

            text += " "+data;

            Console.WriteLine(text);

            //Console.WriteLine(level+": "+data);

            level++;

            foreach (Tree child in children)
            {
                child.PrintTree(level);
            }
        }

        //RESTRICTED:
        //public bool EditNode(string data, string newData)
        //{
        //    Console.WriteLine($"Searching {data} in {this.data} to change on {newData}");

        //    if (data == this.data)
        //    {
        //        Console.WriteLine($"{this.data} was changed on {newData}");
        //        this.data = newData;
        //        return true;
        //    }

        //    foreach (Tree child in children)
        //    {
        //        if (child.EditNode(data, newData))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}
    }
}
