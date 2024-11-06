using System;
using System.IO;

public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }


}

public class BinaryTree 
{
    public Node root;

    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node root, int value)
    {
        if (root == null)
        {
            root = new Node(value);
            return root;
        }

        if (value < root.Value)
        {
            root.Left = InsertRec(root.Left, value);
        }
        else if (value > root.Value)
        {
            root.Right = InsertRec(root.Right, value);
        }

        return root;
    }

    private static void Del(Node t, ref Node tr)
    {
        if (tr.Right != null)
        {
            Del(t, ref tr.Right);
        }
        else
        {
            t.Value = tr.Value;
            tr = tr.Left;
        }
    }
  
    private void Delete(ref Node t)
    {
        if (t != null)
        {
            if (t.Left != null)
            {
                Delete(ref t.Left);
            }
            if (t.Right != null)
            {
                Delete(ref t.Right);
            }
            if (t.Value == t.Value)
            {
                Delete(ref root, t.Value);
            }
        }
    }

    private static void Delete(ref Node t, int key)
    {
        if (t == null)
        {
            return;
        }

        if (key < t.Value)
        {
            Delete(ref t.Left, key);
        }
        else if (key > t.Value)
        {
            Delete(ref t.Right, key);
        }
        else
        {
            if (t.Left == null)
            {
                t = t.Right;
            }
            else if (t.Right == null)
            {
                t = t.Left;
            }
            else
            {
                Del(t, ref t.Left);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            BinaryTree tree = new BinaryTree(); 

            string[] lines = File.ReadAllText("input.txt").Split(' ');
            foreach (string line in lines)
            {
                tree.Insert(int.Parse(line));
            }

            Console.WriteLine("Дерево до удаления нечетных узлов:");
            PrintInOrder(tree.root);

            tree.Delete(ref tree.root);

            Console.WriteLine("Дерево после удаления нечетных узлов:");
            PrintInOrder(tree.root);
        }

        static void PrintInOrder(Node node)
        {
            if (node != null)
            {
                PrintInOrder(node.Left);
                Console.Write(node.Value + " ");
                PrintInOrder(node.Right);
            }
        }
    }
}
