using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList<string>();
            doublyLinkedList.AddLast("1234zdf");
            doublyLinkedList.AddLast("adfasdf");
            doublyLinkedList.AddLast("pfdp");
            doublyLinkedList.AddLast("test");
            

            Console.WriteLine(doublyLinkedList.Contains("test"));
        }
    }
}
