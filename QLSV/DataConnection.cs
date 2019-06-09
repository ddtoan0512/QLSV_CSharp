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
        // Lop ket noi
        public DataConnection() {
            conStr = @"Data Source = TOANPC\SQLSERVER; Initial Catalog = QLSV; Integrated Security=True";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
