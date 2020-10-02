using System;

namespace lab8
{
   
     class BankAccount : IFormattable
    {
      
        private static int number = 0;
        private double remain;
        private enum BankName { VTB24, Сбербанк, Авангард };


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

        public void ChangeRemainmin(int numac, int per)
        {
            if (number == numac)
            {
                if (per > remain) Console.WriteLine(" не удалось перевести деньги");
                else { remain -= per; Console.WriteLine(" деньги переведены -" + per); }
            }
        }
        public void ChangeRemainadd(int percent)
        {
            Console.WriteLine("поступление на  счет");
            remain += percent;
        }

        public string Change(string str)
        {
            Console.WriteLine(str );
            int j;
            string str1  = " ";
            int lenght = str.Length - 1;
            for ( j = lenght; j>=0; j--)
            {
                str1 += str[j];
              
            }
            Console.WriteLine(str1);
            return str1;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {

        static bool IsFormatable(object o) => o is System.IFormattable;

        static void Main(string[] args)
        {


            Console.WriteLine("Hello consumer, i can help you!");
            BankAccount account = new BankAccount();
            
            account.Remainset (3000);
            int numac = account.Numberset();
Console.WriteLine("номер вашего счета  " + numac);


            Console.WriteLine(account.Remain);
            account.ChangeRemainmin(1000);
            Console.WriteLine(account.Remain);
            account.ChangeRemainadd(30);
            Console.WriteLine(account.Remain);

            account.ChangeRemainmin(numac, 1000);
            Console.WriteLine("остаток на счету "+account.Remain);

            string str = account.Change("Hello consumer, i can help you!");

            
            //bool IsFormattable (object o) => o is System.IFormattable;
            Console.WriteLine(IsFormatable(account));
           /* if (o is System.IFormattable)
            
                {
                    Console.WriteLine("it work!");
                }
            else
                {
                    Console.WriteLine("well, try another way");
                }*/
            

                Console.WriteLine();
            Console.ReadKey();

        }
    }
  
}




