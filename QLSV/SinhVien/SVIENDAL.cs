using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLSV
{
    class SVIENDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;

        public SVIENDAL()
        { 
            dc = new DataConnection();

        }
        public DataTable getAllSVien()
        { 
            
            //B1  Tao Cau Lenh Sql de lay toan bo sinh vien
            string sql = "SELECT * FROM tblSVIEN";
            // B2 Tao 1 Ket Noi Den SQL
            SqlConnection con = dc.getConnect();
            //B3 Khoi Tao  Doi Tuong Lop  SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4 Mo Ket Noi
            con.Open();
            //B5 Đổ dữ liệu từ SqlDataAdapter và DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B6 Dong Ket Noi
            con.Close();
            return dt;
        }

        public bool ThemSV(tblSVIEN sv)
        {
            string sql = "INSERT INTO tblSVIEN(MaSV, TenSV, GioiTinh, Lop, Diem, DiaChi, NgaySinh) VALUES(@MaSV, @TenSV, @GioiTinh, @Lop, @Diem, @DiaChi, @NgaySinh)";
            SqlConnection con = dc.getConnect();

            try
            { 
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar).Value = sv.MaSV ;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.Parameters.Add("@Lop", SqlDbType.VarChar).Value = sv.Lop;
                cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value = sv.Diem;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.VarChar).Value = sv.NgaySinh;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception e)
            {
                return false;       
            }
                return true;
        }

        public bool CapNhatSV(tblSVIEN sv)
        {
            string sql = "UPDATE tblSVIEN SET TenSV = @TenSV, GioiTinh = @GioiTinh, Lop = @Lop, Diem = @Diem, DiaChi = @DiaChi, NgaySinh = @NgaySinh WHERE MaSV = @MaSV";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar).Value = sv.TenSV;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = sv.GioiTinh;
                cmd.Parameters.Add("@Lop", SqlDbType.VarChar).Value = sv.Lop;
                cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value = sv.Diem;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.VarChar).Value = sv.NgaySinh;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool XoaSV(tblSVIEN sv)
        {
            string sql = "DELETE tblSVIEN  WHERE MaSV = @MaSV";
            SqlConnection con = dc.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar).Value = sv.MaSV;
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable TimKiemSV(string sv)
        {
            string sql = "SELECT * FROM tblSVIEN WHERE MaSV like N'%" + sv + "%' OR TenSV like N'%" + sv + "%' OR Lop like N'%" + sv + "%'" ;
            // B2 Tao 1 Ket Noi Den SQL
            SqlConnection con = dc.getConnect();
            //B3 Khoi Tao  Doi Tuong Lop  SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4 Mo Ket Noi
            con.Open();
            //B5 Đổ dữ liệu từ SqlDataAdapter và DataTable
            DataTable dt = new DataTable();
             da.Fill(dt);
            //B6 Dong Ket Noi
            con.Close();
            return dt;
        }

        
    }
}
