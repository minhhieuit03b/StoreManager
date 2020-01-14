using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHVatLieuXayDung.DA_Layer
{
    class DataProvider
    {
        public static string dbsource;
        public static string id;
        public static string pass;
        SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder(); //Tạo đối tượng connectionString
        public DataProvider(string dbsource, string id, string pass)
        {
            DataProvider.dbsource = dbsource;
            DataProvider.id = id;
            DataProvider.pass = pass;
            InitialConnectionString(dbsource, id, pass);
        }
        public void InitialConnectionString(string dbsource, string id, string pass) //Khởi tạo các giá trị cho connectionString
        {
            connectionString.DataSource = dbsource;
            connectionString.InitialCatalog = "QL_CHangVatLieuXayDung";
            //connectionString.IntegratedSecurity = true;
            connectionString.UserID = id;
            connectionString.Password = pass;
        }
        public bool TestConnection(string dbsource, string id, string pass)
        {
            try
            {
                var connection = new SqlConnection(connectionString.ToString());
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            //} //Phương thức kiểm tra kết nối
        }
        public DataTable ExecuteQueryDataTable(string cmdText, CommandType cmdType, params SqlParameter[] param) //truy vấn SQL và trả về 1 table
        {
            using (var connection = new SqlConnection(connectionString.ToString()))
            {

                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType = cmdType;

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    connection.Open();

                    var dataAdapter = new SqlDataAdapter(cmd);

                    var dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    connection.Close();

                    return dataTable;
                }
            }
        }
        public bool ExecuteNonQuery(string cmdText, CommandType cmdType, params SqlParameter[] param)
        {
            using (var connection = new SqlConnection(connectionString.ToString()))
            {
                using (var cmd = new SqlCommand(cmdText, connection))
                {


                    cmd.CommandType = cmdType;

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    connection.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0) return false;

                    connection.Close();

                    return true;
                }
            }
        }//truy vấn SQL và trả về kiểu dữ liệu bool
        public Object ExecuteScalar(string cmdText, CommandType cmdType, params SqlParameter[] param)
        {
            using (var connection = new SqlConnection(connectionString.ToString()))
            {
                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.CommandType = cmdType;

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    connection.Open();

                    var result = cmd.ExecuteScalar();

                    connection.Close();

                    return !result.ToString().Equals("NULL") ? result : 0;
                }
            }
        }//Truy vấn SQL và trả về kiểu dữ liệu Object

        public T ExecuteScalar<T>(string cmdText, CommandType cmdType, params SqlParameter[] param)
        {
            using (var connection = new SqlConnection(connectionString.ToString()))
            {
                using (var cmd = new SqlCommand(cmdText, connection))
                {
                    connection.Open();

                    cmd.CommandType = cmdType;

                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    var result = cmd.ExecuteScalar();

                    connection.Close();

                    return (T)result;
                }
            }
        }
    }
}
