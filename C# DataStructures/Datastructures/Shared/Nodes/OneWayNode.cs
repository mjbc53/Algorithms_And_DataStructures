using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C__DataStructures.Datastructures.Shared.Base;

namespace C__DataStructures.Datastructures.Shared.Nodes
{
    public class OneWayNode<T> : BaseNode<T>
    {
        public OneWayNode<T>? Next { get; set; }

        public OneWayNode(T data, OneWayNode<T>? next = null)
        {
            Next = next;
            Data = data;
        }
    }
}
