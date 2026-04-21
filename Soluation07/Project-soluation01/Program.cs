namespace Project_soluation01
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //#region multiArray

            //Console.WriteLine("Enter number of rows");
            //int rows = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Enter number of cols");
            //int cols = Convert.ToInt32(Console.ReadLine());
            //int[,] numbers = new int[rows, cols];

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.WriteLine($"Enter number at position [ {i} , {j} ]");
            //        numbers[i, j] = Convert.ToInt32(Console.ReadLine());
            //    }
            //}

            //Console.WriteLine("Array elements");

            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write(numbers[i, j] + " ");
            //    }
            //    Console.WriteLine(); 
            //}
            //#endregion

            #region Student Management System Using Arrays 

            //Part 1 – Student Names(1D Array)
            string[] students = new string[5];

            Console.WriteLine("Enter 5 Student Names");

            for (int i = 0; i < students.Length; i++)
            {
                Console.Write("Student " + (i + 1) );
                students[i] = Console.ReadLine();
            }

            Console.WriteLine("Student Names");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i]);
            }


            // Part 2 – Student Grades 
            int[,] grades = new int[5, 3];

            string[] subjects = { "Math", "Science", "English" };

            Console.WriteLine("Enter Grades");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Grades for " + students[i]);

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(subjects[j] );
                    grades[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }


            //        // Part 3 – Display Student Grades
            Console.WriteLine("\nStudent Grades Table");

            Console.Write("Name\tMath\tScience\tEnglish\n");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(students[i] + "\t");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grades[i, j] + "\t");
                }

                Console.WriteLine();
            }


            //        // Part 4 – Calculate Student Average
            Console.WriteLine("Student Averages");

            double[] averages = new double[5];

            for (int i = 0; i < 5; i++)
            {
                int sum = 0;

                for (int j = 0; j < 3; j++)
                {
                    sum += grades[i, j];
                }

                averages[i] = sum / 3.0;

                Console.WriteLine(students[i] +
                    " Average = " + averages[i]);
            }


            // Part 5 – Jagged Array
            Console.WriteLine("Jagged Array");

            int[][] jaggedGrades = new int[5][];

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter number of subjects for "
                    + students[i] );

                int subjectsCount =
                    Convert.ToInt32(Console.ReadLine());

                jaggedGrades[i] = new int[subjectsCount];

                for (int j = 0; j < subjectsCount; j++)
                {
                    Console.Write("Enter grade " + (j + 1) );
                    jaggedGrades[i][j] =
                        Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Jagged Array Display");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(students[i] );

                for (int j = 0; j < jaggedGrades[i].Length; j++)
                {
                    Console.Write(jaggedGrades[i][j] );
                }

                Console.WriteLine();
            }


            // Part 6 – Search for Student
            Console.Write("\nEnter student name to search");
            string searchName = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].ToLower() ==
                    searchName.ToLower())
                {
                    Console.WriteLine("Student found at index"
                        + i);

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student not found");
            }


            // Part 7 – Find Highest Grade
            int highest = grades[0, 0];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grades[i, j] > highest)
                    {
                        highest = grades[i, j];
                    }
                }
            }

            Console.WriteLine("Highest Grade = " + highest);


            // BONUS 1 – Sort Students Alphabetically
            Array.Sort(students);

            Console.WriteLine("Sorted Students");

            foreach (string s in students)
            {
                Console.WriteLine(s);
            }


            // BONUS 2 – Student with Highest Average
            double maxAvg = averages[0];
            int maxIndex = 0;

            for (int i = 1; i < averages.Length; i++)
            {
                if (averages[i] > maxAvg)
                {
                    maxAvg = averages[i];
                    maxIndex = i;
                }
            }

            Console.WriteLine("Highest Average Student"
                + students[maxIndex] +
                " Avg = " + maxAvg);


            // BONUS 3 – Count Passed Students
            int passedCount = 0;

            for (int i = 0; i < 5; i++)
            {
                if (averages[i] >= 50)
                {
                    passedCount++;
                }
            }

            Console.WriteLine("\nNumber of Passed Students"
                + passedCount);






#endregion



        }
    }
}
