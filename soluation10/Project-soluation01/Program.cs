namespace Project_soluation01
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
            int num1 = GetNumber("Enter first number:");
            int num2 = GetNumber("Enter second number:");

          
            int sum = Add(num1, num2);
            Console.WriteLine("Sum = " + sum);

           
            Console.WriteLine("Do you want another operation? (yes/no)");
            string answer = Console.ReadLine();

        
            if (answer.ToLower() == "yes")
            {
                int mul = Multiply(num1, num2);
                Console.WriteLine("Multiply = " + mul);
            }
            else
            {
                Console.WriteLine("Program stopped.");
            }
        }

        
        static int GetNumber(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        
        static int Add(int x, int y)
        {
            return x + y;
        }

        
        static int Multiply(int x, int y)
        {
            return x * y;
        


    }
    }
}
