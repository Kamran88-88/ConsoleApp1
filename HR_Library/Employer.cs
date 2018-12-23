using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HR_Library
{
   public class Employer : Advert
    {
        public List<Advert> adverts = new List<Advert>();
        bool TrueFormat = false;

        public void Elan_yerleshdir()
        {
            Advert advert = new Advert();

            Console.Write("Ish elaninin adi: ");
            advert.JobName = Console.ReadLine();
            Console.Write("Shirketin adi: ");
            advert.Name = Console.ReadLine();
            advert.Category_();
            Console.Write("Is barede melumat: ");
            advert.JobInfo = Console.ReadLine();
            advert.City_();
            advert.Salary_();
            advert.Age_();
            advert.Education_();
            advert.Experience_();
            var PhoneForm = @"^(\+994)(50)|(51)|(55)|(70)|(77)(\d+){7}$";
            do
            {
                Console.Write("Mobil nomre: ");
                advert.Phone = Console.ReadLine();
                TrueFormat = Regex.IsMatch(advert.Phone, PhoneForm);
                if (!TrueFormat)
                {
                    Console.WriteLine("Sehv format! Bu formatda daxil edin: +994xxxxxxxxx");
                }
            } while (!TrueFormat);


            adverts.Add(advert);
        }

        public void Menim_elanlarim()
        {

            Console.WriteLine("Menim elanlarim:\n");
            for (int i = 0; i < adverts.Count; i++)
            {
                Console.WriteLine($"\nELAN No: {i + 1}");
                Console.WriteLine($"Ish elaninin adi: ---{adverts[i].JobName}");
                Console.WriteLine($"Shirketin adi:-------{adverts[i].Name}");
                Console.WriteLine($"Kateqoriya-----------{adverts[i].Category}");
                Console.WriteLine($"Ish barede melumat:--{adverts[i].JobInfo}");
                Console.WriteLine($"Sheher:--------------{adverts[i].City}");
                Console.WriteLine($"Maash:---------------{adverts[i].Salary}");
                Console.WriteLine($"Yash:----------------{adverts[i].Age}");
                Console.WriteLine($"Tehsil:--------------{adverts[i].Education}");
                Console.WriteLine($"Staj:----------------{adverts[i].Experience}");
                Console.WriteLine($"Mobil tel:-----------{adverts[i].Phone}\n");
            }

            if (adverts.Count == 0)
            {
                Console.WriteLine("Hele ki, elan yerleshdirmemisiz");
            }
            Console.WriteLine("Esas menyuya qayitmaq ucun \"Enter\" duymesini basin");
            string a = Console.ReadLine();
        }

        public void Muracietler()
        {
            if (adverts.Count > 0)
            {
                switch (1)
                {
                    case 1:
                        int num = 0;//----------->>
                        int elan_no = 0;
                        int number = 0;
                        Console.Clear();
                        do
                        {
                            Console.WriteLine("Elanlar ve muraciet sayi:\n");
                            foreach (var item in adverts)
                            {
                                Console.WriteLine($"\n==>Elan No: {++elan_no}, Elanin adi: {item.JobName}, \tmuraciet sayi: {item.User_Cvs.Count}");
                            }
                            elan_no = 0;
                            Console.WriteLine("\nDetalli baxmaq ucun elanin nomresini secin");
                            Console.WriteLine("Esas menyuya kechmek ucun \"0\" duymesini basin");
                            number = Controller.Nomre_sec(0, adverts.Count);

                        } while (!(number >= 0 && number <= adverts.Count));
                        if (number == 0)
                        {
                            break;
                        }
                        goto case 2;

                    case 2:
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("Elana edilmis muracietler siyahisi");
                            Console.WriteLine($"==>Elan No: {number}, Elanin adi: {adverts[number - 1].JobName}, \tmuraciet sayi: {adverts[number - 1].User_Cvs.Count}\n");

                            for (int i = 0; i < adverts[number - 1].User_Cvs.Count; i++)
                            {
                                Console.WriteLine($"-->>Muraciet No {i + 1}, adi: {adverts[number - 1].User_Cvs[i].Name}, kateqoriyasi: {adverts[number - 1].User_Cvs[i].Category}, tehsili: {adverts[number - 1].User_Cvs[i].Education}");
                            }
                            if (adverts[number - 1].User_Cvs.Count > 0)
                                Console.WriteLine("\nEtrafli baxmaq ucun muracietin nomresini secin");
                            else
                                Console.WriteLine("\nMuraciet yoxdur");
                            Console.WriteLine("Geri qayitmaq ucun \"0\" secin");
                            num = Controller.Nomre_sec(0, adverts[number - 1].User_Cvs.Count);
                            if (num == 0)
                            {
                                goto case 1;
                            }
                        } while (!(num >= 1 && num <= adverts[number - 1].User_Cvs.Count));//--------->>

                        goto case 3;
                    case 3:
                        Console.Clear();
                        int num1 = 1;
                        do
                        {
                            Console.WriteLine("Muracietin detallari\n");
                            Console.WriteLine($"Adi: ---------{adverts[number - 1].User_Cvs[num - 1].Name}");
                            Console.WriteLine($"Soyad: -------{adverts[number - 1].User_Cvs[num - 1].Surname}");
                            Console.WriteLine($"Cinsi: -------{adverts[number - 1].User_Cvs[num - 1].gender}");
                            Console.WriteLine($"Yash: --------{adverts[number - 1].User_Cvs[num - 1].Age}");
                            Console.WriteLine($"Tehsil: ------{adverts[number - 1].User_Cvs[num - 1].Education}");
                            Console.WriteLine($"Is tecrubesi: {adverts[number - 1].User_Cvs[num - 1].Experience}");
                            Console.WriteLine($"Kateqoriya: --{adverts[number - 1].User_Cvs[num - 1].Category}");
                            Console.WriteLine($"Sheher: ------{adverts[number - 1].User_Cvs[num - 1].City}");
                            Console.WriteLine($"Emek haqqi: --{adverts[number - 1].User_Cvs[num - 1].Salary}");
                            Console.WriteLine($"Mobil nomre: -{adverts[number - 1].User_Cvs[num - 1].Phone}");
                            Console.WriteLine("Geri qayitmaq ucun \"0\"  secin");
                            num1 = Controller.Nomre_sec(0, 0);
                            if (num1 == 0)
                            {
                                goto case 2;
                            }

                        } while (!(num1 == 0));
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Elan yerleshdirmemisiz!");
                System.Threading.Thread.Sleep(3000);
            }
        }
    }
}
