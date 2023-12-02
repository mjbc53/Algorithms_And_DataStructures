using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__DataStructures.Datastructures.Stack
{
    public class Stack<T> where T : IComparable<T>
    {
        public LinkedList<T> LinkedList { get; set; }
        public int Length { get; set; }
        public Stack() { 
            Length = 0;
            LinkedList = new LinkedList<T>();
        }
        public void Push() { }

        public void Pop() { }

        public T Peak()
        {
            throw new NotImplementedException();
        }

        public T Find() { 
            throw new NotImplementedException();
        }

    }
}
