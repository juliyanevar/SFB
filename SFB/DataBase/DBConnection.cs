using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFB.DataBase
{
    public class DBConnection
    {
        private static string connectionStringApp = ConfigurationManager.ConnectionStrings["SFBConnection"].ConnectionString;
        public SqlConnection connection =new SqlConnection(connectionStringApp); 
    }
}
