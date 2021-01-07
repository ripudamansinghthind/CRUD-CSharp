using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//
using System.Data;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_Blender {
    /// <summary>
    /// Interaction logic for ConnectSQL.xaml
    /// </summary>
    public partial class ConnectSQL : Window {
        public ConnectSQL() {
            InitializeComponent();
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e) {
            DbClass.openConnection();
            DbClass.sql = "SELECT * FROM RawMasterComponents";
            DbClass.cmd.CommandType = CommandType.Text;
            DbClass.cmd.CommandText = DbClass.sql;

            DbClass.da = new SqlDataAdapter(DbClass.cmd);
            DbClass.dt = new DataTable();
            DbClass.da.Fill(DbClass.dt);

            FelixDataGrid.ItemsSource = DbClass.dt.TableName;
            HeadingGrid.ItemsSource = DbClass.dt.DefaultView;

            DbClass.closeConnection();
        }
    }
}
