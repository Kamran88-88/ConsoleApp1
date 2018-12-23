using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HR_Library
{
  public  class Worker : User
    {
        bool TrueFormat = false;
        public string gender { get; set; }
        public List<Advert> Appeal_adverts = new List<Advert>();
        public List<Employer> employer_offers = new List<Employer>();

        public void CV()
        {
            Console.WriteLine("CV melumatlarini daxil edin");
            Console.Write("Ad: ");
            Name = Console.ReadLine();
            Console.Write("Soyad: ");
            Surname = Console.ReadLine();
            Console.Write("Cins: ");
            gender = Console.ReadLine();
            Age_();
            Education_();
            Category_();
            Experience_();//----------------
            City_();
            Salary_();
            var PhoneForm = @"^(\+994)(50)|(51)|(55)|(70)|(77)(\d+){7}$";
            do
            {
                Console.Write("Mobil nomre: ");
                Phone = Console.ReadLine();
                TrueFormat = Regex.IsMatch(Phone, PhoneForm);
                if (!TrueFormat)
                {
                    Console.WriteLine("Sehv format! Bu formatda daxil edin: +994xxxxxxxxx");
                }
            } while (!TrueFormat);
            Console.Clear();
            Console.WriteLine("CV melumatlariniz ugurla elave edildi!");
            System.Threading.Thread.Sleep(3000);
        }

        public void Cv_info_show()
        {
            Console.Clear();
            Console.WriteLine("CV melumatlarim:\n");
            Console.WriteLine($"Ad: ------------------{Name}");
            Console.WriteLine($"Soyad: ---------------{Surname}");
            Console.WriteLine($"Cins: ----------------{gender}");
            Console.WriteLine($"Yash: ----------------{Age}");
            Console.WriteLine($"Tehsil ---------------{Education}");
            Console.WriteLine($"Is tecrubesi: --------{Experience}");
            Console.WriteLine($"Kateqoriya: ----------{Category}");
            Console.WriteLine($"Sheher: --------------{City}");
            Console.WriteLine($"Minimum emek haqqi: --{Salary}");
            Console.WriteLine($"Mobil nomre: ---------{Phone}\n");
            Console.WriteLine("Esas menyuya qayitmaq ucun \"Enter\" duymesini basin");
        }
        public void Muraciet_olunmush_elanlar()
        {
            switch (1)
            {

                case 1:
                    int num1 = -1;
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Muraciet_olunmush_elanlar:");
                        int count = 0;
                        foreach (var item in Appeal_adverts)
                        {
                            Console.WriteLine($"\nMuraciet No: --------{++count}");
                            Console.WriteLine($"Ish elaninin adi: -----{item.JobName}");
                            Console.WriteLine($"Shirketin adi: --------{item.Name}");
                        }
                        if (Appeal_adverts.Count > 0)
                        {
                            Console.WriteLine("Detalli baxmaq ucun elanin nomresini secin");
                        }
                        else
                        {
                            Console.WriteLine("Hec bir elana muraciet etmemisiz!");
                        }
                        Console.WriteLine("Esas Menyuya kecmek ucun \"0\" secin");
                        num1 = Controller.Nomre_sec(0, Appeal_adverts.Count);
                    } while (!(num1 >= 0 && num1 <= Appeal_adverts.Count));

                    if (num1 == 0)
                    {
                        break;
                    }
                    goto case 2;
                case 2:
                    Console.Clear();
                    int num2 = -1;
                    do
                    {
                        Console.WriteLine($"\nMuraciet No: -------------{num1}");
                        Console.WriteLine($"Ish elaninin adi: ------{Appeal_adverts[num1 - 1].JobName}");
                        Console.WriteLine($"Shirketin adi: ---------{Appeal_adverts[num1 - 1].Name}");
                        Console.WriteLine($"Kateqoriya: ------------{Appeal_adverts[num1 - 1].Category}");
                        Console.WriteLine($"Ish barede melumat: ----{Appeal_adverts[num1 - 1].JobInfo}");
                        Console.WriteLine($"Sheher: ----------------{Appeal_adverts[num1 - 1].City}");
                        Console.WriteLine($"Maash: -----------------{Appeal_adverts[num1 - 1].Salary}");
                        Console.WriteLine($"Yash: ------------------{Appeal_adverts[num1 - 1].Age}");
                        Console.WriteLine($"Tehsil: ----------------{Appeal_adverts[num1 - 1].Education}");
                        Console.WriteLine($"Staj: ------------------{Appeal_adverts[num1 - 1].Experience}");
                        Console.WriteLine($"Mobil tel: -------------{Appeal_adverts[num1 - 1].Phone}");
                        Console.WriteLine("\nGeri qayitmaq ucun \"0\" secin");
                        num2 = Controller.Nomre_sec(0, 0);
                        if (num2 == 0)
                        {
                            goto case 1;
                        }
                    } while (num2 != 0);

                    break;
            }
        }

        public void Teklfler()
        {
            int num1 = 0;
            switch (1)
            {
                case 1:
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Ish teklifleri:\n");
                        for (int i = 0; i < employer_offers.Count; i++)
                        {
                            Console.WriteLine($"\nTeklif No: --{i + 1}");
                            Console.WriteLine($"Shirketin adi: {employer_offers[i].adverts[0].Name}");
                            //Console.WriteLine($"Vakansiya: ----{employer_offers[i].JobName}");
                        }
                        Console.WriteLine("\nEtrafli baxmaq ucun Teklifin nomresini secin");
                        Console.WriteLine("Esas menyuya qayitmaq ucun \"0\" secin");
                        num1 = Controller.Nomre_sec(0, employer_offers.Count);
                    } while (!(num1 >= 0 && num1 <= employer_offers.Count));
                    if (num1 != 0)
                    {
                        goto case 2;
                    }
                    break;

                case 2:
                    Console.Clear();
                    int num2;
                    do
                    {
                        Console.WriteLine($"Shirketin adi: {employer_offers[num1 - 1].adverts[0].Name}");
                        Console.WriteLine("Shirketin butun elnlari:");
                        for (int i = 0; i < employer_offers[num1 - 1].adverts.Count; i++)
                        {

                            Console.WriteLine($"\nELAN No: {i + 1}");
                            Console.WriteLine($"Ish elaninin adi: ---{employer_offers[num1 - 1].adverts[i].JobInfo}");
                            Console.WriteLine($"Shirketin adi:-------{employer_offers[num1 - 1].adverts[i].Name}");
                            Console.WriteLine($"Kateqoriya:----------{employer_offers[num1 - 1].adverts[i].Category}");
                            Console.WriteLine($"Ish barede melumat:--{employer_offers[num1 - 1].adverts[i].JobInfo}");
                            Console.WriteLine($"Sheher:--------------{employer_offers[num1 - 1].adverts[i].City}");
                            Console.WriteLine($"Maash:---------------{employer_offers[num1 - 1].adverts[i].Salary}");
                            Console.WriteLine($"Yash:----------------{employer_offers[num1 - 1].adverts[i].Age}");
                            Console.WriteLine($"Tehsil:--------------{employer_offers[num1 - 1].adverts[i].Education}");
                            Console.WriteLine($"Staj:----------------{employer_offers[num1 - 1].adverts[i].Experience}");
                            Console.WriteLine($"Mobil tel:-----------{employer_offers[num1 - 1].adverts[i].Phone}\n");
                        }
                        Console.WriteLine("\nGeri qayitmaq ucun \"0\" secin");

                        num2 = Controller.Nomre_sec(0, 0);
                    } while (num2 != 0);
                    if (num2 == 0)
                    {
                        goto case 1;
                    }
                    break;
            }
        }

    }
}
