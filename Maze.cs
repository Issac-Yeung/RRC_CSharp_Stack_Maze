/*
* Name: Wai Lit Yeung 
* Program: Business Information Technology
* Course: ADEV-3009 Data Structure and Algorithms
* Created: 2 Oct 2023
* Updated:
*
*/
using System.Collections;
using System.Text;

namespace TestLibrary
{
    public class Maze
    {
        string? fileName;
        int startingRow;
        int startingColumn;
        int rowLength;
        int columnLength;
        char[][] charMaze;
        Point startingPoint;
        Point endPoint;
        Stack<Point> path;
        bool alreadyRunDepthFirstSearch;


        /// <summary>
        /// FileName
        /// </summary>
        public string? FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public int RowLength
        {
            get { return this.rowLength; }
            set { this.rowLength = value; }
        }

        public int ColumnLength
        {
            get { return this.columnLength; }
            set { this.columnLength = value; }
        }
        /// <summary>
        /// StartingRow
        /// </summary>
        public Point StartingPoint
        {
            get { return this.startingPoint; }
            set { this.startingPoint = value; }
        }

        /// <summary>
        /// Point Constructor with 3 parameters
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Maze(int startingRow , int startingColumn, char[][] existingMaze)
        {
            this.Validate(startingRow, startingColumn, existingMaze);

            this.startingRow = startingRow;
            this.startingColumn = startingColumn;
            this.rowLength = existingMaze.Length;
            this.columnLength = existingMaze[0].Length;
            this.startingPoint = new Point(this.startingRow, this.startingColumn);


            this.charMaze = existingMaze;
            this.startingPoint = new Point(this.startingRow, this.startingColumn);
            this.path = new Stack<Point>();
            this.alreadyRunDepthFirstSearch = false;
        }

        /// <summary>
        /// Maze Constructor with file name
        /// </summary>
        /// <param name="fileName"></param>
        public Maze(string fileName)
        { 
            this.fileName = fileName;

            string[] lines = File.ReadAllLines(this.fileName);
            this.rowLength = int.Parse(lines[0].Split(' ')[0]);
            this.columnLength = int.Parse(lines[0].Split(' ')[1]);
            this.startingRow = int.Parse(lines[1].Split(' ')[0]);
            this.startingColumn = int.Parse(lines[1].Split(' ')[1]);

            
            this.charMaze = new char[this.rowLength][];

            int mazeIndex = 0;
            // first 2 lines is maze size and x, y
            // the maze start at 3rd line
            for (int i = 2; i < this.rowLength + 2; i++)
            {
                this.charMaze[mazeIndex++] = lines[i].ToCharArray();
            }
            this.Validate(this.startingRow, this.startingColumn, this.charMaze);
            this.startingPoint = new Point(this.startingRow, this.startingColumn);
            this.path = new Stack<Point>();
            this.alreadyRunDepthFirstSearch = false;
        }

        /// <summary>
        /// GetStartingPoint
        /// </summary>
        /// <returns></returns>
        public Point GetStartingPoint()
        {
            return startingPoint;
        }

        /// <summary>
        /// GetRowLength
        /// </summary>
        /// <returns></returns>
        public int GetRowLength() => this.charMaze.Length;

        /// <summary>
        /// GetColumnLength
        /// </summary>
        /// <returns></returns>
        public int GetColumnLength() => this.charMaze.Length > 0 ? this.charMaze[0].Length : 0;


        /// <summary>
        /// GetMaze
        /// </summary>
        /// <returns></returns>
        public char[][] GetMaze()
        {
            return this.charMaze;
        }


        /// <summary>
        /// PrintMaze - Print the whole Maze
        /// </summary>
        /// <returns></returns>
        public string PrintMaze()
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0;i<charMaze.Length;i++)
            {
                string maze = new string(charMaze[i]);
                if (i < charMaze.Length - 1)
                    maze += "\n";
                sb.Append(maze);
            }
            return sb.ToString();
        }

        /// <summary>
        /// DepthFirstSearch
        /// </summary>
        /// <returns></returns>
        public string DepthFirstSearch()
        {
            string result = string.Empty;
            if (this.RunMaze(this.startingRow, this.startingColumn))
            {
                result = String.Format("Path to follow from Start [{0}, {1}] to Exit [{2}, {3}] - {4} steps:\n", this.startingRow, this.startingColumn, endPoint.Row, endPoint.Column, path.Size);
                result += this.PrintPath();
                result += this.PrintMaze();
            }
            else
            {
                result = "No exit found in maze!\n\n";
                result += this.PrintMaze();
            }
            this.alreadyRunDepthFirstSearch = true;
            return result;
        }   

        /// <summary>
        /// GetPathtoFollow
        /// </summary>
        /// <returns></returns>
        public Stack<Point> GetPathToFollow()
        {
            if (!this.alreadyRunDepthFirstSearch)
                throw new ApplicationException("Not yet run DepthFirstSearch()");
            
            return this.path.Clone(); 
        }

        /// <summary>
        /// RunMaze
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool RunMaze(int row, int column) 
        {
            // out of range or it is wall
            if (row < 0 || column < 0 || row >= this.charMaze.Length || column >= this.charMaze[row].Length || this.charMaze[row][column] == 'W')
                return false;

            // found distinestion 
            if (this.charMaze[row][column] == 'E')
            {
                path.Push(new Point(row, column));
                this.endPoint = new Point(row, column);
                return true;
            }

            // it is path or in starting point
            if (this.charMaze[row][column] == ' ' || (row == this.startingRow && column == this.startingColumn))
            {
                // remark correct path
                this.charMaze[row][column] = '.';
                // south -> east -> west -> north
                if (this.RunMaze(row + 1, column) || this.RunMaze(row, column + 1) || this.RunMaze(row - 1, column) || this.RunMaze(row, column - 1)) 
                {
                    path.Push(new Point(row, column));
                    return true;
                }
                // remark incorrect path
                this.charMaze[row][column] = 'V';
            }

            return false;
        }

        /// <summary>
        /// PrintPath - print route path from stack list
        /// </summary>
        /// <returns></returns>
        private string PrintPath() 
        {
            string result = string.Empty;
            Stack<Point> localPath = path.Clone();

            while (!localPath.IsEmpty())
            {
                result += localPath.Pop() + "\n";
            }
            return result;
        }


        /// <summary>
        /// Validate x,y location inside the maze
        /// </summary>
        /// <param name="startingRow"></param>
        /// <param name="startingColumn"></param>
        /// <param name="charMaze"></param>
        private void Validate(int startingRow, int startingColumn, char[][] charMaze)
        {
            if (startingRow >= charMaze.Length || startingRow < 0 || startingColumn >= charMaze[0].Length || startingColumn < 0)
                throw new IndexOutOfRangeException("Row or Column out of maze range.");

            if (charMaze[startingRow][startingColumn] == 'E' || charMaze[startingRow][startingColumn] == 'W')
                throw new ApplicationException("Starting Point cannot as Exit Point");

        }
    }
}
