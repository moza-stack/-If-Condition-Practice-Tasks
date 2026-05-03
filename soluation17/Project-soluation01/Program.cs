namespace Project_soluation01
{
    internal class Program
    {
        //#region Sum..Multiply


        //static int Sum(int a, int b)
        //{
        //    return a + b;
        //}
        //static int Multiply(int a, int b, int c)
        //{
        //    return a * b * c;
        //}

        //static int Sum(int a, int b, int c)
        //{
        //    return a + b + c;
        //}
        //static void Main()
        //{

        //    int result1 = Sum(2, 4);
        //    Console.WriteLine("sum two number" + result1);
        //    int result2 = Multiply(2, 4, 15);
        //    Console.WriteLine("multiplay three numbers " + result2);
        //    int result3 = Multiply(2, 4, 15);
        //    Console.WriteLine("sum three numbers " + result3);

        //    #endregion

        //#region Sum



        //static int Sum(int a, int b)
        //{
        //    return a + b;
        //}

        //static double Sum(double a, double b)
        //{
        //    return a + b;
        //}

        //static void Main()
        //{
        //    int result1 = Sum(2, 4);
        //    Console.WriteLine("sum two number (int)" + result1);

        //    double result2 = Sum(2.0, 4.0);
        //    Console.WriteLine("sum two number (double)" + result2);
        //    //#endregion

        #region

        static void Hello()
        {
            Console.WriteLine("Please Enter your Age");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 18)
            {
                Console.WriteLine("You are under 18");
            }
        }

        static void Main(string[] args)
        {
            Hello();

            #endregion
        }
    }
}
