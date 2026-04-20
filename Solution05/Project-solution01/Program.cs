using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace Project_solution01
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //#region Practice Tasks


            //Task 1 – Day Name Printer
            //    Console.WriteLine("Enter a number from 1 to 7:");
            //    int dayNumber = Convert.ToInt32(Console.ReadLine());

            //    switch (dayNumber)
            //    {
            //        case 1:
            //            Console.WriteLine("Monday");
            //            break;

            //        case 2:
            //            Console.WriteLine("Tuesday");
            //            break;

            //        case 3:
            //            Console.WriteLine("Wednesday");
            //            break;

            //        case 4:
            //            Console.WriteLine("Thursday");
            //            break;

            //        case 5:
            //            Console.WriteLine("Friday");
            //            break;

            //        case 6:
            //            Console.WriteLine("Saturday");
            //            break;

            //        case 7:
            //            Console.WriteLine("Sunday");
            //            break;

            //        default:

            //            Console.WriteLine("Invalid day number");
            //            break;
            //    }
            //    //Task 2 – Multiplication Table

            //    Console.WriteLine("Enter a number");
            //    int number = Convert.ToInt32(Console.ReadLine());

            //    // for loop runs 10 times
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        Console.WriteLine($"{number} x {i} = {number * i}");
            //    }


            //    //Task 3 – Countdown Timer

            //    Console.WriteLine("Enter a positive number:");
            //    int number = Convert.ToInt32(Console.ReadLine());

            //    // Check if number is NOT positive
            //    if (number <= 0)
            //    {
            //        Console.WriteLine("Please enter a positive number");
            //    }
            //    else
            //    {
            //        // Countdown using while loop
            //        while (number >= 1)
            //        {
            //            Console.WriteLine(number);
            //            number--;
            //        }

            //        Console.WriteLine("Go!");
            //    }


            //    //Task 4 – Season Detector with Month Validation
            //    Console.WriteLine("Enter a month number (1–12)");
            //    int month = Convert.ToInt32(Console.ReadLine());

            //    switch (month)
            //    {
            //        case 12:
            //        case 1:
            //        case 2:
            //            Console.WriteLine("Winter");
            //            break;

            //        case 3:
            //        case 4:
            //        case 5:
            //            Console.WriteLine("Spring");
            //            break;

            //        case 6:
            //        case 7:
            //        case 8:
            //            Console.WriteLine("Summer");
            //            break;

            //        case 9:
            //        case 10:
            //        case 11:
            //            Console.WriteLine("Autumn");
            //            break;

            //        default:
            //            // Handles month < 1 OR month > 12
            //            Console.WriteLine("Invalid month number");
            //            break;
            //    }


            //    //Task 5 – Sum of Even and Odd Numbers
            //    Console.WriteLine("Enter a positive integer N");
            //    int N = Convert.ToInt32(Console.ReadLine());

            //    // Check if N is positive
            //    if (N <= 0)
            //    {
            //        Console.WriteLine("Please enter a positive integer");
            //        return;
            //    }

            //    int evenSum = 0;
            //    int oddSum = 0;

            //    // Loop from 1 to N
            //    for (int i = 1; i <= N; i++)
            //    {
            //        // Check if number is even or odd
            //        if (i % 2 == 0)
            //        {
            //            evenSum += i; // Add to even sum
            //        }
            //        else
            //        {
            //            oddSum += i; // Add to odd sum
            //        }
            //    }

            //    // Print results
            //    Console.WriteLine($"Sum of even numbers = {evenSum}");
            //    Console.WriteLine($"Sum of odd numbers = {oddSum}");
            //}

            //Task 6 – Password Retry System

            //            string correctPassword = "1234";
            //            string userPassword = "";
            //            int attempts = 0;
            //            int maxAttempts = 3;

            //            while (attempts < maxAttempts)
            //            {
            //                Console.Write("Enter Password: ");
            //                userPassword = Console.ReadLine();

            //                if (userPassword == correctPassword)
            //                {
            //                    Console.WriteLine("Access Granted");
            //                    break;
            //                }
            //                else
            //                {
            //                    attempts++;

            //                    if (attempts == maxAttempts)
            //                    {
            //                        Console.WriteLine("Account Locked");
            //                    }
            //                    else
            //                    {
            //                        Console.WriteLine("Wrong password, try again");
            //                        Console.WriteLine($"Attempts remaining: {maxAttempts - attempts}");
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}


            

            //#endregion

            //#region For

            //for (int x = 1; x < 5; x++)
            //{
            //    Console.WriteLine("my age is 25");
            //}
            //    for (int x = 0; x < 5; x++) { 
            //    Console.WriteLine("Enter your number");
            //    int num= Convert.ToInt32(Console.ReadLine());
            //}

            //for (int x = 1; x <= 5; x++)
            //{
            //    for (int i = 1; i <= 5; i++)
            //    {

            //        Console.WriteLine((x,i));
            //    }
            //}


            //prime



            //Console.WriteLine("enter number");
            //int num = Convert.ToInt32(Console.ReadLine());
            //bool prime = true;
            //for (int i = 2; i < num; i++)
            //{

            //    if (num % i == 0)
            //    {
            //        prime = false;
            //        break;
            //    }
            //}
            //if (prime)
            //{
            //    Console.WriteLine("prime num");
            //}
            //else { Console.WriteLine("not prime num"); }
            //}

            //#endregion


            //#region while



            //Console.WriteLine("Please Enter number");
            //int num = Convert.ToInt32(Console.ReadLine());
            //while (num != 5)
            //{
            //    Console.WriteLine("Incrocet Number");
            //    num = Convert.ToInt32(Console.ReadLine());
            //}


            //    Console.WriteLine("Please Enter number");
            //    int x = Convert.ToInt32(Console.ReadLine());
            //    Random rnd = new Random();
            //    int num = rnd.Next(1, 10);
            //    int i;
            //    while (x != num)
            //    { 
            //        Console.WriteLine("Incorrect Number");
            //    x = Convert.ToInt32(Console.ReadLine());
            //}
            //#endregion


            //#region Random



            //Console.WriteLine("Please Enter number");
            //int x = Convert.ToInt32(Console.ReadLine());

            //Random rnd = new Random();

            //int num = rnd.Next(1, 10);
            //int i = 0;

            //while (x != num)
            //{
            //    i++;

            //    if (i < 3)
            //    {

            //        Console.WriteLine("Incorrect Number");
            //        x = Convert.ToInt32(Console.ReadLine());
            //    }
            //    else
            //    {
            //        Console.WriteLine("you used 3 tries");
            //        break;
            //    }
            //}
            //  #endregion



            #region reversed

           

            Console.WriteLine("Enter a word");
            string word = Console.ReadLine();

            string reversed = "";

            
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversed += word[i];
            }

            
            if (word == reversed)
            {
                Console.WriteLine("The word is Perfect");
            }
            else
            {
                Console.WriteLine("The word is NOT Perfect");
            }

          #endregion



        }

    }
    }






























