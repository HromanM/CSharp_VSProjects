using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTree;

namespace BinaryTreeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BTree<int> tree1 = new BTree<int>(10);
            tree1.insert(5);
            tree1.insert(11);
            tree1.insert(5);
            tree1.insert(-12);
            tree1.insert(15);
            tree1.insert(0);
            tree1.insert(14);
            tree1.insert(-8);
            tree1.insert(10);
            tree1.insert(8);
            tree1.insert(8);
            tree1.printTree();
        }
    }
}
