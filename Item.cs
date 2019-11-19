using System;
using System.Collections.Generic;
using System.Text;

namespace SelfRef
{
    class Item
    {
        int itemNum;
        string itemName;
        Item next;

        public int Num
        {
            get { return itemNum; }
        }
        public Item Next
        {
            get { return next; }
            set { next = value; }
        }

        public Item (int Num, string Name)
        {
            itemNum = Num;
            itemName = Name;
            next = null;
        }

        public override string ToString()
        {
            return $"Num: {itemNum}, Name: {itemName}";
        }
    }
}
