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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalAssignment.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string strConnection = "Server='ASHLEY-PC\\SQLEXPRESS';Database='Inventory';Trusted_Connection=true";

            var strConnection = ConfigurationManager.ConnectionStrings["InventoryContext"].ConnectionString;

            SqlConnection con = new SqlConnection(strConnection);

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = con;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select ItemNumber as Item Number, Name, Cost, QuantityOnHand as Quantity on Hand from Item";
            SqlDataAdapter sqlDataAdap = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            sqlDataAdap.Fill(dt);
            dgInventory.ItemsSource = dt.DefaultView;
        }
    }
}