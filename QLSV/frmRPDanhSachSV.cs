using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class frmRPDanhSachSV : Form
    {
        public frmRPDanhSachSV()
        {
            InitializeComponent();
        }

        protected SqlConnection con = new SqlConnection(@"Data Source = TOANPC\SQLSERVER; Initial Catalog = QLSV; Integrated Security=True");

        public DataTable Load2(string sql) {
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            return dt;
        }

        private void frmRPDanhSachSV_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();

            string sql = "Select * From tblSVIEN ";

            DataTable dt = new DataTable();
            dt = Load2(sql);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"../../rpDSSV.rdlc";
            if (dt.Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetSV";
                rds.Value = dt;
                // xoa du lieu cua bao cao cu trong trg hop ng dung thuc hien cau truy van khac
                reportViewer1.LocalReport.DataSources.Clear();
                // add du lieu
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("khong co du lieu");
            }
        }
    }
}
