using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BTreeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
    {
        private BTree<T> actData = null;
        private T actItem = default(T);
        private Queue<T> enumData = null;

        public BTreeEnumerator(BTree<T> data)
        {
            this.actData = data;
        }

        private void fill(Queue<T> que, BTree<T> tr)
        {
            if (tr.LeftLeaf != null)
                fill(que, tr.LeftLeaf);
            if (tr.Root != null)
                this.enumData.Enqueue(tr.Root);
            if (tr.RightLeaf != null)
                fill(que, tr.RightLeaf);
        }

        T IEnumerator<T>.Current 
        {
            get
            {
                if (this.actItem == null)
                    throw new InvalidOperationException("you have to call moveNext() first");
                return this.actItem;
            }
        }

        public object Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        void IDisposable.Dispose()
        {
            
        }

        bool System.Collections.IEnumerator.MoveNext()
        {
            if (this.enumData == null)
            {
                this.enumData = new Queue<T>();
                fill(this.enumData, this.actData);
            }

            if (this.enumData.Count > 0)
            {
                this.actItem = this.enumData.Dequeue();
                return true;
            }
            return false;
        }

        void IEnumerator.Reset()
        {
            throw new NotImplementedException();
        }
    }
}

