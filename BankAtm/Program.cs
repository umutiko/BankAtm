using System;

namespace BankAtm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            int[] accounts = { 2500, 1200, 6000, 10000, 7450, 4569 };
            string repeat;
            int processNumber; 
            #endregion

            void ShowMenu()
            {
                Console.WriteLine("Brave ATM Welcome :)");
                Console.WriteLine("---------------------");
                Console.WriteLine("Please select your transaction");
                Console.WriteLine("1 - Withdraw Money");
                Console.WriteLine("2 - Deposit Money");
                Console.WriteLine("3 - Transfer Money");
            }

            Console.WriteLine("Press a key to get started");
            Console.ReadLine();

            do
            {
                ShowMenu();
                processNumber = Convert.ToInt32(Console.ReadLine());
                Process();
                Console.WriteLine("Do you want to take another action ? (Y/N)");
                repeat = Console.ReadLine();
            }
            while (repeat == "y" || repeat == "Y");

            void Process()
            {
                switch (processNumber)
                {
                    case 1:
                        MakeADeposit(ProcessType.WithdrawMoney);
                        break;
                    case 2:
                        MakeADeposit(ProcessType.DepositMoney);
                        break;
                    case 3:
                        TransferMoney();
                        break;
                }
            }

            void MakeADeposit(ProcessType processType)
            {
                Console.WriteLine("Choose an account  :");
                ShowAccounts();

                int accountNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the amount");
                int amount = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= accounts.Length; i++)
                {
                    if (i == accountNumber)
                    {
                        int account = accounts[i - 1];
                        account = processType == ProcessType.WithdrawMoney ? account - amount : processType == ProcessType.DepositMoney ? account + amount : account;

                        Console.WriteLine("Your transaction is in progress,please wait...");
                        System.Threading.Thread.Sleep(1500);
                        if (account >= 0)
                        {
                            accounts[i - 1] = account;
                            ShowAccounts(accountNumber);
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough funds !");
                            ShowAccounts(accountNumber);
                        }
                    }
                }
            }

            void TransferMoney()
            {
                Console.WriteLine("Choose an account  :");
                ShowAccounts();
                Console.Write("1. Account : ");
                int firstAccount = Convert.ToInt32(Console.ReadLine());
                Console.Write("2. Account : ");
                int secondAccount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the amount : ");
                int amount = Convert.ToInt32(Console.ReadLine());

                if (accounts[firstAccount - 1] != -1 && accounts[secondAccount - 1] != -1)
                {
                    int fA = accounts[firstAccount - 1] - amount;
                    int sA = accounts[secondAccount - 1] + amount;

                    Console.WriteLine("Your transaction is in progress,please wait...");
                    System.Threading.Thread.Sleep(1500);
                    if (firstAccount >= 0 && secondAccount >= 0)
                    {
                        accounts[firstAccount - 1] = fA;
                        accounts[secondAccount - 1] = sA;
                        ShowAccounts(firstAccount);
                        Console.WriteLine("----------------------");
                        ShowAccounts(secondAccount);
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough funds !");
                        ShowAccounts(firstAccount);
                    }
                }
            }

            void ShowAccounts(int index = 0)
            {
                if (index > 0)
                {
                    Console.WriteLine("Account");
                    Console.WriteLine("--------------");
                    for (int i = 1; i <= accounts.Length; i++)
                        if (index == i)
                            Console.WriteLine($"Account Number: {i} | Available Balance: {accounts[i - 1]}");
                }
                else
                {
                    Console.WriteLine("Accounts");
                    Console.WriteLine("--------------");
                    for (int i = 1; i <= accounts.Length; i++)
                        Console.WriteLine($"Account Number: {i} | Available Balance: {accounts[i - 1]}");
                }
            }
        }
        enum ProcessType
        {
            WithdrawMoney,
            DepositMoney
        }
    }
}