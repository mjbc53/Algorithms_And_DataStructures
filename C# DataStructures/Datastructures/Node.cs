using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C__DataStructures.Datastructures
{
    //TODO: Need to figure out how to turn this into a proper abstract class
    internal class Node<T>
    {
        T Data { get; set; }
        Node<T> Next { get; set; }
    }
}
