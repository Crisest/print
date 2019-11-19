using System;

namespace SelfRef
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new instance of CustomList class
            CustomList myList = new CustomList();

            //create some new items to add
            Item five = new Item(5, "Five");
            Item seven = new Item(7, "Seven");
            Item nine = new Item(9, "Nine");
            Item fifteen = new Item(15, "Fifteen");
            Item three = new Item(3, "Three");
            Item eight = new Item(8, "Eight");

            //add six new elements to the list, they will end up in order due to Add algorithm
            myList.Add(five);
            myList.Add(seven);
            myList.Add(nine);
            myList.Add(fifteen);
            myList.Add(three);
            myList.Add(eight);

            //use a foreach loop to iterate over elements in the custom list
            foreach (Item i in myList)
                Console.WriteLine(i.ToString());
            //display how many elements are in the list
            Console.WriteLine("Number of items: {0}", myList.Count);

            //attempt to remove an element from the list
            myList.Remove(new Item(9, "Blah")); //remove method only compares number, not name

            //display the custom list contents again after the remove
            foreach (Item i in myList)
                Console.WriteLine(i.ToString());
            //display how many elements are in the list after the remove
            Console.WriteLine("Number of items: {0}", myList.Count);
        }
    }
}
