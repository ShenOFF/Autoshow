using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoShow
{
    public class Connection
    {
        public static DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");
            //try
            //{

                SqlConnection sqlConnection = new SqlConnection(MainWindow.mainWindow.con);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = selectSQL;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка в связи!!!");
            //    return dataTable;
            //}

        }


        //public static DataTable Ubuntu(string selectSQL)
        //{
        //    DataTable dataTable = new DataTable("dataBase");
        //    try
        //    {
        //        SqlConnection sqlConnection = new SqlConnection(MainWindow.mainWindow.conUbuntu);
        //        sqlConnection.Open();
        //        SqlCommand sqlCommand = sqlConnection.CreateCommand();
        //        sqlCommand.CommandText = selectSQL;
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        sqlDataAdapter.Fill(dataTable);
        //        return dataTable;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Ошибка в связи!!!");
        //        return dataTable; 
        //    }
        //}
    }
}
