using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace PracticeApplication
{
    public static class Querys
    {
        const string ConnectionAdres = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\MainDatabase.mdf;MultipleActiveResultSets=True;";

        public static DataTable readEmployers()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Сотрудники]", ConnectionAdres);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static SecurityPosition fillPosition()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);

            SecurityPosition securityPosition = null;
            SqlCommand nameComand = new SqlCommand($"SELECT [Id], [Название] FROM [Должности]", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = nameComand.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                var positionId = reader.GetString(0);
                var positionName = reader.GetString(1);
                securityPosition = new SecurityPosition { positionId = positionId, positionName = positionName };
            }
            reader.Close();
            sqlConnection.Close();
            return securityPosition;
        }
    }
}
