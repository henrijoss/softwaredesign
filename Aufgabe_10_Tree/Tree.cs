using System;
using System.Collections.Generic;

namespace Aufgabe_10_Tree
{
    public class Tree <T>
    {
        public T data;
        public List<Tree<T>> children = new List<Tree<T>>();
        public static bool notCalledYet = true; 
        public Tree<T> CreateNode(T Data)
        {
            Tree<T> newNode = new Tree<T>
            {
                data = Data
            };
            return newNode;
        }
        public void AppendChild(Tree<T> child)
        {
            children.Add(child);    
        }
        public void RemoveChild(Tree<T> child)
        {
            children.Remove(child);
        }

        public void PrintTree(String level = "")
        {
            Console.WriteLine(level + data);
            foreach (Tree<T> child in children)
            {
                child.PrintTree(level + "*"); 
            }
        }

        public void ForEach(Action<string> function) 
        {
            if (notCalledYet)
            {
                Console.Write(this.data.ToString()  + " | ");
            }
            notCalledYet = false;

            foreach (Tree<T> child in children)
            {
                function(child.data.ToString());
                child.ForEach(Program.Func);
            }
        }
    }
}