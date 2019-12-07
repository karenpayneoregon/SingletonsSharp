using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cached.Classes
{
    class Class1
    {
        public static void DoSomething1(string something) 
        {
            using (var connection = new SqlConnection("..."))
            {
                connection.Open();

                // ...

                connection.Close();
            }
        }
        public static void Example(string statement, SqlConnection connection)
        {
            var openConn = (connection.State == ConnectionState.Open);
            if (!openConn)
            {
                connection.Open();
            }

            // ....

            if (openConn)
            {
                connection.Close();
            }
        }
    }
}
