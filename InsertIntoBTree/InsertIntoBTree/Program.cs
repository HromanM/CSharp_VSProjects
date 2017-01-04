using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace InsertIntoBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree<char> tree = new BTree<char>('d');
            insertIntoTree(tree, 'f', 'o', 'a', 'x', 'j');
            tree.printTree();
        }

        static void insertIntoTree<T>(BTree<T> tree, params T[] data) where T : IComparable<T>
        {
            if (data.Length == 0)
                throw new ArgumentException("Empty input field");
            foreach (T item in data)
                tree.insert(item);
        }
    }
}
