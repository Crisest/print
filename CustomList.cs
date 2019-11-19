using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections;

namespace SelfRef
{
    class CustomList : ICollection<Item>
    {
        private int count;
        private Item first;

        public CustomList()
        {
            count = 0;
            first = null;
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(Item newEight)
        {
            count++;
            if (first == null)
            {
                first = newEight;
                return;
            }
            if (newEight.Num < first.Num)
            {
                newEight.Next = first;
                first = newEight;
                return;
            }

            Item current = first;
            while (current != null)
            {
                if (current.Next == null)       //insert new item at the end of the list
                {
                    current.Next = newEight;
                    break;
                }
                if (current.Num < newEight.Num &&       //insert new item between two other items
                    current.Next.Num > newEight.Num)
                {
                    newEight.Next = current.Next;
                    current.Next = newEight;
                    break;
                }
                current = current.Next;     //advance to next node if this is not the right place to insert
            }
        }

        public void Clear()
        {
            count = 0;
            first = null;
        }

        public bool Contains(Item item)
        {
            Item current = first;
            while (current != null)
            {
                if (item.Num == current.Num) return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return new CustomListEnumerator(this);
        }

        public bool Remove(Item item)
        {
            //remove first element?
            if (item.Num == first.Num)
            {
                first = first.Next;
                count--;
                return true;
            }
            //remove some other element
            Item current = first;
            while (current != null)
            {
                if (current.Next == null) break;
                if (current.Next.Num == item.Num)
                {
                    count--;
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustomListEnumerator(this);
        }

        class CustomListEnumerator : IEnumerator<Item>
        {
            private Item current;
            private int index;
            private CustomList enumList;

            public CustomListEnumerator(CustomList list)
            {
                enumList = list;
                index = -1;
                current = null;
            }

            public Item Current => current;

            object IEnumerator.Current => current;

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                //first index gets incremented
                index++;
                if (index >= enumList.Count)
                    return false;
                Item c = enumList.first;
                for (int i = 0; i < index; i++)
                    c = c.Next;
                current = c;
                return true;
            }

            public void Reset()
            {
                index = -1;
                current = null;
            }
        }
    }
}
