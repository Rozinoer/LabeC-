using System;

namespace project
{
   
    class BankAccount
    {
        private static int number;
        private double remain;
        private enum bankName { VTB24, Сбербанк, Авангард };


        public void ChangeRemain(double newRemain)
        {
            remain = newRemain;
        }
        public double Remain => remain;
        public int Number => number;

        public int Numberset()
        {            Random rand = new Random();

            

            number = (rand.Next(200) + rand.Next(100) - rand.Next(50)) *2 +1;
             
            return number;
        }
        public void Remainset(int um)
        {
            remain = um;
        }

        public void ChangeRemainmin(int per)
        {
            if (per > remain)  Console.WriteLine(" не удалось снять деньги с счета") ;
            else {remain -= per; Console.WriteLine(" деньги сняты с счета"); }
        }

         public void ChangeRemainadd(int percent)
        {
            Console.WriteLine("поступление на  счет");
            remain += percent;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Hello consumer, i can help you!");
            BankAccount account = new BankAccount();
            
            account.Remainset (2000);
Console.WriteLine("номер вашего счета  " + account.Numberset());


            Console.WriteLine(account.Remain);
            account.ChangeRemainmin(1000);
            Console.WriteLine(account.Remain);
            account.ChangeRemainadd(30);
            Console.WriteLine(account.Remain);
            Console.ReadKey();
            
        }
    }
}

