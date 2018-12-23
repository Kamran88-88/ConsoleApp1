using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HR_Library
{
   public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool num; //bunlari daha sonra publiclikden cixart
        public int Number; //bunlari daha sonra publiclikden cixart

        public string Category { get; set; } //ish axtar ucun
        public string City { get; set; } //ish axtar ucun
        public int Salary { get; set; } //ish axtar ucun
        public int Age; // ish axtar
        public string Education { get; set; } //ish axtar
        public string Experience { get; set; } //ish axtar
        public string Phone { get; set; } //ish axtar

        public string Username { get; set; }
        public string E_mail { get; set; }
        public string Password { get; set; }

        public void Category_()
        {

            do //---------------
            {
                Console.WriteLine("Kateqoriya: ");
                Console.WriteLine("Hekim ------------1");
                Console.WriteLine("Jurnalist --------2");
                Console.WriteLine("IT mutexessis ----3");
                Console.WriteLine("Tercumeci --------4");
                num = int.TryParse(Console.ReadLine(), out Number);

                if (!(Number > 0 && Number <= 4))
                {
                    Console.Clear();
                    Console.WriteLine("Tekrar cehd edin!\n");
                }

            } while (!(Number > 0 && Number <= 4));

            switch (Number)
            {
                case 1: Category = "Hekim"; break;
                case 2: Category = "Jurnalist"; break;
                case 3: Category = "IT mutexessis"; break;
                case 4: Category = "Tercumeci"; break;
            }//----------------------
        }

        public void Age_()
        {
            bool age;
            do
            {
                Console.Write("Yash: ");
                age = int.TryParse(Console.ReadLine(), out Age);
                if (!age)
                {
                    Console.Clear();
                    Console.WriteLine("Tekrar cehd edin!");
                }
            } while (!(Age > 0));
        }

        public void Education_()
        {
            do
            {
                Console.WriteLine("Tehsil: ");
                Console.WriteLine("Orta ---------1");
                Console.WriteLine("Natamam ali --2");
                Console.WriteLine("Ali ----------3");
                num = int.TryParse(Console.ReadLine(), out Number);

                if (!(Number > 0 && Number < 4))
                {
                    Console.Clear();
                    Console.WriteLine("Tekrar cehd edin!\n");
                }

            } while (!(Number > 0 && Number < 4));

            switch (Number)
            {
                case 1: Education = "Orta"; break;
                case 2: Education = "Natamam ali"; break;
                case 3: Education = "Ali"; break;
            }
        }

        public void Experience_()
        {
            do
            {
                Console.WriteLine("Ish tecrubesi: ");
                Console.WriteLine("1 ilden ashagi ---------1");
                Console.WriteLine("1 ilden 3 ile qeder ----2");
                Console.WriteLine("3 ilden 5 ile qeder ----3");
                Console.WriteLine("5 ilden cox ------------4");
                num = int.TryParse(Console.ReadLine(), out Number);

                if (!(Number > 0 && Number <= 4))
                {
                    Console.Clear();
                    Console.WriteLine("Tekrar cehd edin!\n");
                }

            } while (!(Number > 0 && Number <= 4));

            switch (Number)
            {
                case 1: Experience = "1 ilden ashagi"; break;
                case 2: Experience = "1 ilden 3 ile qeder"; break;
                case 3: Experience = "3 ilden 5 ile qeder"; break;
                case 4: Experience = "5 ilden cox"; break;
            }
        }

        public void City_()
        {
            do
            {
                Console.WriteLine("Sheher: ");
                Console.WriteLine("Baki -----1");
                Console.WriteLine("Gence ----2");
                Console.WriteLine("Sheki ----3");
                Console.WriteLine("Sumqayit -4");
                num = int.TryParse(Console.ReadLine(), out Number);

                if (!(Number > 0 && Number <= 4))
                {
                    Console.Clear();
                    Console.WriteLine("Tekrar cehd edin!\n");
                }

            } while (!(Number > 0 && Number <= 4));

            switch (Number)
            {
                case 1: City = "Baki"; break;
                case 2: City = "Gence"; break;
                case 3: City = "Sheki"; break;
                case 4: City = "Sumqayit"; break;
            }
        }

        public void Salary_()
        {
            do
            {
                Console.WriteLine("Minimum emek haqqi: ");

                num = int.TryParse(Console.ReadLine(), out Number);

                if (!(Number >= 136))
                {
                    Console.Clear();
                    Console.WriteLine("Minimum emek haqqi 136 AZN olmalidir!\n");
                }
            } while (!(Number >= 136));
            Salary = Number;
        }
    }
}
