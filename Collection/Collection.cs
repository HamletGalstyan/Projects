using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Collection:IEnumerable,IEnumerator
    {
        readonly Elements[] elements = new Elements[4];
        
        public Elements this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        int position = -1;

        object IEnumerator.Current
        {
            get { return elements[position];}
        }
        bool IEnumerator.MoveNext()
        {
            if(position<elements.Length-1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerator)this);
        }
    }
}
