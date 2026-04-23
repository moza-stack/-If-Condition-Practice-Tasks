namespace Project_soluation01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = new string[100];
            int[] studentGrades = new int[100];

            int count = 0;
            int choice = 0;

            do
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");

                try
                {
                    Console.Write("Enter your choice ");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            // Add Student
                            Console.Write("Enter student name: ");
                            studentNames[count] = Console.ReadLine();

                            try
                            {
                                Console.Write("Enter student grade");
                                studentGrades[count] =
                                    Convert.ToInt32(Console.ReadLine());

                                count++;

                                Console.WriteLine("Student added successfully");
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Error: Grade must be a number");
                            }

                            break;

                        case 2:
                            // Display Students
                            Console.WriteLine("\n--- Student List ");

                            if (count == 0)
                            {
                                Console.WriteLine("No students available");
                            }
                            else
                            {
                                for (int i = 0; i < count; i++)
                                {
                                    Console.WriteLine(
                                        "Name: " + studentNames[i] +
                                        " | Grade: " + studentGrades[i]);
                                }
                            }

                            break;

                        case 3:
                            // Search Student
                            Console.Write("Enter student name to search");
                            string searchName = Console.ReadLine();

                            bool found = false;

                            for (int i = 0; i < count; i++)
                            {
                                if (studentNames[i]
                                    .ToLower() ==
                                    searchName.ToLower())
                                {
                                    Console.WriteLine(
                                        "Student Found: " +
                                        studentNames[i] +
                                        " | Grade: " +
                                        studentGrades[i]);

                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                Console.WriteLine("Student not found");
                            }

                            break;

                        case 4:
                            Console.WriteLine("Exiting program");
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number only.");
                }

            } while (choice != 4);
        


    }
    }
}
