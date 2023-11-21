using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DataStructures.Datastructures.Shared.Base
{
    public abstract class BaseLinkedList<T, K>
    {
        public int Length { get; set; } = 0;
        public T? Head { get; set; }
        public T? Last { get; set; }
        public abstract void Add(T item);
        public abstract void AddLast(T item);
        public abstract void AddFirst(T item);
        public abstract void Clear();
        public abstract void Remove();
        public abstract void RemoveFirst();
        public abstract void RemoveLast();
        public abstract void RemoveItem(K data);
        public abstract void Find(T item);
        public abstract bool Contains(T item);
        public abstract int IndexOf(T item);
        public abstract bool IsEmpty();
        public abstract string ToString();
    }
}
