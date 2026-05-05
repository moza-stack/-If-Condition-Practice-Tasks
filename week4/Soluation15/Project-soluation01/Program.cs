namespace Project_soluation01
{
    internal class Program
    {
        class Car
        {
            public string color;
            public int model_year { get; set; }

            private int temp;

            public int Speed
            {
                get { return temp; }
                set
                {
                    if (value > 0)
                        temp = value;
                    else
                        temp = 0;
                }
            }

            public void Drive()
            {
                color = "Red";
                model_year = 1999;
                temp = 0;
            }
        }

        static void Main(string[] args)
        {
            Car my_car = new Car();

            Console.WriteLine(my_car.Speed);

            Console.ReadLine();
        }
    }
}