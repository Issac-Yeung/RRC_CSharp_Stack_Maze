/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* Created: 2 Oct 2023
* Updated:
*
*/
namespace TestLibrary
{
    public class Point
    {
        int row;
        int column;

        /// <summary>
        /// Row
        /// </summary>
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        /// <summary>
        /// Column
        /// </summary>
        public int Column
        {
            get { return this.column; }
            set { this.column = value; }
        }

        /// <summary>
        /// Point Constructor with 3 parameters
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Point(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"[{row}, {column}]";
    }
}
