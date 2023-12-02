using C__DataStructures.Datastructures.Shared.Nodes;
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
        public abstract T this[int index] { get; }
        public abstract void Add(T item);
        protected abstract void AddLast(T item);
        public abstract void AddFirst(T item);
        public abstract void Clear();
        public abstract T? Remove(T item);
        public abstract T? RemoveFirst();
        public abstract T? RemoveLast();
        protected abstract T? RemoveItem(T item);
        public abstract bool Contains(T item);
        public abstract int IndexOf(T item);
        public abstract bool IsEmpty();
        public abstract string ToString();
    }
}
