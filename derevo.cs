using System;
using System.IO;

public class Node
{
    public int data;// Значение узла

    public Node left, right;// Левый и правый потомок узла
    public Node(int item)  // Конструктор класса Node для инициализации узла с заданным значением
    {
        data = item;// инициализация данных узла

        left = right = null;// инициализация ссылок на поддеревья

    }
}

// Описание класса BinaryTree, представляющего бинарное дерево
public class BinaryTree
{
    public Node root;// Корень дерева

    public void Insert(int data)// Метод вставки нового элемента в дерево
    {
        root = InsertRec(root, data);
    }

    private Node InsertRec(Node root, int data)// Рекурсивный метод вставки нового элемента в дерево
    {
        if (root == null)
        {
            root = new Node(data);
            return root;
        }

        if (data < root.data)
        {
            root.left = InsertRec(root.left, data);
        }
        else if (data > root.data)
        {
            root.right = InsertRec(root.right, data);
        }

        return root;
    }

    public int CountNodesGreaterThanAverage()// Метод подсчета количества узлов со значением больше среднего арифметического

    {
        int sum = 0, count = 0;
        CalculateSumAndCount(root, ref sum, ref count);

        if (count == 0)
        {
            return 0;
        }

        int average = sum / count;
        return CountNodesGreaterThanAverageRec(root, average);
    }

    private int CountNodesGreaterThanAverageRec(Node root, int average) // Рекурсивный метод подсчета количества узлов со значением больше среднего арифметического
    {
        if (root == null)
        {
            return 0;
        }

        int count = 0;
        if (root.data > average)
        {
            count++;
        }

        count += CountNodesGreaterThanAverageRec(root.left, average);
        count += CountNodesGreaterThanAverageRec(root.right, average);

        return count;
    }
    // Вспомогательный метод для вычисления суммы и количества узлов в дереве
    private void CalculateSumAndCount(Node root, ref int sum, ref int count)
    {
        if (root == null)
        {
            return;
        }

        sum += root.data;
        count++;

        CalculateSumAndCount(root.left, ref sum, ref count);
        CalculateSumAndCount(root.right, ref sum, ref count);
    }
}

public class Program
{
    public static void Main()
    {
        string[] input = File.ReadAllText("input.txt").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        BinaryTree tree = new BinaryTree();

        foreach (string s in input)
        {
            tree.Insert(int.Parse(s));
        }

        int count = tree.CountNodesGreaterThanAverage();
        Console.WriteLine("количество узлов, значение которых больше среднего арифметического: " + count);
    }
}

