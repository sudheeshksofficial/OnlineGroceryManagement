using GroceryManage.DataAccess;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.Mstesting
{
    public class Testing
    {
        public readonly GroceryDbContext _context;
        public Testing()
        {

        }
        public Testing(GroceryDbContext context)
        {
            _context = context;
        }

        public int Loginchecker(int v1, int v2)
        {
            return v1 + v2;
        }
        public string Logincheck(string v1, string v2)
        {
            string messages;
            using (SqlConnection connection = new SqlConnection("data source=MC1JUNB2145; database=Complete;user id = sa; password = pass@word1"))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM [Complete].[dbo].[adminUsers] where AdminMail = '{v1}' and Password = '{v2}'; ", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                var num = command.ExecuteReader();

                if (num.HasRows)
                {
                    messages = "Success";
                    return messages;
                }
                else
                {
                    messages = "Failure";
                    return messages;
                }
                connection.Close();
            }
        }

        public string userLogincheck(string mail, string pass)
        {
            string messages;
            using (SqlConnection connection = new SqlConnection("data source=MC1JUNB2145; database=Complete;user id = sa; password = pass@word1"))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM [Complete].[dbo].[adminUsers] where AdminMail = '{mail}' and Password = '{pass}'; ", connection);
                command.CommandType = CommandType.Text;
                connection.Open();
                var num = command.ExecuteReader();

                if (num.HasRows)
                {
                    messages = "Success";
                    return messages;
                }
                else
                {
                    messages = "Failure";
                    return messages;
                }
                connection.Close();
            }
        }
    }
}
