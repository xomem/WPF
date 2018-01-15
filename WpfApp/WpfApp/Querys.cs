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


namespace WpfApp
{
    public class Querys
    {

        //static string ConnectionAdres = @"Data source=(LocalDB)\MSSQLLocalDB;Attachdbfilename=|DataDirectory|\MainDatabase.mdf;‌​Integrated Security=True;MultipleActiveResultSets=True;";
        static string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SOVAJJ\Google Drive\WpfApp\WpfApp\MainDatabase.mdf;Integrated Security=True";

        public static DataTable employByRoom(string roomNumber)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM employment INNER JOIN room ON employment.ID = room.employID WHERE room.roomNumber = " + roomNumber, ConnectionAdres);
            DataTable dt = new DataTable("Call Reciept");
            da.Fill(dt);
            return dt;

        }
        public static DataTable readEmployers()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [employment]", ConnectionAdres);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
            //var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            //try
            //{
            //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [employment]", ConnectionAdres);
            //    DataTable dt = new DataTable("Call Reciept");
            //    da.Fill(dt);
            //    mainWindow.successfulConnection();
            //    return dt;
            //}
            //catch (Exception ex)
            //{
            //    mainWindow.errorConnection(ex);
            //    return null;
            //}
        }
        public static DataTable readHDD()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [hardDrive]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }
        public static DataTable readTech()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [technic]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }
        public static DataTable readSysCharacter()
        {
            var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [systemCharacteristic]", ConnectionAdres);
                DataTable dt = new DataTable("Call Reciept");
                da.Fill(dt);
                mainWindow.successfulConnection();
                return dt;
            }
            catch (Exception ex)
            {
                mainWindow.errorConnection(ex);
                return null;
            }
        }



        //public async void connectDB(MainWindow MainWin)
        //{
        //    this.MainWin = MainWin;
        //    string ConnectionAdres = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Edward\source\repos\WpfApp\WpfApp\MainDatabase.mdf;Integrated Security=True";
        //    SqlConnection = new SqlConnection(ConnectionAdres);

        //    await SqlConnection.OpenAsync();

        //    SqlDataReader SQLDReader = null;

        //    SqlCommand GetAllEmployCommand = new SqlCommand("SELECT * FROM [employment]", SqlConnection);



        //    try
        //    {
        //        MainWin.Status.Content = "Подключено к БД";

        //        while (await SQLDReader.ReadAsync())
        //        {
        //            string test = Convert.ToString(SQLDReader["ID"]) + Convert.ToString(SQLDReader["surname"]) + Convert.ToString(SQLDReader["name"]) + Convert.ToString(SQLDReader["patronymic"]);
        //            MainWin.checkConnect(test);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MainWin.connectError(ex);
        //        MainWin.Status.Content = "Ошибка подключения к БД" + " - " + ex;
        //    }
        //    finally
        //    {
        //        if (SQLDReader != null)
        //        {
        //            SQLDReader.Close();
        //        }
        //    }
        //}

        //public void closeConnect()
        //{
        //    if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
        //    {
        //        SqlConnection.Close();
        //        MainWin.Status.Content = "Подключение закрыто";
        //    }
        //}
    }
}
