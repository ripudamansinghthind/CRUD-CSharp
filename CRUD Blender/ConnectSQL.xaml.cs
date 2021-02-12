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
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace CRUD_Blender {
    /// <summary>
    /// Interaction logic for ConnectSQL.xaml
    /// </summary>
    public partial class ConnectSQL : Window {
        List<Model> models = new List<Model>();
        readonly string ConString = ConfigurationManager.ConnectionStrings["BlenderDB"].ConnectionString;
        public ConnectSQL() {
            InitializeComponent();
            DataAccess db = new DataAccess();
            models = db.GetModel();
            GetModels();
        }
        private void GetModels() {
            using (SqlConnection con = new SqlConnection(ConString)) {
                FelixDataGrid.ItemsSource = models;
                models = null;
            }
        }
        private void SearchModels(object sender, EventArgs e) {
            Regex regex = new Regex(@"^\d$");
            if (ModelIDSearchBox.Text == "") {
                MessageBox.Show("No input, enter integer Model ID please :)", "User mistake", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (ModelIDSearchBox.Text == null) {
                MessageBox.Show("No input, enter integer Model ID please :)", "User mistake", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else {
                FelixDataGrid.ItemsSource = null;
                DataAccess db = new DataAccess();
                models = db.SearchModel(ModelIDSearchBox.Text);
                using (SqlConnection con = new SqlConnection(ConString)) {
                    FelixDataGrid.ItemsSource = models;
                    models = null;
                }
            }
        }

        private void DeleteModels(object sender, RoutedEventArgs e) {
            dynamic firstCellValue = FelixDataGrid.SelectedItem;
            DataAccess db = new DataAccess();
            if (FelixDataGrid.SelectedItem == null) {
                MessageBox.Show("Please Select a Model to Delete", "User mistake", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else {
                db.DeleteModel(firstCellValue.deletetrialgetter);
                GetModels();
            }
        }

        private void CloseButton_click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void RefreshButton_click(object sender, RoutedEventArgs e) {
            using (SqlConnection con = new SqlConnection(ConString)) {
                DataAccess db = new DataAccess();
                models = db.GetModel();
                FelixDataGrid.ItemsSource = models;
                models = null;
            }
        }
    }
}