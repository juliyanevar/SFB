using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class Request
    {
        public Request()
        {

        }

        public Request(int id, string login, string mail, bool status)
        {
            Id = id;
            Login = login;
            Mail = mail;
            Status = status;
        }

        public Request(string login, string mail, bool status)
        {
            Login = login;
            Mail = mail;
            Status = status;
        }

        public Request(string login, string mail)
        {
            Login = login;
            Mail = mail;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
    }
}
