using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    public delegate void AccountHandler(string message);

    public class Account
    {
        public int sum;

        AccountHandler taken;

        public Account(int sum) => this.sum = sum;

        public void RegisterHandler(AccountHandler del)
        {
            taken += del;
        }

        public void UnregisterHandler(AccountHandler del)
        {
            taken -= del;
        }

        public void Summa(int sum) => this.sum += sum;

        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
            }

        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            void PrintSimpleMessage(string message) => Console.WriteLine(message);


            Account account = new Account(1000);

            account.RegisterHandler(PrintSimpleMessage);

            account.Take(500);
            account.Take(600);
        }
    }
}
