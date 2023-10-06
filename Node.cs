/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* Created: 3 Oct 2023
* Updated:
*
*/

namespace TestLibrary
{
    public class Node<T> 
    {
        private T? element;
        /// <summary>
        /// Element property
        /// </summary>
        public T? Element
        {
            get { return element; }
            set { element = value; }
        }

        private Node<T>? previousNode;
        /// <summary>
        /// Previous Perporty
        /// </summary>
        public Node<T>? Previous
        {
            get { return previousNode; }
            set { previousNode = value; }
        }

        private Node<T>? nextNode;
        /// <summary>
        /// NextNode Property
        /// </summary>
        public Node<T>? Next
        {
            get { return nextNode; }
            set { nextNode = value; }
        }

        /// <summary>
        /// Node Constructor with 3 parameters
        /// </summary>
        /// <param name="element"></param>
        /// <param name="previousNode"></param>
        /// <param name="nextNode"></param>
        public Node(T? element = default, Node<T>? previousNode = null, Node<T>? nextNode = null)
        {
            this.element = element;
            this.previousNode = previousNode;
            this.nextNode = nextNode;
        }

    }
}
