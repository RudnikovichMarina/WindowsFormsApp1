using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class User
    {
        private string login;
        private string password;

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string login_get()
        {
            return login;
        }

        public string password_get()
        {
            return password;
        }

        public bool IsCorrect()
        {
            DateB database = new DateB("Data Source = DateB.db; Version = 3;");

            if (database.CheckUser(this))
                return true;

            return false;
        }
    }

}
