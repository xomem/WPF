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
        //static string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SOVAJJ\source\repos\PracticeApplication\PracticeApplication\MainDatabase.mdf;Integrated Security=True";
        public static bool checkDepartment(string name)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);
            SqlCommand roomCommand = new SqlCommand($"SELECT [Название отдела] FROM Отделы WHERE [Название отдела]= {name}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = roomCommand.ExecuteReader();
            reader.Read();
            result = reader.HasRows;
            reader.Close();
            sqlConnection.Close();
            return result;
        }

        public static bool addDepartment(string name)
        {
            bool result = checkDepartment(name);
            if (!result)
            {

                var query =
                $"INSERT INTO [Отделы] ([Название отдела]) VALUES(@Отдел);";
                using (SqlConnection connection = new SqlConnection(ConnectionAdres))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("Отдел", name);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return result;
        }

        public static bool checkRoom(int roomNumber)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);
            SqlCommand roomCommand = new SqlCommand($"SELECT [Номер кабинета] FROM Кабинеты WHERE [Номер кабинета] = {roomNumber}", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = roomCommand.ExecuteReader();
            reader.Read();
            result = reader.HasRows;
            reader.Close();
            sqlConnection.Close();
            return result;
        }
        public static bool addRoom(int number, int department)
        {
            bool result = checkRoom(number);
            if (!result)
            {

                var query =
                $"INSERT INTO [Кабинеты] ([Номер кабинета], [Номер отдела]) VALUES(@Кабинет, @Отдел);";
                using (SqlConnection connection = new SqlConnection(ConnectionAdres))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("Кабинет", number);
                    command.Parameters.AddWithValue("Отдел", department);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return result;
        }
        //public static void addRoom(int number, int department)
        //{
        //    bool result = checkRoom(number);
        //    if (!result)
        //    {

        //        var query =
        //        $"INSERT INTO [Кабинеты] ([Номер кабинета], [Номер отдела]) VALUES(@Кабинет, @Отдел);";
        //        using (SqlConnection connection = new SqlConnection(ConnectionAdres))
        //        {
        //            connection.Open();
        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("Кабинет", number);
        //            command.Parameters.AddWithValue("Отдел", department);
        //            command.ExecuteNonQuery();
        //            connection.Close();
        //        }
        //        Add.AddRoom.successfully();
        //    }
        //    else
        //    {
        //        Add.AddRoom.alreadeExists();
        //    }
        //}
        public static void addEmploy(string name, string surname, string patronymic, string date, int position, int department, string city, string adres, string phone)
        {
            var query =
            $"INSERT INTO [Сотрудники] (Имя, Фамилия, Отчество, [Дата рождения], Должность, Отдел, Город, Адрес, Телефон) VALUES(@Имя, @Фамилия, @Отчество, @Дата, @Должность, @Отдел, @Город, @Адрес, @Телефон);";
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Имя", name);
                command.Parameters.AddWithValue("Фамилия", surname);
                command.Parameters.AddWithValue("Отчество", patronymic);
                command.Parameters.AddWithValue("Дата", date);
                command.Parameters.AddWithValue("Должность", position);
                command.Parameters.AddWithValue("Отдел", department);
                command.Parameters.AddWithValue("Город", city);
                command.Parameters.AddWithValue("Адрес", adres);
                command.Parameters.AddWithValue("Телефон", phone);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable readEmployers()
        {
            //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Сотрудники]", ConnectionAdres);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id", ConnectionAdres);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static DataTable readRoom()
        {
            //SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Сотрудники]", ConnectionAdres);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id", ConnectionAdres);

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
                do
                {
                    var positionId = reader.GetInt32(0);
                    var positionName = reader.GetString(1);
                    yield return new SecurityPosition { positionId = positionId, positionName = positionName };
                }
                while (reader.Read());
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
            {
                do
                {
                    var departmentId = reader.GetInt32(0);
                    var departmentName = reader.GetString(1);
                    yield return new SecurityDepartment { departmentId = departmentId, departmentName = departmentName };
                }
                while (reader.Read());
            }
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
                do
                {
                    var roomId = reader.GetInt32(0);
                    var roomName = reader.GetString(1);
                    var departmentNumber = reader.GetInt32(2);
                    yield return new SecurityRoom { roomId = roomId, roomName = roomName, departmentNumber = departmentNumber };
                }
                while (reader.Read());
            }
            reader.Close();
            sqlConnection.Close();
        }
        public static DataTable employBySurname(string surname)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id WHERE c.Фамилия = N'" + surname +"'", ConnectionAdres);
            DataTable dataTable = new DataTable("Call Reciept");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
