/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* MileStone 1: 10 Oct 2023
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestLibrary
{
    public class Stack<T>
    {
        private Node<T> head; // top node in the stack
        private int size; // number of nodes in the stack

        /// <summary>
        /// Stack Class
        /// </summary>
        public Stack()
        {
            head = null;
            size = 0;
        }

        public int Size => size; // size property using expression-bodied member

        public Node<T> Head => head; // head property using expression-bodied member

        // Pushes an item onto the top of the stack
        public void Push(T element)
        {
            Node<T> newNode = new Node<T>(element, head);
            head = newNode;
            size++;
        }

        // Returns and removes the top item from the stack
        public T Pop()
        {
            if (IsEmpty())
                throw new ApplicationException("Stack is empty.");

            T topItem = head.Element;
            head = head.Previous;
            size--;
            return topItem;
        }

        // Returns the top item from the stack without removing it
        public T Top()
        {
            if (IsEmpty())
                throw new ApplicationException("Stack is empty.");

            return head.Element;
        }

        // Empties the stack
        public void Clear()
        {
            head = null;
            size = 0;
        }

        // Checks if the stack is empty
        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public Stack<T> Clone()
        {
            Stack<T> temporaryStack = new Stack<T>();
            Stack<T> clonedStack = new Stack<T>();

            Node<T> currentNode = head;
            while (currentNode != null)
            {
                temporaryStack.Push(currentNode.Element);
                currentNode = currentNode.Previous;
            }

            while (!temporaryStack.IsEmpty())
            {
                clonedStack.Push(temporaryStack.Pop());
            }

            return clonedStack;
        }

    }
}
