using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HR_Library
{
   public class Advert : User
    {
        public string JobName { get; set; }
        public string JobInfo { get; set; }
        public List<Worker> User_Cvs = new List<Worker>();

    }
}
