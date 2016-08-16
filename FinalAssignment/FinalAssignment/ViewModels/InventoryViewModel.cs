using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace FinalAssignment.ViewModels
{
    class InventoryViewModel : Screen
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter dataAdapt;
        private DataTable dataTab;

        public void ConnectDb()
        {
            conn = new SqlConnection();
        }
    }
}
