using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp8._0
{
    public class MyCircularQueue
    {
        /** Initialize your data structure here. Set the size of the queue to be k. */
        //private int Head;
        //private int Tail;
        //private bool Empty;
        //private int[] Queue;
        //public MyCircularQueue(int k)
        //{
        //    Queue = new int[k];
        //    Head = 0;
        //    Tail = 0;
        //    Empty = true;
        //}

        ///** Insert an element into the circular queue. Return true if the operation is successful. */
        //public bool EnQueue(int value)
        //{
        //    if (IsFull())
        //        return false;
        //    Queue[Head] = value;
        //    Head = (Head + 1) % Queue.Length;
        //    return true;
        //}

        ///** Delete an element from the circular queue. Return true if the operation is successful. */
        //public bool DeQueue()
        //{
        //    if (IsEmpty())
        //        return false;
        //    Tail = (Tail + 1) % Queue.Length;
        //    return true;
        //}

        ///** Get the front item from the queue. */
        //public int Front()
        //{
        //    return Queue[Head];
        //}

        ///** Get the last item from the queue. */
        //public int Rear()
        //{
        //    return Queue[Tail];
        //}

        ///** Checks whether the circular queue is empty or not. */
        //public bool IsEmpty()
        //{
        //    return Empty;
        //}

        ///** Checks whether the circular queue is full or not. */
        //public bool IsFull()
        //{
        //    return !Empty && Head == Tail;
        //}



        //public void Print() {
        //    if (IsEmpty())
        //        return;
        //    var start = Exit;
        //    while (start != Enter) {
        //        Console.Write(Queue[start++] + "  ");
        //    }
        //    Console.WriteLine();
        //    Operation();
        //}

        //public void Operation(){
        //    Console.WriteLine("操作：");
        //    Console.WriteLine("1,Print");
        //    Console.WriteLine("2,Insert");
        //    Console.WriteLine("3,Delete");
        //    var key = Console.ReadLine();
        //    switch (key) {
        //        case "2":
        //            Insert();
        //            break;
        //        case "3":
        //            Delete();
        //            break;
        //    }
        //}

        //private void Insert()
        //{
        //    EnQueue(new Random().Next(0, 100000));
        //    Print();
        //}
        //private void Delete() {
        //    DeQueue();
        //    Print();
        //}
    }

    /**
     * Your MyCircularQueue object will be instantiated and called as such:
     * MyCircularQueue obj = new MyCircularQueue(k);
     * bool param_1 = obj.EnQueue(value);
     * bool param_2 = obj.DeQueue();
     * int param_3 = obj.Front();
     * int param_4 = obj.Rear();
     * bool param_5 = obj.IsEmpty();
     * bool param_6 = obj.IsFull();
     */
}
