using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_session_1
{
    public class BankAccount
    {

        public List<BankAccountModel> accounts { get; set; }
        public List<UserModel> users { get; set; }
        //string accountNumber;
        //string accountHolderName;
        //double balance;

        //public void SetAccountBalance(ref double amount)


        //{
        //    amount -= 5;
        //    if (amount <= 0)
        //    {
        //        Console.WriteLine("Invalid balance .please enter positive amount.");

        //    }
        //    else
        //    {
        //        balance = amount;
        //    }
        //}
        //public double GetAccountBalance(string password)
        //{
        //    if (password == "secert")
        //    {
        //        return balance;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid password");
        //        return 0;
        //    }
        //}
        //public void Deposit(double amount)
        //{
        //    if (amount <= 0)
        //    {
        //        Console.WriteLine("Invalid dwposit amount.please enter a positive amount");
        //    }
        //    else
        //    {
        //        balance += amount;
        //        Console.WriteLine($"Deposited{amount}.New balance {balance}");

        //    }
        //}

        //public void Withdraw(double amount)
        //{
        //    if (amount <= 0)
        //    {
        //        Console.WriteLine("Invalid dwposit amount.please enter a positive amount");
        //    }
        //    else if (amount > balance)
        //    {
        //        Console.WriteLine("Insufficient funds");
        //    }
        //    else
        //    {
        //        balance -= amount;
        //        Console.WriteLine($"Withdraw" +amount+"New balane" +balance);

        //    }


        //}
    }
}


    


