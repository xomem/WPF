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
        public static IEnumerable<SecurityPosition> fillPosition()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);

            SqlCommand nameComand = new SqlCommand($"SELECT [Id], [Название] FROM [Должности]", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = nameComand.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var positionId = reader.GetInt32(0);
                    var positionName = reader.GetString(1);
                    yield return new SecurityPosition { positionId = positionId, positionName = positionName };
                }
            }
            reader.Close();
            sqlConnection.Close();
        }
        public static IEnumerable<SecurityDepartment> fillDepartment()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);

            SqlCommand nameComand = new SqlCommand($"SELECT [Id], [Название отдела] FROM [Отделы]", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = nameComand.ExecuteReader();
            reader.Read();
            //if (reader.HasRows)
            //{
                while (reader.Read())
                {
                    var departmentId = reader.GetInt32(0);
                    var departmentName = reader.GetString(1);
                    yield return new SecurityDepartment { departmentId = departmentId, departmentName = departmentName };
                }
            //}
            reader.Close();
            sqlConnection.Close();
        }
        public static IEnumerable<SecurityRoom> fillRoom(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);
            SqlCommand roomCommand = new SqlCommand($"SELECT К.Id, К.[Номер кабинета], К.[Номер отдела] as idОтдела, О.[Название отдела] as НазваниеОтдела FROM Кабинеты as К JOIN Отделы as О on О.Id = К.[Номер отдела] WHERE О.Id = {id}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = roomCommand.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var roomId = reader.GetInt32(0);
                    var roomName = reader.GetString(1);
                    var departmentNumber = reader.GetInt32(2);
                    yield return new SecurityRoom { roomId = roomId, roomName = roomName, departmentNumber = departmentNumber};
                }
            }
            reader.Close();
            sqlConnection.Close();
        }
        public static DataTable employByRoom(string roomNumber)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM [Сотрудники] INNER JOIN [Кабинеты] ON [Сотрудники].ID = [Кабинеты].employID WHERE room.roomNumber = " + roomNumber, ConnectionAdres);
            DataTable dataTable = new DataTable("Call Reciept");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
