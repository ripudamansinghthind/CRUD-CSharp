using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_Blender {
    class DbClass {

        public static string GetConnectionStrings() {
            string SubMainMenuString = ConfigurationManager.ConnectionStrings["conString"].ToString();
            return SubMainMenuString;
        }

        
        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;

        public static void openConnection() {
            try {
                if(con.State == ConnectionState.Closed) {
                    con.ConnectionString = GetConnectionStrings();
                    con.Open();
                }
            }
            catch(Exception ex) {
                MessageBox.Show("Connection Failed: The system failed to establish a connection." + Environment.NewLine +
                    "Descriptions: " + ex.Message.ToString(), "C# WPF Connect to SQL Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void closeConnection() {
            try {
                if (con.State == ConnectionState.Open) {
                    con.Close();
                }
            }
            catch(Exception) {
                //
            }
        }
    }
}
