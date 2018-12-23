using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Library;

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
}