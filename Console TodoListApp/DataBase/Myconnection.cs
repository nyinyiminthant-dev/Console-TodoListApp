using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Console_TodoListApp.DataBase
{
    public static class Myconnection
    {
        public static SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "ToDoList",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

    }
}
