using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
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

        protected SqlConnection con = new SqlConnection(@"Data Source = TOANPC\SQLSERVER; Initial Catalog = QLSV; Integrated Security=True");
        public DataTable Load(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            return dt;
        }
    }
}
