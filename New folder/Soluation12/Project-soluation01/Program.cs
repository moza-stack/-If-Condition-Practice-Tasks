namespace Project_soluation01
{
    internal class Program
    {
        #region Queue

        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Queue<string> names = new Queue<string>();
            names.Enqueue("moza");
            names.Enqueue("basma");
            names.Enqueue("zahra");
            names.Enqueue("mohammed");

            int choice;

            do
            {
                
                Console.WriteLine("1. Add String");
                Console.WriteLine("2. Print First String");
                Console.WriteLine("3. Delete First element");
                Console.WriteLine("4. Show all elements");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.Write("Enter name to add");
                        string newName = Console.ReadLine();
                        names.Enqueue(newName);
                        Console.WriteLine("Name added");
                        break;

                    case 2:

                        if (names.Count > 0)
                        {
                            Console.WriteLine("First name" + names.Peek());
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;

                    case 3:

                        if (names.Count > 0)
                        {
                            string removed = names.Dequeue();
                            Console.WriteLine("Removed " + removed);
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;

                    case 4:
                        
                        if (names.Count > 0)
                        {
                            Console.WriteLine("All names");
                            foreach (string name in names)
                            {
                                Console.WriteLine(name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Queue is empty");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Program ended");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 5);
#endregion



            







        }
    }
}
