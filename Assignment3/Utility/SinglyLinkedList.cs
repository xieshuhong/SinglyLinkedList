using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment3.Utility
{
    [Serializable, KnownType(typeof(SinglyLinkedList))]
    public class SinglyLinkedList: ILinkedListADT
    {
        public Node<User> Head { set; get; }
        public int count;

        public SinglyLinkedList() 
        {
            Head = null; 
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > this.count) throw new IndexOutOfRangeException();
            Node<User> newnode = new Node<User>(value);
            if (index == 0)
            {
                newnode.next = Head;
                Head = newnode;
            } else
            {
                Node<User> current = Head;
                for (int i = 0; i < index -1; i++)
                {
                    current = current.next;
                }
                newnode.next = current.next;
                current.next = newnode;
            }
            this.count++;
        }

        public void AddFirst(User value)
        {
            Node<User> newnode= new Node<User>(value);
            newnode.next = Head;
            Head = newnode;
            this.count ++;
        }

        public void AddLast(User value)
        {
            Node<User> newnode = new Node<User>(value);
            if (Head == null) Head = newnode;
            else
            {
                Node<User> current = Head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newnode;
            }
            this.count++;
        }

        public void Clear()
        {
            Head = null;
            this.count = 0;
        }

        public bool Contains(User value)
        {
            Node<User> current = Head;
            while (current != null)
            {
                if (current.data.Equals(value)) return true;
                current = current.next;
            }
            return false;
        }


        public User GetValue(int index)
        {
            if (index < 0 || index > this.count) throw new IndexOutOfRangeException();
            Node<User> current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.data;
        }

        public int IndexOf(User value)
        {
            Node<User> current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.data.Equals(value)) return index;
                current = current.next;
                index++;
            }
            return -1;
        }

        public bool IsEmpty()
        {
            if (this.count <= 0) return true;
            else return false;
        }

        public void Remove(int index)
        {
            if (index < 0 || index > this.count) throw new IndexOutOfRangeException();
            if (index == 0) Head = Head.next;
            else
            {
                Node<User> current = Head;
                for (int i = 0; i < index -1;  i++) current = current.next;
                current.next = current.next.next;
            }
            this.count--;
        }

        public void RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException();
            Head = Head.next;
            this.count--;
        }

        public void RemoveLast()
        {
            if (Head == null) throw new InvalidOperationException();
            if (Head.next == null) Head = null;
            else
            {
                Node<User> current = Head;
                while (current.next.next != null) current = current.next;
                current.next = null;
            }       
            this.count--;
        }

        public void Replace(User value, int index)
        {
            Node<User> node = new Node<User>(value);

            if (Head == null) throw new InvalidOperationException();
            else if (index == 0) Head.data = value;
            else
            {
                Node<User> current = Head;
                for (int i = 0;i < index - 1;i++)
                {
                    current = current.next;
                    if (current == null)
                    {
                        throw new ArgumentOutOfRangeException("index is out of range");
                    }
                }
                current.data = value;
            }

        }
        public int Count()
        {
            int count = 0;
            Node<User> current = Head;

            while (current != null)
            {
                count++;
                current = current.next;
            }

            return count;
        }

        // Reverse the linkedList
        public void Reverse()
        {
            if(IsEmpty() || Head.next == null) return;
            Node<User> previous = null;
            Node<User> current = Head;
            while (current != null)
            {
                Node<User> next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            Head = previous;
        }

        // sorting the list based on alphabet
        //public void Sort()
        //{
        //    if (IsEmpty() || Head.next == null) return;
        //    Node<User> current = Head;
        //    while (current != null)
        //    {
        //        Node<User> next = current.next;
        //        while (next != null)
        //        {
        //            if(string.Compare(current.data.Name, next.data.Name) > 0)
        //            {
        //                User temp = current.data;
        //                current.data = next.data;
        //                next.data = temp;
        //            }
        //            next = next.next;
        //        }
        //        current = current.next;
        //    }
        //}
    }
}
