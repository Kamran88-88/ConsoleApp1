using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace HR_Library
{
   public class Controller
    {
        static bool TrueForm = false;

        public static void Isci_axtar(User employer, List<Employer> employers, List<Worker> workers)
        {
            int num = 0;
            switch (1)
            {
                case 1:
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("Axtarishi ashagidaki kateqoriyalar uzre ede bilersiz");
                        Console.WriteLine("Kateqoriya --1");
                        Console.WriteLine("Tehsil-------2");
                        Console.WriteLine("Sheher-------3");
                        Console.WriteLine("Emek haqqi---4");
                        Console.WriteLine("Is tecrubesi-5\n");
                        Console.WriteLine("Esas menyuya qayitmaq ucun \"0\" duymesini basin");
                        num = Controller.Nomre_sec(0, 5);
                    } while (!(num >= 0 && num <= 5));
                    Console.Clear();
                    switch (num)
                    {
                        case 0:

                            Controller.Esas_Menu(ref employer, employers, workers); break;
                        case 1: employer.Category_(); break;
                        case 2: employer.Education_(); break;
                        case 3: employer.City_(); break;
                        case 4: employer.Salary_(); break;
                        case 5: employer.Experience_(); break;
                    }
                    if (num == 0)
                    {
                        break;
                    }
                    else
                    {
                        goto case 2;
                    }

                case 2:
                    Console.Clear();
                    int count = 0;
                    List<Worker> Rezumes = new List<Worker>();
                    switch (num)
                    {

                        case 1:
                            Rezumes = workers.Where(x => x.Category == employer.Category).ToList();
                            foreach (var item in Rezumes)
                            {
                                Console.WriteLine($"\nElanin No: {++count}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Kateqoriya: {item.Category}");
                            }
                            break;
                        case 2:
                            Rezumes = workers.Where(x => x.Education == employer.Education).ToList();
                            foreach (var item in Rezumes)
                            {
                                Console.WriteLine($"\nElanin No: {++count}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Tehsil: {item.Education}");
                            }
                            break;
                        case 3:
                            Rezumes = workers.Where(x => x.City == employer.City).ToList();
                            foreach (var item in Rezumes)
                            {
                                Console.WriteLine($"\nElanin No: {++count}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Sheher: {item.City}");
                            }
                            break;
                        case 4:
                            Rezumes = workers.Where(x => x.Salary == employer.Salary).ToList();
                            foreach (var item in Rezumes)
                            {
                                Console.WriteLine($"\nElanin No: {++count}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Emek haqqi: {item.Salary}");
                            }
                            break;
                        case 5:
                            Rezumes = workers.Where(x => x.Experience == employer.Experience).ToList();
                            foreach (var item in Rezumes)
                            {
                                Console.WriteLine($"\nElanin No: {++count}");
                                Console.WriteLine($"Name: {item.Name}");
                                Console.WriteLine($"Ish tecrubesi: {item.Experience}");
                            }
                            break;
                    }
                    goto case 3;
                case 3:
                    int num1 = 0;
                    if (Rezumes.Count > 0)
                    {
                        do
                        {
                            if (!(num1 >= 0 && num1 <= Rezumes.Count))
                            {
                                goto case 2;
                            }
                            Console.WriteLine("Etrafli baxmaq ucun elanin nomresini secin");
                            Console.WriteLine("Kateqoriyalara qayitmaq ucun \"0\" duymesini basin");
                            num1 = Controller.Nomre_sec(0, Rezumes.Count);
                        } while (!(num1 >= 0 && num1 <= Rezumes.Count));

                        if (num1 > 0)
                        {
                            do
                            {
                                Console.Clear();
                                Console.WriteLine($"Ad: ----------------{Rezumes[num1 - 1].Name}");
                                Console.WriteLine($"Soyad: -------------{Rezumes[num1 - 1].Surname}");
                                Console.WriteLine($"Cins: --------------{Rezumes[num1 - 1].gender}");
                                Console.WriteLine($"Yash: --------------{Rezumes[num1 - 1].Age}");
                                Console.WriteLine($"Tehsil:-------------{Rezumes[num1 - 1].Education}");
                                Console.WriteLine($"Is tecrubesi: ------{Rezumes[num1 - 1].Experience}");
                                Console.WriteLine($"Kateqoriya: --------{Rezumes[num1 - 1].Category}");
                                Console.WriteLine($"Sheher: ------------{Rezumes[num1 - 1].City}");
                                Console.WriteLine($"Minimum emek haqqi: {Rezumes[num1 - 1].Salary}");
                                Console.WriteLine($"Mobil nomre: -------{Rezumes[num1 - 1].Phone}\n");
                                Console.WriteLine("Teklif gondermek ucun \"1\" secin");
                                Console.WriteLine("Elanlara qayitmaq ucun \"0\" duymesini basin");

                                num1 = Controller.Nomre_sec(0, 1);
                            } while (!(num1 >= 0 && num1 <= 1));

                            if (num1 == 0)
                            {
                                goto case 2;
                            }
                            else
                            {
                                Console.WriteLine("Teklif gonderildi!");
                                Rezumes[num1 - 1].employer_offers.Add((employer as Employer));
                                System.Threading.Thread.Sleep(3000);
                                goto case 2;
                            }
                        }
                        else if (num1 == 0)
                        {
                            Console.Clear();
                            goto case 1;
                            //Controller.Esas_Menu(ref employer, employers, workers);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Axtarisha uygun hec bir elan tapilmadi");
                        System.Threading.Thread.Sleep(3000);
                        goto case 1;
                    }
                    break;
            }
        }
        public static void Show_All_adverts(User worker, List<Employer> employers, List<Worker> workers)//butunelanlari goster
        {



            var employAdverts = employers.Select(x => x.adverts);

            List<Advert> adverts = new List<Advert>();


            foreach (var item in employAdverts)
            {
                adverts.AddRange(item.Where(y => true));
            }


            Axtarish_ucun_kod_bloku(ref adverts, worker, employers, workers);
        }

        public static void Search(Worker worker, List<Employer> employers, List<Worker> workers)
        {

            var employAdverts = employers.Select(x => x.adverts);

            List<Advert> adverts = new List<Advert>();
            int num = 0;
            do
            {
                Console.WriteLine("Axtarishi ashagidaki kateqoriyalar uzre ede bilersiz");
                Console.WriteLine("Kateqoriya --1");
                Console.WriteLine("Tehsil-------2");
                Console.WriteLine("Sheher-------3");
                Console.WriteLine("Emek haqqi---4");
                Console.WriteLine("Is tecrubesi-5");
                num = Nomre_sec(1, 5);
            } while (!(num >= 1 && num <= 5));

            switch (num)
            {
                case 1:
                    foreach (var item in employAdverts)
                    {
                        if (item.Exists(x => (x.Category == worker.Category)))
                        {
                            adverts.AddRange(item.Where(y => y.Category == worker.Category));
                        }
                    }
                    break;
                case 2:
                    foreach (var item in employAdverts)
                    {
                        if (item.Exists(x => (x.Education == worker.Education)))
                        {
                            adverts.AddRange(item.Where(y => y.Education == worker.Education));
                        }
                    }
                    break;
                case 3:
                    foreach (var item in employAdverts)
                    {
                        if (item.Exists(x => (x.City == worker.City)))
                        {
                            adverts.AddRange(item.Where(y => y.City == worker.City));
                        }
                    }

                    break;
                case 4:
                    foreach (var item in employAdverts)
                    {
                        if (item.Exists(x => (x.Salary == worker.Salary)))
                        {
                            adverts.AddRange(item.Where(y => y.Salary == worker.Salary));
                        }
                    }

                    break;
                case 5:
                    foreach (var item in employAdverts)
                    {
                        if (item.Exists(x => (x.Experience == worker.Experience)))
                        {
                            adverts.AddRange(item.Where(y => y.Experience == worker.Experience));
                        }
                    }

                    break;

            }

            Axtarish_ucun_kod_bloku(ref adverts, worker, employers, workers);
            //System.Threading.Thread.Sleep(10000);
        }

        public static void Axtarish_ucun_kod_bloku(ref List<Advert> adverts, User worker, List<Employer> employers, List<Worker> workers)
        {
            int number = 0;
            Console.Clear();
            switch (1)
            {
                case 1:

                    for (int i = 0; i < adverts.Count; i++)
                    {

                        Console.WriteLine($"\nELAN No: {i + 1}");
                        Console.WriteLine($"Ish elaninin adi: ---{adverts[i].JobName}");
                        Console.WriteLine($"Shirketin adi:-------{adverts[i].Name}");
                    }
                    goto case 2;

                case 2:
                    do
                    {
                        if (adverts.Count > 0)
                        {
                            Console.WriteLine("Tam baxmaq ucun elanin nomresini secin");
                            Console.WriteLine("Esas menyuya qayitmaq ucun \"0\" duymesini basin");
                            number = Controller.Nomre_sec(0, adverts.Count);
                            if (number >= 1 && number <= adverts.Count)
                            {
                                int move = 0;
                                Console.Clear();
                                do
                                {
                                    Console.WriteLine($"\nELAN No: {number}");
                                    Console.WriteLine($"Ish elaninin adi: ---{adverts[number - 1].JobName}");
                                    Console.WriteLine($"Shirketin adi:-------{adverts[number - 1].Name}");
                                    Console.WriteLine($"Ish barede melumat:--{adverts[number - 1].JobInfo}");
                                    Console.WriteLine($"Sheher:--------------{adverts[number - 1].City}");
                                    Console.WriteLine($"Maash:---------------{adverts[number - 1].Salary}");
                                    Console.WriteLine($"Yash:----------------{adverts[number - 1].Age}");
                                    Console.WriteLine($"Tehsil:--------------{adverts[number - 1].Education}");
                                    Console.WriteLine($"Staj:----------------{adverts[number - 1].Experience}");
                                    Console.WriteLine($"Mobil tel:-----------{adverts[number - 1].Phone}\n");
                                    Console.WriteLine("Elana muraciet etmek ucun - 1");
                                    Console.WriteLine("Elanlara qayitmaq ucun ---- 2");
                                    move = Nomre_sec(1, 2);

                                    if (move == 2)
                                    {
                                        Console.Clear();
                                        goto case 1;
                                    }
                                    else if (move == 1)
                                    {
                                        adverts[number - 1].User_Cvs.Add(worker as Worker);
                                        var a = worker as Worker;
                                        a.Appeal_adverts.Add(adverts[number - 1]);

                                        Console.WriteLine($"{number} sayli elana CV-niz gonderildi");
                                        System.Threading.Thread.Sleep(3000);
                                        Console.Clear();
                                        Esas_Menu(ref worker, employers, workers);
                                    }

                                } while (!(move >= 1 && move <= 2));
                            }
                            else if (number == 0)
                            {
                                goto case 3;
                            }
                            else
                            {
                                // Console.Clear();
                                goto case 1;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hec bir elan tapilmadi");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            Esas_Menu(ref worker, employers, workers);
                            break;

                        }
                    } while (!(number >= 1 && number <= adverts.Count)); break;

                case 3:
                    Console.Clear();
                    Esas_Menu(ref worker, employers, workers);
                    break;
            }
        }

        public static int Nomre_sec(int min, int max)
        {
            bool num;
            int number = 0;
            // do
            //{
            num = int.TryParse(Console.ReadLine(), out number);
            if (!(number >= min && number <= max) || !num)
            {
                Console.Clear();
                Console.WriteLine("Sehv kod daxil etmisiz. Tekrar daxil edin!");
            }
            //} while (!(number >= 0 && number <= max));
            return number;
        }
        public static int OperSerch()
        {
            bool input;
            int number = 0;
            do
            {
                Console.WriteLine("Sign in - 1");
                Console.WriteLine("Sign up - 2");
                Console.WriteLine("Exit ---- 3");
                input = int.TryParse(Console.ReadLine(), out number);
                if (number != 1 && number != 2 && number != 3)
                {
                    Console.Clear();
                }
            } while (number != 1 && number != 2 && number != 3);

            return number;
        }

        public static void EmployerOrWorker(ref User user)
        {
            bool input;
            int number = 0;
            do
            {
                Console.WriteLine("Select registration format:");
                Console.WriteLine("Worker --- 1");
                Console.WriteLine("Employer - 2");

                input = int.TryParse(Console.ReadLine(), out number);
                switch (number)
                {
                    case 1: user = new Worker(); break;
                    case 2: user = new Employer(); break;
                }
            } while (number != 1 && number != 2);
        }


        public static void Esas_Menu(ref User user, List<Employer> employers, List<Worker> workers)
        {
            if (user != null)
            {
                var work1 = user is Worker;
                if (work1) //worker place
                {
                    var worker = user as Worker;
                    bool num;
                    int number = 0;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"Xosh gelmisiz {worker.Username} \nEsas Menu:");
                        Console.WriteLine("CV yerleshdir -------------\t1");
                        Console.WriteLine("Ish axtar -----------------\t2");
                        Console.WriteLine("Search --------------------\t3");
                        Console.WriteLine("CV melumatlari goster -----\t4");
                        Console.WriteLine("Butun elanlari goster -----\t5");
                        Console.WriteLine("Log out -------------------\t6");
                        Console.WriteLine("Muraciet olunmush elanlar -\t7");
                        Console.WriteLine("Teklifler -----------------\t8");

                        num = int.TryParse(Console.ReadLine(), out number);
                        if (!(number > 0 && number < 9))
                        {
                            Console.Clear();
                            Console.WriteLine("Sehv kod daxil etmisiz. Tekrar daxil edin!");
                        }
                    } while (!(number > 0 && number < 9));

                    switch (number)
                    {
                        case 1:
                            worker.CV();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 2: Controller.Ish_axtar(worker, employers, workers); break;
                        case 3: Controller.Search(worker, employers, workers); break;
                        case 4:
                            worker.Cv_info_show();
                            string num1 = Console.ReadLine();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 5:
                            Show_All_adverts(worker, employers, workers);
                            break;
                        case 6: break;
                        case 7:
                            worker.Muraciet_olunmush_elanlar();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 8:
                            worker.Teklfler();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                    }
                }
                else //employer place
                {
                    var employer = user as Employer;

                    bool num;
                    int number = 0;
                    Console.Clear();
                    do
                    {

                        Console.WriteLine($"Xosh gelmisiz {employer.Username} \nEsas Menu:");
                        Console.WriteLine("Elan yerlesdir -------------\t1");
                        Console.WriteLine("Isci axtar -----------------\t2");
                        Console.WriteLine("Muracietler ----------------\t3");
                        Console.WriteLine("Menim elanlarim ------------\t4");
                        Console.WriteLine("Log out --------------------\t5");

                        num = int.TryParse(Console.ReadLine(), out number);
                        if (!(number > 0 && number <= 5))
                        {
                            Console.Clear();
                            Console.WriteLine("Sehv kod daxil etmisiz. Tekrar daxil edin!");

                        }

                    } while (!(number > 0 && number <= 5));

                    switch (number)
                    {
                        case 1:
                            employer.Elan_yerleshdir();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 2:
                            Controller.Isci_axtar(employer, employers, workers);
                            Console.Clear();
                            break;
                        case 3:
                            employer.Muracietler();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 4:
                            Console.Clear();
                            employer.Menim_elanlarim();
                            Console.Clear();
                            Esas_Menu(ref user, employers, workers);
                            break;
                        case 5: break;
                    }
                }

            }
            else
            {
                Console.WriteLine("Istifadechi adi ve ya parol yanlishdir");
                System.Threading.Thread.Sleep(3000);
            }
        }

        public static void Sign_In(ref List<User> users, List<Worker> workers, List<Employer> employers)
        {
            users.Clear();
            users.AddRange(workers);
            users.AddRange(employers);

            Console.Write("UsenName: ");
            string Username = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();

            var user = users.SingleOrDefault(x => x.Username == Username && x.Password == Password);

            Esas_Menu(ref user, employers, workers);
        }

        public static void Sign_Up(ref List<User> users, ref List<Worker> workers, ref List<Employer> employers)
        {
            users.Clear();
            users.AddRange(workers);
            users.AddRange(employers);

            User user = new User();
            bool a;
            EmployerOrWorker(ref user);
            var work = user is Worker;

            do
            {
                var mailformat = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                var PasswordFormat = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
                Console.Clear();
                Console.WriteLine("Sign_Up:");
                if (work)
                {
                    Console.WriteLine("\nIsci qisminde:");
                }
                else
                {
                    Console.WriteLine("\nIshe goturen qisminde:");
                }
                Console.Write("UserName: ");

                user.Username = Console.ReadLine();
                do
                {
                    Console.Write("E_mail: ");
                    user.E_mail = Console.ReadLine();
                    TrueForm = Regex.IsMatch(user.E_mail, mailformat);
                    if (!TrueForm)
                    {
                        Console.Clear();
                        Console.WriteLine("Dogru formatta yazin. Meselen: Kamranaliyev@inbox.ru");
                        //.Threading.Thread.Sleep(3000);

                    }
                } while (!TrueForm);

                do
                {
                    Console.Write("Password: ");
                    user.Password = Console.ReadLine();
                    TrueForm = Regex.IsMatch(user.Password, PasswordFormat);
                    if (!TrueForm)
                    {
                        Console.Clear();
                        Console.WriteLine("Dogru formatta yazin. En azi bir boyuk, bir balaca herf ve  reqem olmalidir. 8-15 simvol arasi");
                    }
                } while (!TrueForm);

                a = users.Exists(x => x.Username == user.Username);
                if (a)
                {
                    Console.WriteLine("Bu login artiq movcuddur. Bashqa login secin");
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("Qeydiyyat ugurla basha catdi!");
                    System.Threading.Thread.Sleep(2000);
                }

            } while (a);


            if (work)
            {
                workers.Add(user as Worker);
            }
            else
            {
                employers.Add(user as Employer); //burada employer listine add edilmelidir
            }
        }

        public static void Exit(List<Employer> employers, List<Worker> workers)
        {

            SerializeEmployers(employers);
            SerializeWorkers(workers);
            Environment.Exit(0);
        }

        static JsonSerializerSettings jsonSetting = new JsonSerializerSettings();

        public static void SerializeEmployers(List<Employer> employers)
        {
            var Employerjson = JsonConvert.SerializeObject(employers, jsonSetting);

            using (StreamWriter writer1 = new StreamWriter("Employers.json"))
            {
                writer1.WriteLine(Employerjson);
            }
        }

        public static void SerializeWorkers(List<Worker> workers)
        {
            var Workerjson = JsonConvert.SerializeObject(workers, jsonSetting);

            using (StreamWriter writer = new StreamWriter("Workers.json"))
            {
                writer.WriteLine(Workerjson);
            }
        }





        public static void Deserialize(ref List<Employer> employers, ref List<Worker> workers)
        {

            using (StreamReader read = new StreamReader("Workers.json"))
            {
                var fromWorkfile = JsonConvert.DeserializeObject<List<Worker>>(read.ReadToEnd(), jsonSetting);
                workers = fromWorkfile;
            }

            using (StreamReader read1 = new StreamReader("Employers.json"))
            {
                var fromEmployFile = JsonConvert.DeserializeObject<List<Employer>>(read1.ReadToEnd(), jsonSetting);
                employers = fromEmployFile;
            }
        }

        public static void Ish_axtar(Worker worker, List<Employer> employers, List<Worker> workers)
        {
            var employAdverts = employers.Select(x => x.adverts);

            List<Advert> adverts = new List<Advert>();

            foreach (var item in employAdverts)
            {
                if (item.Exists(x => (x.Category == worker.Category || x.Education == worker.Education)))
                {
                    adverts.AddRange(item.Where(y => y.Category == worker.Category || y.Education == worker.Education));
                }
            }

            Axtarish_ucun_kod_bloku(ref adverts, worker, employers, workers);

        }
    }
}
