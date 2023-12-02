using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__DataStructures.Datastructures.Shared.Base;

namespace C__DataStructures.Datastructures.Shared.Nodes
{
    public class TwoWayNode<T> : BaseNode<T>
    {
        public TwoWayNode<T>? Next { get; set; }
        public TwoWayNode<T>? Previous { get; set; }
        public TwoWayNode(T data, TwoWayNode<T>? next = null, TwoWayNode<T>? prev = null )
        {
            Next = next;
            Previous = prev;
            Data = data;
        }
    }
}
