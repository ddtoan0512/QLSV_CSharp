using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace QLSV
{
    class DataConnection
    {
        string conStr;

        public DataConnection() {
            conStr = "Data Source = TOAN-PC\\SQLEXPRESS; Initial Catalog = QLSV_BTL; Integrated Security=True";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
