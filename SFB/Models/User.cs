using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.Models
{
    public class User
    {
        public User() { }

        public User(string Login, string Password, string Mail)
        {
            this.Login = Login;
            this.Password = Password;
            this.Mail = Mail;
        }

        public User(int id, string Login, string Password, string Mail)
        {
            Id = id;
            this.Login = Login;
            this.Password = Password;
            this.Mail = Mail;
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
