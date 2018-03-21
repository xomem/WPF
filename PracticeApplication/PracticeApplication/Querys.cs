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


        public static Employer GetEmployDataByID(string id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);

            Employer employer = null;
            SqlCommand nameComand = new SqlCommand($"SELECT * FROM [Сотрудники] WHERE Id = '{id}';", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = nameComand.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                var name = reader.GetString(1);
                var surname = reader.GetString(2);
                var patronymic = reader.GetString(3);
                var dateOfBirth = reader.GetDateTime(4);
                var position = reader.GetInt32(5);
                var department = reader.GetInt32(6);
                var room = reader.GetInt32(7);
                var city = reader.GetString(8);
                var adres = reader.GetString(9);
                var phone = reader.GetString(10);
                employer = new Employer { name = name, surname = surname, patronymic = patronymic, dateOfBirth = Convert.ToString( dateOfBirth), position = Convert.ToInt32(position), department = Convert.ToInt32(department), room = Convert.ToInt32(room),city= city, adres = adres,phone = phone };
            }
            reader.Close();
            sqlConnection.Close();
            return employer;
        }
        public static void addPosition(string name, string salary)
        {
            var query =
            $"INSERT INTO [Должности] ([Название должности], Оклад) VALUES(@Название, @Оклад);";
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Название", name);
                command.Parameters.AddWithValue("Оклад", salary);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static bool removePosition(string id)
        {

            var query = $"DELETE FROM [Должности] WHERE [Id] = N'{id}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool removeDepartment(string id)
        {
            var query = $"DELETE FROM [Отделы] WHERE [Id] = '{id}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool removeEmploy(string name)
        {
            var query = $"DELETE FROM [Сотрудники] WHERE [Фамилия] = N'{name}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
            return result;
        }
        public static bool removeRoom(string number)
        {
            var query = $"DELETE FROM [Кабинеты] WHERE [Номер кабинета] = '{number}';";
            bool result = false;
            using (SqlConnection connection = new SqlConnection(ConnectionAdres))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery() >= 1;
                connection.Close();
            }
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
        public static bool checkDepartment(string name)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);
            SqlCommand roomCommand = new SqlCommand($"SELECT [Название отдела] FROM Отделы WHERE [Название отдела]= N'{name}';", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = roomCommand.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
            sqlConnection.Close();
            return result;
        }

        public static bool checkRoom(int roomNumber)
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);
            SqlCommand roomCommand = new SqlCommand($"SELECT [Номер кабинета] FROM Кабинеты WHERE [Номер кабинета] = {roomNumber};", sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = roomCommand.ExecuteReader();
            //reader.Read();
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
        public static void addEmploy(string name, string surname, string patronymic, string date, int position, int department, string city, string adres, string phone, string room)
        {
            var query =
            $"INSERT INTO [Сотрудники] (Имя, Фамилия, Отчество, [Дата рождения], Должность, Отдел, Город, Адрес, Телефон, Кабинет) VALUES(@Имя, @Фамилия, @Отчество, @Дата, @Должность, @Отдел, @Город, @Адрес, @Телефон, @Кабинет);";
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
                command.Parameters.AddWithValue("Кабинет", room);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static DataTable readDepartment()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT   [Отделы].[Id], [Отделы].[Название отдела], COUNT([Сотрудники].Отдел) AS[Количество сотрудников] FROM[Отделы], [Сотрудники] WHERE[Сотрудники].[Отдел]   = [Отделы].[Id] GROUP BY[Отделы].[Id], [Отделы].[Название отдела]", ConnectionAdres);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static DataTable readPosition()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Должности]", ConnectionAdres);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static DataTable readEmployers()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT c.Id, c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id", ConnectionAdres);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static DataTable readRoom()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT   [Кабинеты].[Номер кабинета],  [Отделы].[Название отдела], COUNT([Сотрудники].[Кабинет]) AS[Количество сотрудников] FROM[Кабинеты],  [Отделы], [Сотрудники] WHERE[Сотрудники].[Кабинет] = [Кабинеты].[Id] AND[Сотрудники].[Отдел]   = [Отделы].[Id] GROUP BY[Кабинеты].[Номер кабинета],  [Отделы].[Название отдела]", ConnectionAdres);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable employBySurname(string surname)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT c.Имя, c.Фамилия, c.Отчество, c.[Дата рождения], c.Город, c.Адрес, c.Телефон, o.[Название отдела], d.[Название должности], r.[Номер кабинета] FROM[Сотрудники] AS c INNER JOIN Отделы AS o ON c.Отдел = o.Id INNER JOIN Должности AS d ON c.Должность = d.Id INNER JOIN Кабинеты AS r ON c.Кабинет = r.Id WHERE c.Фамилия = N'" + surname + "'", ConnectionAdres);
            DataTable dataTable = new DataTable("Call Reciept");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static IEnumerable<SecurityPosition> fillPosition()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionAdres);

            SqlCommand nameComand = new SqlCommand($"SELECT [Id], [Название должности] FROM [Должности]", sqlConnection);
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
    }
}
