using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aufgabe_9
{
    public class Tree<T>
    {
        public T Data;
        public List<Tree<T>> children = new List<Tree<T>>();
        public Tree<T> CreateNode(T data)
        {
            Tree<T> newNode = new Tree<T>
            {
                Data = data
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
            Console.WriteLine(level + Data);
            foreach (Tree<T> child in children)
            {
                child.PrintTree(level + "*");
            }
        }
    }
}