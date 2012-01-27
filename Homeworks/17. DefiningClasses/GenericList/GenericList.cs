using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericList
{
    class GenericList<T>
    {

        public List<T> list { get; set; }
 
        public GenericList(int capacity)
        {
            list.Capacity = capacity;
        }


        public void Add(T element)
        {
            list.Add(element);
        }

        public bool Remove(T element)
        {
            return list.Remove(element);
        }

        public T GetByIndex(int index)
        {

            return list[index];
        }

        public void RemoveByIndex(int index)
        {
            list.RemoveAt(index);
        }

        public override string ToString()
        {
            return "ToString() overrided";
        }

        public int FindByValue(T value)
        {
            var e = (from T item in list
                    where item.Equals(value)
                    select item).First();

            return list.IndexOf(e);

        }

        public void  ClearList()
        {
            list.Clear();
        }

    }
}
