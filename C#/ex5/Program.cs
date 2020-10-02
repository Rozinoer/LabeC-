using System;
using System.Collections;
using System.IO;

namespace Lab_11
{
    class Factory
    {
        public BankAccount CreateAccount() { return new BankAccount(); }
        public void DestroyBankAccount (BankAccount toDestroy) { }

        Hashtable hash1 = new Hashtable();

    }
    class BankTransaction : IFormattable
    {
        private Queue myQ = new Queue();
        DateTime now = DateTime.Now;
        readonly string datetime;
        readonly int changesum;

        public void bankstory(ref int sum, char x)
        {

            //myQ.Enqueue("F: " + now.ToString("F") + " изменение суммы на "+ x +  sum);
            myQ.Enqueue(DateTime.Now + " change of amount to " + x + sum);
            string queueElement = (string)myQ.Dequeue();
            Despoise(queueElement);
            Console.WriteLine(queueElement);
        }
        public void Despoise(string str)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "3.txt"), true))
            {
                outputFile.WriteLine(str);
            }

        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }

    enum bankname { VTB24, Сбербанк, Авангард };
    
    class BankAccount : BankTransaction 
    {
        private  int number;
        private double remain;
        private bankname Bankname;
        private static int ineedit = 0;
        string tipe;
        
        internal BankAccount()
        {
            remain = 0;
            number = Numberset();
            tipe = bankname.VTB24.ToString();
        }

        internal BankAccount(double um)
        {
            number = Numberset();
            this.remain = um;
            tipe = bankname.Авангард.ToString();
        }

        internal BankAccount(double um, string bankname1)
        {
            number = Numberset();
            this.remain = um;
            // this.Bankname = bankname1;
            Bankname = (bankname)Enum.Parse(typeof(bankname), bankname1);
        }

        internal BankAccount(string bankname1)
        {
            number = Numberset();

            Bankname = (bankname)Enum.Parse(typeof(bankname), bankname1);
        }

        public void ChangeRemain(double newRemain)
        {
            remain = newRemain;
        }
        public double Remain => remain;
        public int Number => number;
        //int ick;
        public int Numberset()
        {
            Random rand = new Random();
           // number = (rand.Next(200) + rand.Next(100) - rand.Next(50)) * 2 + 1;
           ineedit++;
            number = ineedit;
            return number;
        }
        public void Remainset(int um)
        {
            remain = um;
        }

        public void ChangeRemainmin(int per)
        {
            if (per > remain) { Console.WriteLine(" не удалось снять деньги с счета"); }
            else { remain -= per; Console.WriteLine(" деньги сняты с счета"); bankstory(ref per, '-'); }

        }

        public void ChangeRemainmin(int numac, int per)
        {
            if (number == numac)
            {
                if (per > remain) Console.WriteLine(" не удалось перевести деньги");
                else { remain -= per; Console.WriteLine(" деньги переведены -" + per); bankstory(ref per, '-'); }
            }
        }
        public void ChangeRemainadd(int percent)
        {
            Console.WriteLine("поступление на  счет");
            remain += percent; bankstory(ref percent, '+');
        }

        public string Change(string str)
        {
            Console.WriteLine(str);
            int j;
            string str1 = " ";
            int lenght = str.Length - 1;
            for (j = lenght; j >= 0; j--)
            {
                str1 += str[j];

            }
            Console.WriteLine(str1);
            return str1;
        }
        public void Showme()
        {
            Console.WriteLine("show me!");
            Console.WriteLine(remain);
            Console.WriteLine(number);
            Console.WriteLine(Bankname);

        }

    }
    class Program
    {
        static bool IsFormatable(object o) => o is System.IFormattable;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello consumer, i can help you!");
            BankAccount account = new BankAccount();

            account.Remainset(3000);
            int numac = account.Numberset();
            Console.WriteLine("номер вашего счета  " + numac);


            Console.WriteLine(account.Remain);
            account.ChangeRemainmin(1000);
            Console.WriteLine(account.Remain);
            account.ChangeRemainadd(30);
            Console.WriteLine(account.Remain);

            account.ChangeRemainmin(numac, 1000);
            Console.WriteLine("остаток на счету " + account.Remain);

            string str = account.Change("Hello consumer, i can help you!");
            BankAccount account2 = new BankAccount();
            account2.Showme();
            BankAccount account3 = new BankAccount(2);
            account3.Showme();
            BankAccount account4 = new BankAccount(2, "Сбербанк");
            account4.Showme();
            BankAccount account5 = new BankAccount("Сбербанк");
            account5.Showme();

            Console.WriteLine(IsFormatable(account));

            Console.ReadKey();
        }
    }
}





