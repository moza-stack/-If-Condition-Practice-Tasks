namespace Project_soluation01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Stack, Queue, Dictionary

            
            Console.WriteLine("Hello, World!");


            // Dictionary → Student ID , Student Name
            Dictionary<int, string> students =
                new Dictionary<int, string>();



            // Queue → Waiting Line
            Queue<int> serviceQueue =
                new Queue<int>();

            // Stack → Undo Service
            Stack<int> servedStack =
                new Stack<int>();

            int choice = 0;

            do
            {
            
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Remove Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Join Service Queue");
                Console.WriteLine("6. Serve Next Student");
                Console.WriteLine("7. Undo Last Service");
                Console.WriteLine("8. Show Queue");
                Console.WriteLine("9. Exit");

                Console.Write("Enter choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {

                    //  Add Student
                    case 1:
                        Console.Write("Enter Student ID");
                        int id = Convert.ToInt32(Console.ReadLine());

                        if (students.ContainsKey(id))
                        {
                            Console.WriteLine("ID already exists");
                        }
                        else
                        {
                            Console.Write("Enter Student Name");
                            string name = Console.ReadLine();

                            students.Add(id, name);

                            Console.WriteLine("Student Added Successfully");
                        }
                        break;

                    

                    //  Update Student
                    case 2:
                        Console.Write("Enter Student ID to update");
                        int updateId =
                            Convert.ToInt32(Console.ReadLine());

                        if (students.ContainsKey(updateId))
                        {
                            Console.Write("Enter new name");
                            string newName =
                                Console.ReadLine();

                            students[updateId] = newName;

                            Console.WriteLine("Student Updated");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;


                    //  Remove Student
                    case 3:
                        Console.Write("Enter Student ID to remove");
                        int removeId =
                            Convert.ToInt32(Console.ReadLine());

                        if (students.ContainsKey(removeId))
                        {
                            students.Remove(removeId);

                            Console.WriteLine("Student Removed");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }
                        break;


                    // Show All Students
                    case 4:
                        Console.WriteLine("\nAll Students");

                        foreach (var student in students)
                        {
                            Console.WriteLine(
                                "ID: " + student.Key +
                                " Name: " + student.Value);
                        }

                        Console.WriteLine(
                            "Total Students"
                            + students.Count);

                        break;


                    //  Join Queue
                    case 5:
                        Console.Write("Enter Student ID to join queue");
                        int queueId =
                            Convert.ToInt32(Console.ReadLine());

                        if (students.ContainsKey(queueId))
                        {
                            serviceQueue.Enqueue(queueId);

                            Console.WriteLine(
                                students[queueId]
                                + " joined the queue");
                        }
                        else
                        {
                            Console.WriteLine("Student not found");
                        }

                        break;


                    //  Serve Next Student
                    case 6:

                        if (serviceQueue.Count > 0)
                        {
                            int servedId =
                                serviceQueue.Dequeue();

                            servedStack.Push(servedId);

                            Console.WriteLine(
                                students[servedId]
                                + " has been served");
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }

                        break;


                    //  Undo Last Service
                    case 7:

                        if (servedStack.Count > 0)
                        {
                            int undoId =
                                servedStack.Pop();

                            serviceQueue.Enqueue(undoId);

                            Console.WriteLine(
                                students[undoId]
                                + " returned to queue");
                        }
                        else
                        {
                            Console.WriteLine(
                                "No service to undo");
                        }

                        break;


                    //  Show Queue
                    case 8:

                        Console.WriteLine("\nWaiting Queue");

                        foreach (int qId in serviceQueue)
                        {
                            Console.WriteLine(
                                "ID: " + qId +
                                " Name: " + students[qId]);
                        }

                        Console.WriteLine(
                            "Queue Count"
                            + serviceQueue.Count);

                        break;


                    //  Exit
                    case 9:
                        Console.WriteLine("Exiting program");
                        break;


                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 9);

            #endregion
        }

    }
}
