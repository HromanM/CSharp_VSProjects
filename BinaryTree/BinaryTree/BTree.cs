using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BTree<TItem> where TItem : IComparable<TItem>
    {
        public TItem Root {get;set;}
        public BTree<TItem> LeftLeaf {get;set;}
        public BTree<TItem> RightLeaf { get; set; }

        public BTree(TItem node)
        {
            this.Root = node;
            this.LeftLeaf = null;
            this.RightLeaf = null;
        }

        // insert new node
        public void insert(TItem item)
        {
            TItem thisNode = this.Root;
            if (this.Root.CompareTo(item) > 0)
            {
                if (this.LeftLeaf == null)
                    this.LeftLeaf = new BTree<TItem>(item);
                else
                    this.LeftLeaf.insert(item);
            }
            else
            {
                if (this.RightLeaf == null)
                    this.RightLeaf = new BTree<TItem>(item);
                else
                    this.RightLeaf.insert(item);
            }     
        }

        // print all nodes
        public void printTree()
        {
            // print lef leaf
            if (this.LeftLeaf != null)
                this.LeftLeaf.printTree();

            // print root
            if (this.Root != null)
                Console.WriteLine(this.Root.ToString());

            if (this.RightLeaf != null)
                this.RightLeaf.printTree();
           
        }
    }
}
