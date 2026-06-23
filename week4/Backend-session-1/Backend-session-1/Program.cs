namespace Backend_session_1
{
    public class Program
    {

        public static void RegisterUser(BankContext context)
        {
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            context.users.Add(new UserModel
            {
                username = username,
                Password = password,
                Email = email,
                userAccounts = new List<BankAccountModel>()
            });
            EmailService.SendEmail(email, "User Registration", "Thank you for registering with our banking system.");
            Console.WriteLine("User registered successfully");
        }
        public static void CreateAccount(BankContext context)
        {
            Console.WriteLine("Enter account number");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter account holder name");
            string accountHolderName = Console.ReadLine();
            Console.WriteLine("Enter email address");
            string emailAddress = Console.ReadLine();
            context.accounts.Add(new BankAccountModel
            {
                accountNumber = accountNumber,
                accountHolderName = accountHolderName,
                emailAddress = emailAddress,
                balance = 0
            });
            EmailService.SendEmail(emailAddress, "Account Creation", "Your account has been created successfully.");

            Console.WriteLine("Account created successfully");
        }
        public static void CreateAccountRelatedToUser(BankContext context)
        {
            Console.WriteLine("Enter account number");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter user username");
            string username = Console.ReadLine();

            foreach (UserModel user in context.users)
            {
                if (user.username == username)
                {
                    user.userAccounts.Add(new BankAccountModel
                    {
                        accountNumber = accountNumber,
                        balance = 0

                    });

                    EmailService.SendEmail(user.Email, "Account Creation", "Your account has been created successfully.");

                }
            }

            Console.WriteLine("Account created successfully");
        }
        public static void DepositAmount(BankContext context)
        {
            Console.WriteLine("Enter your account number");
            string depAccNum = Console.ReadLine(); 

            Console.WriteLine("Enter deposit amount");
            double depAmount = Convert.ToDouble(Console.ReadLine());

            bool accFound = false;
            foreach (BankAccountModel account in context.accounts) 
            {
                if (account.accountNumber == depAccNum)
                {
                    accFound = true;
                    if (BankAccountServices.Deposit(account, depAmount) == true)
                    {
                        Console.WriteLine("Amount deposited successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed to deposit amount");
                    }
                }
            }

            if (accFound == false)
            {
                Console.WriteLine("Account not found");
            }
        }

        public static void Main(string[] args)
        {
            BankContext context = new BankContext(); 
            context.accounts = new List<BankAccountModel>();
            context.users = new List<UserModel>();

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Welcome to the banking system");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register user");
                Console.WriteLine("2. Create Account");
                Console.WriteLine("3. Deposit amount");
                Console.WriteLine("4. Withdraw amount ");
                Console.WriteLine("5. Check balance");
                Console.WriteLine("6. Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        RegisterUser(context);
                        break;

                    case 2:
                        CreateAccount(context);
                        break;


                    case 3:
                        DepositAmount(context);
                        break;

                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }


            }

        }

        public static void commentedCode()
        {
            //public static void printBankAccountDetails(BankAccount b)
            //{
            //    Console.WriteLine($"Account Balance :{b.GetAccountBalance("secret")}");
            //}
            //static void Main(string[] args)
            //{

            //    Console.WriteLine("Enter amount");
            //    double amount = Convert.ToDouble(Console.ReadLine());

            //    //call by value vs by call reference
            //    BankAccount b = new BankAccount();
            //    b.SetAccountBalance(ref amount);
            //    printBankAccountDetails(b);
            //Console.WriteLine("enter initial balance");
            //double initialBalance = Convert.ToDouble(Console.ReadLine());
            //if (initialBalance <= 0)
            //{
            //    Console.WriteLine("Invalid balance .please enter positive amount");

            //}
            //else
            //{
            //    b.balance = initialBalance;
            //}

            //b. SetAccountBalance (-11);
        }
    }
}
