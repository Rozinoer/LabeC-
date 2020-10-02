using System;

namespace laba10
{
    public interface ICipher
    {
        string Encode(ref string str);
        string Decode(ref string str);
    }

    public class ACipher : ICipher
    {
        public string Encode(ref string str)
        {
            char[] arr = new char[str.ToCharArray().Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if ((str[i] > 64 && str[i] < 91) || (str[i] > 96 && str[i] < 123))
                {

                    if (str[i] == 90) { arr[i] = (char)65; }
                    else if (str[i] == 122) { arr[i] = (char)97; }
                    else arr[i] = (char)(str[i] + 1);
                }
                else if (str[i] > 1039 && str[i] < 1104)
                {
                    if (str[i] == 1071) { arr[i] = (char)1040; }
                    else if (str[i] == 1103) { arr[i] = (char)1072; }
                    else arr[i] = (char)(str[i] + 1);
                }
                else arr[i] = (char)(str[i]);
            }

            str = new string(arr);
            return str;
        }
        public string Decode(ref string str)
        {
            char[] arr = new char[str.ToCharArray().Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if ((str[i] > 64 && str[i] < 91) || (str[i] > 96 && str[i] < 123))
                {
                    if (str[i] == 65) arr[i] = (char)90;
                    else if (str[i] == 97) arr[i] = (char)122;
                    else arr[i] = (char)(str[i] - 1);
                }
                else if (str[i] > 1039 && str[i] < 1104)
                {
                    if (str[i] == 1040) arr[i] = (char)1071;
                    else if (str[i] == 1072) arr[i] = (char)1103;
                    else arr[i] = (char)(str[i] - 1);
                }
                else arr[i] = (char)(str[i]);
            }
            str = new string(arr);
            return str;
        }
    }

    public class BCipher : ICipher
    {
        public string Encode(ref string str)
        {
            char[] arr = new char[str.ToCharArray().Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if ((str[i] > 64 && str[i] < 91) ||
                    (str[i] > 96 && str[i] < 123))
                {
                    if (str[i] < 91) { arr[i] = (char)(90 - str[i] + 65); }
                    else { arr[i] = (char)(122 - str[i] + 97); }
                }
                else if (str[i] > 1039 && str[i] < 1104)
                {
                    if (str[i] < 1072) arr[i] = (char)(1071 - str[i] + 1040);
                    else arr[i] = (char)(1103 - str[i] + 1072);
                }
                else arr[i] = str[i];
            }
            str = new string(arr);
            return str;
        }
        public string Decode(ref string str)
        {
            char[] arr = new char[str.ToCharArray().Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if ((str[i] > 64 && str[i] < 91) || (str[i] > 96 && str[i] < 123))
                {
                    if (str[i] < 91) arr[i] = (char)(90 - str[i] + 65);
                    else arr[i] = (char)(122 - str[i] + 97);
                }
                else if (str[i] > 1039 && str[i] < 1104)
                {
                    if (str[i] < 1072) arr[i] = (char)(1071 - str[i] + 1040);
                    else arr[i] = (char)(1103 - str[i] + 1072);
                }
                else arr[i] = str[i];
            }
            str = new string(arr);
            return str;
        }
    }

class Program
    {
        static void Main(string[] args)
        { int count = 0;
            do
            {
                Console.WriteLine("Введите строку");
                ACipher deafh = new ACipher();
                BCipher life = new BCipher();
                string line = Console.ReadLine();


                Console.WriteLine("1 - сдвиг");
                Console.WriteLine("2 - обмен");
                Console.WriteLine("3 - оба");


                int key = 0;
                Console.WriteLine("Выберите способ шифрования"); key = int.Parse(Console.ReadLine());

                switch (key)
                {
                    case 1:
                        {
                            line = deafh.Encode(ref line);
                            Console.WriteLine(line);
                            Console.WriteLine("хотите расшифровать: 1 - да, нет - любое введенное число ");
                            int ans = int.Parse(Console.ReadLine());
                            if (ans == 1)
                            {
                                deafh.Decode(ref line);
                                Console.WriteLine(line);
                            }
                            break;
                        }
                    case 2:
                        {
                            life.Encode(ref line);
                            Console.WriteLine(line);
                            Console.WriteLine("хотите расшифровать: 1 - да, нет - любое введенное число ");
                            int ans = int.Parse(Console.ReadLine());
                            if (ans == 1)
                            {
                                life.Decode(ref line);
                                Console.WriteLine(line);
                            }
                            break;
                        }
                    case 3:
                        {
                            line = deafh.Encode(ref line);
                            Console.WriteLine(line);
                            Console.WriteLine("хотите расшифровать: 1 - да, нет - любое введенное число ");
                            int ans = int.Parse(Console.ReadLine());
                            if (ans == 1)
                            {
                                deafh.Decode(ref line);
                                Console.WriteLine(line);
                            }
                            life.Encode(ref line);
                            Console.WriteLine(line);
                            Console.WriteLine("хотите расшифровать: 1 - да, нет - любое введенное число ");
                            ans = int.Parse(Console.ReadLine());
                            if (ans == 1)
                            {
                                life.Decode(ref line);
                                Console.WriteLine(line);
                            }


                            break;
                        }
                    default: break;

                }
                Console.WriteLine("хотите засшифровать еще одно сообщение: 1 - да, нет - любое введенное число ");
                count = int.Parse(Console.ReadLine());

            } while (count == 1);


        }
    }
}


