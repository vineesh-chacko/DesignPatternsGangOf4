namespace DesignPatternPlayground
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {

            /* visitor Pattern client code 
            
            VisitorDemo.Person person = new VisitorDemo.Person();
            person.AssetList.Add(new VisitorDemo.BankAccount { Amount = 1000, MonthlyInterest = 0.02 });
            person.AssetList.Add(new VisitorDemo.BankAccount { Amount = 12000, MonthlyInterest = 0.05 });
            person.AssetList.Add(new VisitorDemo.Loan { Owned = 1000, MonthlyPayment = 250 });
            person.AssetList.Add(new VisitorDemo.RealEstate { EstimatedValue = 10000, Rent = 2000 });

            VisitorDemo.NetWorthVisitor networth = new VisitorDemo.NetWorthVisitor();
            VisitorDemo.IncomeVisitor income = new VisitorDemo.IncomeVisitor();

            person.Accept(networth);
            person.Accept(income);

            Console.WriteLine(networth.Total);
            Console.WriteLine(income.Amount);
            Console.ReadLine();

            */

            /* Observer Pattern Client code */
            string strCustomerCode = "asdfdsafdsafdsafdsafsadfdsafds";
            Notifier objNotifier = new Notifier();
            EmailNotifications email = new EmailNotifications();
            EventNotification eventLog = new EventNotification();

            objNotifier.AddNotification(email);
            objNotifier.AddNotification(eventLog);

            if (strCustomerCode.Length > 10)
                objNotifier.NotifyAll();

            


        }

        public void PrintMatrix(int _i, int _j)
        {
            int i = _i;
            int j = _j;

            int[,] matrix = new int[i, j];

            for (int l = 0; l < i; l++)
            {
                for (int m = 0; m < j; m++)
                {
                    if (l == m)
                    {
                        matrix[l, m] = 0;
                    }
                    else if (l > m)
                    {
                        matrix[l, m] = -1;
                    }
                    else
                    {
                        matrix[l, m] = 1;
                    }
                }
            }

            // print matrix 
            for (int a = 0; a < _i; a++)
            {
                for (int b = 0; b < _j; b++)

                {
                    Console.Write(string.Format("{0}\t", matrix[a, b]));
                    //Console.Write(matrix[a,b]);


                }
                Console.WriteLine();
            }
        }
    }
}
