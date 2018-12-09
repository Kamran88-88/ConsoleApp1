using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {

            User user = new Worker();
            List<Worker> workers = new List<Worker>();
            List<Employer> employers = new List<Employer>();
            List<User> users = new List<User>();
            FileInfo directoryInfo1 = new FileInfo("Workers.json");
            FileInfo directoryInfo2 = new FileInfo("Employers.json");

            if (!directoryInfo1.Exists)
            {
                Controller.SerializeWorkers(workers);
            }

            if (!directoryInfo2.Exists)
            {
                Controller.SerializeEmployers(employers);
            }

            Controller.Deserialize(ref employers, ref workers);

            while (true)
            {
                switch (Controller.OperSerch())
                {
                    case 1: Controller.Sign_In(ref users, workers, employers); break;
                    case 2: Controller.Sign_Up(ref users, ref workers, ref employers); break;
                    case 3: Controller.Exit(employers, workers); break;
                }
                Console.Clear();
            }
        }
    }

    class Controller
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
            // System.Threading.Thread.Sleep(10000);
        }

        //public static void Muraciet_et(Worker worker)
        //{

        //}
    }

    class User
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


    class Worker : User
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

    class Advert : User
    {
        public string JobName { get; set; }
        public string JobInfo { get; set; }
        public List<Worker> User_Cvs = new List<Worker>();

    }
    class Employer : Advert
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